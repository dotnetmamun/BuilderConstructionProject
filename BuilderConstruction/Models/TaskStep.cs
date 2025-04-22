using System.ComponentModel.DataAnnotations.Schema;

namespace BuilderConstruction.Models
{
    public class TaskStep
    {
        public int Id { get; set; }

        public string StepName { get; set; } = null!;

        public int? TaskOrder { get; set; }
        [ForeignKey(nameof(BuildingTask))]

        public int? BuildingTaskId { get; set; }

        public virtual BuildingTask? BuildingTask { get; set; }

        public virtual ICollection<TaskDetail> TaskDetails { get; set; } = new List<TaskDetail>();
    }
}