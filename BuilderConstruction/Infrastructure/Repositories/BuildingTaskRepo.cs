using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Infrastructure.Repositories
{
    public interface IBuildingTaskRepo : IGenericRepo<BuildingTask>
    {

    }
    public class BuildingTaskRepo : GenericRepo<BuildingTask>, IBuildingTaskRepo
    {
        public BuildingTaskRepo(InvContext context) : base(context)
        {
        }
    }
}
