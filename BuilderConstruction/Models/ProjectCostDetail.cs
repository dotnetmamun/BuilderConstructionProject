using System.ComponentModel.DataAnnotations.Schema;

namespace BuilderConstruction.Models
{
    public class ProjectCostDetail
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Material))]

        public int? MaterialId { get; set; }

        public int? UnitQuantity { get; set; }

        public double? UnitPrice { get; set; }
        [ForeignKey(nameof(ProjectCost))]

        public int? ProjectCostId { get; set; }

        public double? TotalCost { get; set; }

        public Material? Material { get; set; }

        public ProjectCost? ProjectCost { get; set; }
    }
}