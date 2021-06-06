using EntityConfiguration.Models.Database;
using EntityConfiguration.Translators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityConfiguration.Tests.TranslatorTests
{
    public class EntityTranslatorTests
    {
        [Test]
        public void TestEntityTranslatorWhenRequestIsNull()
        {
            List<Color> colors = null;
            var translation = colors.ToEntities("");
            Assert.IsNull(translation);
        }
        
        [Test]
        public void TestEntityTranslator()
        {
            List<Color> colors = GetMockColors();
            var translation = colors.ToEntities(Constants.DefaultSource);
            Assert.IsNotNull(translation);
            Assert.AreEqual(translation.Count, 2);
            Assert.AreEqual(translation[0].Field, colors[0].FieldName);
            Assert.AreEqual(translation[0].IsRequired, colors[0].IsRequired);
            Assert.AreEqual(translation[0].MaxLength, colors[0].MaxLength);
            Assert.AreEqual(translation[0].Source, Constants.DefaultSource);
        }

        private List<Color> GetMockColors()
        {
            return new List<Color>
            {
                new Color
                {
                    FieldName = "Blue",
                    IsRequired = true,
                    MaxLength = 10
                },
                new Color
                {
                    FieldName = "Green",
                    IsRequired = true,
                    MaxLength = 1
                }
            };
        }
    }
}
