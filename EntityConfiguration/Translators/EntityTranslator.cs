using EntityConfiguration.Models;
using EntityConfiguration.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityConfiguration.Translators
{
    public static class EntityTranslator
    {
        public static List<FieldResponse> ToEntities(this List<Color> colors, string source)
        {
            if (colors != null && colors.Count != 0)
                return colors.Select(c => c.ToFieldResponse(source)).ToList();
            return null;
        }

        private static FieldResponse ToFieldResponse(this Color color, string source)
        {
            if (color == null)
                return null;
            return new FieldResponse
            {
                Field = color.FieldName,
                IsRequired = color.IsRequired,
                MaxLength = color.MaxLength,
                Source = source
            };
        }
    }
}
