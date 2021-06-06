using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityConfiguration.Models
{
    public class EntityResponse
    {
        public string EntityName { get; set; }
        public List<FieldResponse> Fields { get; set; }
    }
}
