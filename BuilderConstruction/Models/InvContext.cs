using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Models
{
    public class InvContext : IdentityDbContext<ApplicationUser>
    {
        public InvContext(DbContextOptions<InvContext> op) : base(op)
        {

        }
        //public DbSet<Category> Categories { get; set; }
        public DbSet<BuildingTask> BuildingTasks { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCost> ProjectCosts { get; set; }
        public DbSet<ProjectCostDetail> ProjectCostDetails { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<TaskDetail> TaskDetails { get; set; }
        public DbSet<TaskStep> TaskSteps { get; set; }
        public DbSet<Unit> Units { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= DESKTOP-8G9B3DO\\SQLEXPRESS; Initial Catalog=DBFirstProject; Trusted_connection=true; TrustServerCertificate=true; ");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
