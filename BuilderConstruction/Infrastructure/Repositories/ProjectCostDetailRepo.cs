using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Infrastructure.Repositories
{
    public interface IProjectCostDetailRepo : IGenericRepo<ProjectCostDetail>
    {

    }
    public class ProjectCostDetailRepo : GenericRepo<ProjectCostDetail>, IProjectCostDetailRepo
    {
        public ProjectCostDetailRepo(InvContext context) : base(context)
        {
        }
    }
}
