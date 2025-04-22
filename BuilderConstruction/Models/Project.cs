using System.ComponentModel.DataAnnotations.Schema;

namespace BuilderConstruction.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string LocationLink { get; set; }

        public string? ProjectLocation { get; set; }

        public double? LandSizekatha { get; set; }

        public double? TotalPrice { get; set; }
        [ForeignKey(nameof(Company))]

        public int? ComId { get; set; }

        public Company? Company { get; set; }

        public virtual ICollection<ProjectCost> ProjectCosts { get; set; } = new List<ProjectCost>();

        public virtual ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();

        public virtual ICollection<TaskDetail> TaskDetails { get; set; } = new List<TaskDetail>();
        public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();
    }
}