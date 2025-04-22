using BuilderConstruction.Infrastructure.Repositories;
using BuilderConstruction.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Infrastructure.Base
{
    public interface IUnitOfWork : IDisposable
    {

        Modelmessage Save();
        #region properties
        //public ICateRepo? CateRepo { get; }
        public ICompanyRepo? CopmanyRepo { get; }
        public IBuildingTaskRepo? BuildingTaskRepo { get; }
        public IEmployeeRepo? EmployeeRepo { get; }
        public IProjectTaskRepo? ProjectTaskRepo { get; }
        public IUnitRepo? UnitRepo { get; }
        public IMaterialRepo? MaterialRepo { get; }
        public IPictureRepo? PictureRepo { get; }
        public IProjectCostRepo? ProjectCostRepo { get; }
        public IProjectCostDetailRepo? ProjectCostDetailRepo { get; }
        public ITaskStepRepo? TaskStepRepo { get; }
        public ITaskDetailRepo? TaskDetailRepo { get; }
        public IProjectRepo? ProjectRepo { get; }


        #endregion
    }
}
