using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Models
{
    public class BuildingTask
    {
        public int Id { get; set; }

        public string? TaskName { get; set; }

        public int? TaskOrder { get; set; }

        public virtual ICollection<ProjectCost> ProjectCosts { get; set; } = new List<ProjectCost>();

        public virtual ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();

        public virtual ICollection<TaskDetail> TaskDetails { get; set; } = new List<TaskDetail>();

        public virtual ICollection<TaskStep> TaskSteps { get; set; } = new List<TaskStep>();
    }
}
