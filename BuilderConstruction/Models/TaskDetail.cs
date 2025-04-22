using System.ComponentModel.DataAnnotations.Schema;

namespace BuilderConstruction.Models
{
    public class TaskDetail
    {
        public int Id { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalCost { get; set; }

        public int? ManPower { get; set; }

        public decimal? ManPowerCost { get; set; }

        public int? Duration { get; set; }

        public string? WorkingPlace { get; set; }
        [ForeignKey(nameof(Project))]

        public int? ProjectId { get; set; }
        [ForeignKey(nameof(TaskStep))]

        public int? TaskStepId { get; set; }
        [ForeignKey(nameof(BuildingTask))]

        public int? BuildingTaskId { get; set; }
        [ForeignKey(nameof(Material))]

        public int? MaterialId { get; set; }

        public Material? Material { get; set; }

        public Project? Project { get; set; }

        public BuildingTask? BuildingTask { get; set; }

        public TaskStep? TaskStep { get; set; }
    }
}