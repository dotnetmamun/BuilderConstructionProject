using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Models
{
    public class Material
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        [ForeignKey(nameof(Unit))]

        public int? UnitId { get; set; }

        public virtual ICollection<ProjectCostDetail> ProjectCostDetails { get; set; } = new List<ProjectCostDetail>();

        public virtual ICollection<TaskDetail> TaskDetails { get; set; } = new List<TaskDetail>();

        public Unit? Unit { get; set; }
    }
}
