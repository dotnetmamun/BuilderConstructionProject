using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Infrastructure.Repositories
{
    public interface IProjectRepo : IGenericRepo<Project>
    {

    }
    public class ProjectRepo : GenericRepo<Project>, IProjectRepo
    {
        public ProjectRepo(InvContext context) : base(context)
        {
        }
    }
}
