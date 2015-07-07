﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ilaro.Admin.Extensions;
using Ilaro.Admin.Filters;
using Ilaro.Admin.Models;
using Massive;
using Resources;

namespace Ilaro.Admin.Core.Data
{
    public class RecordsSource : IFetchingRecords
    {
        private readonly Notificator _notificator;

        public RecordsSource(Notificator notificator)
        {
            if (notificator == null)
                throw new ArgumentNullException("notificator");

            _notificator = notificator;
        }

        public Entity GetEntityWithData(string entityName, string key)
        {
            var entity = AdminInitialise.EntitiesTypes
                .FirstOrDefault(x => x.Name == entityName);

            if (entity == null)
                return null;

            var item = GetRecord(entity, entity.Key.Value.ToObject(key));
            if (item == null)
            {
                _notificator.Error(IlaroAdminResources.EntityNotExist);
                return null;
            }

            var propertiesDict = item as IDictionary<string, object>;

            foreach (var property in entity.CreateProperties(false))
            {
                property.Value.Raw =
                    propertiesDict.ContainsKey(property.ColumnName) ?
                    propertiesDict[property.ColumnName] :
                    null;
            }

            return entity;
        }

        public object GetRecord(Entity entity, object key)
        {
            var table = new DynamicModel(
                AdminInitialise.ConnectionStringName,
                tableName: entity.TableName,
                primaryKeyField: entity.Key.ColumnName);

            var result = table.Single(key);

            return result;
        }

        public PagedRecords GetRecords(
            Entity entity,
            IList<IEntityFilter> filters = null,
            string searchQuery = null,
            string order = null,
            string orderDirection = null,
            bool determineDisplayValue = false,
            int? page = null,
            int? take = null)
        {
            var search = new EntitySearch
            {
                Query = searchQuery,
                Properties = entity.SearchProperties
            };
            order = order.IsNullOrEmpty() ? entity.Key.ColumnName : order;
            orderDirection = orderDirection.IsNullOrEmpty() ?
                "ASC" :
                orderDirection.ToUpper();
            var orderBy = order + " " + orderDirection;
            var columns = string.Join(",",
                entity.Properties
                    .Where(x =>
                        !x.IsForeignKey ||
                        (!x.TypeInfo.IsCollection && x.IsForeignKey))
                    .Select(x => x.ColumnName)
                    .Distinct());
            List<object> args;
            var where = ConvertFiltersToSql(filters, search, out args);

            var table = new DynamicModel(
                AdminInitialise.ConnectionStringName,
                entity.TableName,
                entity.Key.ColumnName);

            if (page.HasValue && take.HasValue)
            {
                var result = table.Paged(
                    columns: columns,
                    where: where,
                    orderBy: orderBy,
                    currentPage: page.Value,
                    pageSize: take.Value,
                    args: args.ToArray());

                var data = new List<DataRow>();
                foreach (var item in result.Items)
                {
                    data.Add(new DataRow(item, entity));
                }

                return new PagedRecords
                {
                    TotalItems = result.TotalRecords,
                    TotalPages = result.TotalPages,
                    Records = data
                };
            }
            else
            {
                var result = table.All(
                    columns: columns,
                    where: where,
                    orderBy: orderBy,
                    args: args.ToArray());

                var data = result
                    .Select(item => new DataRow(item, entity))
                    .ToList();

                if (determineDisplayValue)
                {
                    foreach (var row in data)
                    {
                        row.DisplayName = entity.ToString(row);
                    }
                }

                return new PagedRecords
                {
                    Records = data
                };
            }
        }

        private static string ConvertFiltersToSql(
            IList<IEntityFilter> filters,
            EntitySearch search,
            out List<object> args,
            string alias = "")
        {
            args = new List<object>();
            if (filters == null)
            {
                filters = new List<IEntityFilter>();
            }

            var activeFilters = filters
                .Where(x => !x.Value.IsNullOrEmpty())
                .ToList();
            if (!activeFilters.Any() && !search.IsActive)
            {
                return null;
            }

            if (!alias.IsNullOrEmpty())
            {
                alias += ".";
            }

            var sbConditions = new StringBuilder();
            foreach (var filter in activeFilters)
            {
                var condition = filter.GetSqlCondition(alias, ref args);

                if (!condition.IsNullOrEmpty())
                {
                    sbConditions.AppendFormat(" {0} AND", condition);
                }
            }

            if (search.IsActive)
            {
                var searchCondition = String.Empty;
                foreach (var property in search.Properties)
                {
                    var query = search.Query.TrimStart('>', '<');
                    decimal temp;
                    if (property.TypeInfo.IsString)
                    {
                        searchCondition += " {0}[{1}] LIKE @{2} OR"
                            .Fill(alias, property.Name, args.Count);
                        args.Add("%" + search.Query + "%");
                    }
                    else if (decimal.TryParse(query, out temp))
                    {
                        var sign = "=";
                        if (search.Query.StartsWith(">"))
                        {
                            sign = ">=";
                        }
                        else if (search.Query.StartsWith("<"))
                        {
                            sign = "<=";
                        }

                        searchCondition += " {0}[{1}] {2} @{3} OR"
                            .Fill(alias, property.Name, sign, args.Count);
                        args.Add(temp);
                    }
                }

                if (!searchCondition.IsNullOrEmpty())
                {
                    searchCondition = searchCondition
                        .TrimStart(' ')
                        .TrimEnd("OR".ToCharArray());
                    sbConditions.AppendFormat(" ({0})", searchCondition);
                }
            }

            var conditions = sbConditions.ToString();
            if (conditions.IsNullOrEmpty())
            {
                return null;
            }

            return " WHERE" + conditions.TrimEnd("AND".ToCharArray());
        }
    }
}