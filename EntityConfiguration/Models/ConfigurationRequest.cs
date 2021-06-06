using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityConfiguration.Models
{
    public class ConfigurationRequest
    {
        [Required(ErrorMessage = "entities can't be empty")]
        public List<EntityDescription> Entities { get; set; }
    }
}
