using System.ComponentModel.DataAnnotations.Schema;

namespace BuilderConstruction.Models
{
    public class ProjectCost
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public decimal? LabourCost { get; set; }

        public decimal? OtherCost { get; set; }

        public decimal? TotalCost { get; set; }
        [ForeignKey(nameof(BuildingTask))]

        public int? TaskId { get; set; }
        [ForeignKey(nameof(Project))]

        public int? ProjectId { get; set; }

        public Project? Project { get; set; }

        public virtual ICollection<ProjectCostDetail> ProjectCostDetails { get; set; } = new List<ProjectCostDetail>();

        public BuildingTask? BuildingTask { get; set; }
    }
}