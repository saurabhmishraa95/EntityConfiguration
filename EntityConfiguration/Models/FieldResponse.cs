namespace EntityConfiguration.Models
{
    public class FieldResponse
    {
        public string Field { get; set; }
        public bool IsRequired { get; set; }
        public int MaxLength { get; set; }
        public string Source { get; set; }
    }
}