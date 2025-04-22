using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime? JoiningDate { get; set; }

        public decimal? Salary { get; set; }

        public int? Age { get; set; }

        public virtual ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();
    }
}
