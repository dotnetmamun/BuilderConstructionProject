using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Infrastructure.Repositories
{
    public interface ITaskStepRepo : IGenericRepo<TaskStep>
    {

    }
    public class TaskStepRepo : GenericRepo<TaskStep>, ITaskStepRepo
    {
        public TaskStepRepo(InvContext context) : base(context)
        {
        }
    }
}
