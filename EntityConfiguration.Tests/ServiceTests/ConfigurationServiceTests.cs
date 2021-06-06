using EntityConfiguration.Adaptors;
using EntityConfiguration.Models;
using EntityConfiguration.Models.Database;
using EntityConfiguration.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EntityConfiguration.Tests.ServiceTests
{
    public class ConfigurationServiceTests
    {
        private readonly Mock<ICustomFieldAdaptor> customFieldAdaptor = new Mock<ICustomFieldAdaptor>();
        private readonly Mock<IDefaultFieldAdaptor> defaultFieldAdaptor = new Mock<IDefaultFieldAdaptor>();
        private DbContextOptions<ConfigurationContext> options = new DbContextOptionsBuilder<ConfigurationContext>()
            .UseInMemoryDatabase(databaseName: "Configuration")
            .Options;

        public ConfigurationServiceTests()
        {
            using (var context = new ConfigurationContext(options))
            {
                context.Color.Add(new Color
                {
                    FieldName = "Blue",
                    IsRequired = true,
                    MaxLength = 15
                });
                context.Color.Add(new Color
                {
                    FieldName = "Red",
                    IsRequired = true,
                    MaxLength = 10
                });

                context.SaveChanges();
            }
        }

        [Test]
        public async Task TestGetConfigurationAsync()
        {
            customFieldAdaptor.Setup(x => x.GetFieldsAsync(It.IsAny<string>())).ReturnsAsync(GetCustomFields());
            defaultFieldAdaptor.Setup(x => x.GetFieldsAsync(It.IsAny<string>())).ReturnsAsync(GetDefaultFields());

            var configurationService = new ConfigurationService(customFieldAdaptor.Object, defaultFieldAdaptor.Object);
            configurationService.context = new ConfigurationContext(options);
            var configurationResponse = await configurationService.GetConfigurationAsync();
            Assert.IsNotNull(configurationResponse);
            Assert.AreEqual(configurationResponse.Entities.Count,1);
            Assert.AreEqual(configurationResponse.Entities[0].EntityName,"Color");
            Assert.AreEqual(configurationResponse.Entities[0].Fields.Count,2);
            Assert.AreEqual(configurationResponse.Entities[0].Fields[0].Field,"Blue");
            Assert.AreEqual(configurationResponse.Entities[0].Fields[0].IsRequired,true);
            Assert.AreEqual(configurationResponse.Entities[0].Fields[0].MaxLength,15);
            Assert.AreEqual(configurationResponse.Entities[0].Fields[0].Source,Constants.DefaultSource);
        }

        private FieldNameSet GetDefaultFields()
        {
            return new FieldNameSet
            {
                Fields = new List<string> { "Grey", "Blue" }
            };
        }

        private FieldNameSet GetCustomFields()
        {
            return new FieldNameSet
            {
                Fields = new List<string> { "Maroon", "Red" }
            };
        }
    }
}
