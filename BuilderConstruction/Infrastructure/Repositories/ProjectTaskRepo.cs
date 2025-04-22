using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Infrastructure.Repositories
{
    public interface IProjectTaskRepo : IGenericRepo<ProjectTask>
    {

    }
    public class ProjectTaskRepo : GenericRepo<ProjectTask>, IProjectTaskRepo
    {
        public ProjectTaskRepo(InvContext context) : base(context)
        {
        }
    }
}
