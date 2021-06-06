using System;
using System.Collections.Generic;

namespace EntityConfiguration.Models.Database
{
    public partial class Color
    {
        public string FieldName { get; set; }
        public bool IsRequired { get; set; }
        public int MaxLength { get; set; }
    }
}
