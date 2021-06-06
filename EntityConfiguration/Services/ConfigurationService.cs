using Microsoft.EntityFrameworkCore;
using EntityConfiguration.Adaptors;
using EntityConfiguration.Models;
using EntityConfiguration.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityConfiguration.Translators;

namespace EntityConfiguration.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private ICustomFieldAdaptor customFieldAdaptor;
        private IDefaultFieldAdaptor defaultFieldAdaptor;
        public ConfigurationContext context;

        public ConfigurationService(ICustomFieldAdaptor customFieldAdaptor, IDefaultFieldAdaptor defaultFieldAdaptor)
        {
            this.customFieldAdaptor = customFieldAdaptor;
            this.defaultFieldAdaptor = defaultFieldAdaptor;
            context = new ConfigurationContext();
        }

        public async Task<ConfigurationResponse> GetConfigurationAsync()
        {
            var defaultFieldAwaitable = defaultFieldAdaptor.GetFieldsAsync(Constants.ColorEntity);
            var customFieldAwaitable = customFieldAdaptor.GetFieldsAsync(Constants.ColorEntity);
            await Task.WhenAll(defaultFieldAwaitable, customFieldAwaitable);
            return new ConfigurationResponse
            {
                Entities = new List<EntityResponse> {
                    GetEntity(defaultFieldAwaitable.Result.Fields, customFieldAwaitable.Result.Fields)
                }
            };
        }

        private EntityResponse GetEntity(List<string> defaultFields, List<string> customFields)
        {
            List<Color> customColorFields, defaultColorFields;
            defaultColorFields = context.Color.Where(c => defaultFields.Any(fieldName => fieldName == c.FieldName)).ToList();
            customColorFields = context.Color.Where(c => customFields.Any(fieldName => fieldName == c.FieldName)).ToList();
            var entity = new EntityResponse
            {
                EntityName = Constants.ColorEntity,
                Fields = defaultColorFields.ToEntities(Constants.DefaultSource)
            };
            entity.Fields.AddRange(customColorFields.ToEntities(Constants.CustomSource));
            return entity;
        }

        public async Task SaveConfigurationAsync(ConfigurationRequest configurationRequest)
        {
            var colors = configurationRequest?.Entities?[0]?.Fields.ToColors();
            await context.Color.ForEachAsync(c =>
            {
                var found = colors.Find(color => color.FieldName == c.FieldName);
                if (found != default(Color))
                {
                    c.IsRequired = found.IsRequired;
                    c.MaxLength = found.MaxLength;
                    colors.Remove(found);
                }
            });
            context.Color.AddRange(colors);
            await context.SaveChangesAsync();
        }
    }
}
