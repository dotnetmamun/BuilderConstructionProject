using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Infrastructure.Repositories
{
    public interface ITaskDetailRepo : IGenericRepo<TaskDetail>
    {

    }
    public class TaskDetailRepo : GenericRepo<TaskDetail>, ITaskDetailRepo
    {
        public TaskDetailRepo(InvContext context) : base(context)
        {
        }
    }
}
