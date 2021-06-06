using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityConfiguration.Models
{
    public class EntityDescription
    {
        [Required]
        public string EntityName { get; set; }
        public List<FieldEntity> Fields { get; set; }
    }
}
