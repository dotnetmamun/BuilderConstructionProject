namespace BuilderConstruction.Models
{
    public class Unit
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? ShortName { get; set; }

        public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}