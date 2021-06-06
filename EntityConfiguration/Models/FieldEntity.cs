using System.ComponentModel.DataAnnotations;

namespace EntityConfiguration.Models
{
    public class FieldEntity
    {
        [Required]
        public string Field { get; set; }
        public bool IsRequired { get; set; }
        public int MaxLength { get; set; }
    }
}