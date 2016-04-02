﻿using System;
using Ilaro.Admin.Core;
using Ilaro.Admin.DataAnnotations;
using System.Collections.Generic;
using Ilaro.Admin.Core.Data;

namespace Ilaro.Admin.Configuration.Customizers
{
    public class PropertyCustomizer : IPropertyCustomizer
    {
        private PropertyCustomizerHolder propertyCustomizerHolder;

        public PropertyCustomizer(PropertyCustomizerHolder propertyCustomizerHolder)
        {
            if (propertyCustomizerHolder == null)
                throw new ArgumentNullException(nameof(propertyCustomizerHolder));

            this.propertyCustomizerHolder = propertyCustomizerHolder;
        }

        public IPropertyCustomizer Column(string columnName)
        {
            propertyCustomizerHolder.Column = columnName;

            return this;
        }

        public IPropertyCustomizer OnCreateDefaultValue(ValueBehavior behavior)
        {
            propertyCustomizerHolder.OnCreateDefaultValue = behavior;

            return this;
        }

        public IPropertyCustomizer OnCreateDefaultValue(object value)
        {
            propertyCustomizerHolder.OnCreateDefaultValue = value;

            return this;
        }

        public IPropertyCustomizer OnUpdateDefaultValue(ValueBehavior behavior)
        {
            propertyCustomizerHolder.OnUpdateDefaultValue = behavior;

            return this;
        }

        public IPropertyCustomizer OnUpdateDefaultValue(object value)
        {
            propertyCustomizerHolder.OnUpdateDefaultValue = value;

            return this;
        }

        public IPropertyCustomizer Display(string name, string description)
        {
            propertyCustomizerHolder.DisplayName = name;
            propertyCustomizerHolder.Description = description;

            return this;
        }

        public IPropertyCustomizer File(
            NameCreation nameCreation,
            long maxFileSize,
            bool isImage,
            string path,
            params string[] allowedFileExtensions)
        {
            if (propertyCustomizerHolder.FileOptions == null)
            {
                propertyCustomizerHolder.FileOptions = new FileOptions
                {
                    Settings = new List<ImageSettings>()
                };
            }

            propertyCustomizerHolder.FileOptions.NameCreation = nameCreation;
            propertyCustomizerHolder.FileOptions.MaxFileSize = maxFileSize;
            propertyCustomizerHolder.FileOptions.IsImage = isImage;
            propertyCustomizerHolder.FileOptions.Path = path;
            propertyCustomizerHolder.FileOptions.AllowedFileExtensions = allowedFileExtensions;

            return Type(isImage ? DataType.Image : DataType.File);
        }

        public IPropertyCustomizer ForeignKey(string name)
        {
            propertyCustomizerHolder.IsForeignKey = true;
            propertyCustomizerHolder.ForeignKey = name;

            return this;
        }

        public IPropertyCustomizer Format(string dataFormatString)
        {
            propertyCustomizerHolder.Format = dataFormatString;

            return this;
        }

        public IPropertyCustomizer Id()
        {
            propertyCustomizerHolder.IsKey = true;

            return this;
        }

        public IPropertyCustomizer Image(string path, int? width, int? height)
        {
            if (propertyCustomizerHolder.FileOptions == null)
            {
                propertyCustomizerHolder.FileOptions = new FileOptions
                {
                    NameCreation = NameCreation.OriginalFileName,
                    Settings = new List<ImageSettings>()
                };
            }

            propertyCustomizerHolder.FileOptions.Settings.Add(new ImageSettings(path, width, height));

            return Type(DataType.Image);
        }

        public IPropertyCustomizer ForeignDelete(DeleteOption deleteOption)
        {
            propertyCustomizerHolder.ForeignDeleteOption = deleteOption;

            return this;
        }

        public IPropertyCustomizer Required(string errorMessage)
        {
            propertyCustomizerHolder.IsRequired = true;
            propertyCustomizerHolder.RequiredErrorMessage = errorMessage;

            return this;
        }

        public IPropertyCustomizer Searchable()
        {
            propertyCustomizerHolder.IsSearchable = true;

            return this;
        }

        public IPropertyCustomizer Template(string display = null, string editor = null)
        {
            propertyCustomizerHolder.DisplayTemplate = display;
            propertyCustomizerHolder.EditorTemplate = editor;

            return this;
        }

        public IPropertyCustomizer Type(DataType dataType)
        {
            propertyCustomizerHolder.DataType = dataType;

            return this;
        }

        public IPropertyCustomizer Type(System.ComponentModel.DataAnnotations.DataType dataType)
        {
            propertyCustomizerHolder.SourceDataType = dataType;

            return Type(DataTypeConverter.Convert(dataType));
        }

        public IPropertyCustomizer Enum(Type enumType)
        {
            propertyCustomizerHolder.EnumType = enumType;

            return Type(DataType.Enum);
        }

        public IPropertyCustomizer Visible()
        {
            propertyCustomizerHolder.IsVisible = true;

            return this;
        }
    }
}