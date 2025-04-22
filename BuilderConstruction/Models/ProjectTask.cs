using System.ComponentModel.DataAnnotations.Schema;

namespace BuilderConstruction.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        [ForeignKey(nameof(BuildingTask))]

        public int? BuildingTaskId { get; set; }
        [ForeignKey(nameof(Project))]

        public int? ProjecId { get; set; }
        [ForeignKey(nameof(Employee))]

        public int? EmployeeId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Note { get; set; }

        public string? Taskstatus { get; set; }

        public Employee? Employee { get; set; }

        public Project? Project { get; set; }

        public BuildingTask? BuildingTask { get; set; }
    }
}