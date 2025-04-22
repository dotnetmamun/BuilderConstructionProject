using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        [Required, ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
