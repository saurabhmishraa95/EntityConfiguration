using EntityConfiguration.Models;
using EntityConfiguration.Translators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EntityConfiguration.Tests.TranslatorTests
{
    public class ColorTranslatorTests
    {
        [Test]
        public void TestColorTranslatorWhenRequestIsNull()
        {
            List<FieldEntity> fieldEntities = null;
            var translation = fieldEntities.ToColors();
            Assert.IsNull(translation);
        } 
        
        [Test]
        public void TestColorTranslator()
        {
            List<FieldEntity> fieldEntities = GetMockFieldEntities();
            var translation = fieldEntities.ToColors();
            Assert.IsNotNull(translation);
            Assert.AreEqual(translation.Count, 2);
            Assert.AreEqual(translation[0].FieldName, fieldEntities[0].Field);
            Assert.AreEqual(translation[0].IsRequired, fieldEntities[0].IsRequired);
            Assert.AreEqual(translation[0].MaxLength, fieldEntities[0].MaxLength);
            Assert.AreEqual(translation[1].FieldName, fieldEntities[1].Field);
            Assert.AreEqual(translation[1].IsRequired, fieldEntities[1].IsRequired);
            Assert.AreEqual(translation[1].MaxLength, fieldEntities[1].MaxLength);
        }

        private List<FieldEntity> GetMockFieldEntities()
        {
            return new List<FieldEntity>
            {
                new FieldEntity
                {
                    Field = "Blue",
                    IsRequired = true,
                    MaxLength = 10
                },
                new FieldEntity
                {
                    Field = "Grey",
                    IsRequired = false,
                    MaxLength = 15
                }
            };
        }
    }
}
