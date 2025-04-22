using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Contact { get; set; }

        public string? Email { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
