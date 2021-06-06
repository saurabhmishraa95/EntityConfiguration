using EntityConfiguration.Models;
using EntityConfiguration.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityConfiguration.Translators
{
    public static class ColorTranslator
    {
        public static List<Color> ToColors(this List<FieldEntity> request)
        {
            if (request == null)
                return null;
            return request.Select(r => r.ToColor()).ToList();
        }

        private static Color ToColor(this FieldEntity request)
        {
            if (request == null)
                return null;
            return new Color
            {
                FieldName = request.Field,
                IsRequired = request.IsRequired,
                MaxLength = request.MaxLength
            };
        }
    }
}
