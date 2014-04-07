﻿using Ilaro.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resources;

namespace Ilaro.Admin.EntitiesFilters
{
    public class BoolEntityFilter : IEntityFilter
    {
        public PropertyViewModel Property { get; set; }

        public SelectList Options { get; set; }

        public string Value { get; set; }

        public void Initialize(PropertyViewModel property, string value = "")
        {
            Value = value ?? String.Empty;

            Property = property;

            var options = new Dictionary<string, string>
            {
                { IlaroAdminResources.All, String.Empty },
                { IlaroAdminResources.Yes, "1" },
                { IlaroAdminResources.No, "0" }
            };

            Options = new SelectList(options, "Value", "Key", Value);
        }

        public string GetSQLCondition(string alias)
        {
            return string.Format("{0}[{1}] = {2}", alias, Property.Name, Value);
        }
    }
}