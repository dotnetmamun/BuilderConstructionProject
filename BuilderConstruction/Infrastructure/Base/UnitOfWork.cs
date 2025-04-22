using BuilderConstruction.Infrastructure.Repositories;
using BuilderConstruction.Models;
using BuilderConstruction.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Infrastructure.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        InvContext _context;
        public UnitOfWork(InvContext context)
        {
            this._context = context;

        }
        #region properties
        public ICompanyRepo? companyRepo;
        public IBuildingTaskRepo? buildingTaskRepo;
        public IEmployeeRepo? employeeRepo;
        public IProjectTaskRepo? projectTaskRepo;
        public IUnitRepo? unitRepo;
        public IMaterialRepo? materialRepo;
        public IPictureRepo? pictureRepo;
        public IProjectCostRepo? projectCostRepo;
        public IProjectCostDetailRepo? projectCostDetailRepo;
        public ITaskStepRepo? taskStepRepo;
        public ITaskDetailRepo? taskDetailRepo;
        public IProjectRepo? projectRepo;


        //public ICompanyRepo CompanyRepo
        //{
        //    get
        //    {
        //        if (companyRepo == null)
        //        {
        //            companyRepo = new CopmanyRepo(_context);
        //        }
        //        return companyRepo;
        //    }
        //}

        public ICompanyRepo? CopmanyRepo
        {
            get
            {
                if (companyRepo == null)
                {
                    companyRepo = new CopmanyRepo(_context);
                }
                return companyRepo;
            }
        }

        public IBuildingTaskRepo? BuildingTaskRepo
        {
            get
            {
                if (buildingTaskRepo == null)
                {
                    buildingTaskRepo = new BuildingTaskRepo(_context);
                }
                return buildingTaskRepo;
            }
        }
        /***/
        public IEmployeeRepo? EmployeeRepo
        {
            get
            {
                if (employeeRepo == null)
                {
                    employeeRepo = new EmployeeRepo(_context);
                }
                return employeeRepo;
            }
        }

        public IProjectTaskRepo? ProjectTaskRepo
        {
            get
            {
                if (projectTaskRepo == null)
                {
                    projectTaskRepo = new ProjectTaskRepo(_context);
                }
                return projectTaskRepo;
            }
        }

        public IUnitRepo? UnitRepo
        {
            get
            {
                if (unitRepo == null)
                {
                    unitRepo = new UnitRepo(_context);
                }
                return unitRepo;
            }
        }

        public IMaterialRepo? MaterialRepo
        {
            get
            {
                if (materialRepo == null)
                {
                    materialRepo = new MaterialRepo(_context);
                }
                return materialRepo;
            }
        }

        public IPictureRepo? PictureRepo
        {
            get
            {
                if (pictureRepo == null)
                {
                    pictureRepo = new PictureRepo(_context);
                }
                return pictureRepo;
            }
        }

        public IProjectCostRepo? ProjectCostRepo
        {
            get
            {
                if (projectCostRepo == null)
                {
                    projectCostRepo = new ProjectCostRepo(_context);
                }
                return projectCostRepo;
            }
        }

        public IProjectCostDetailRepo? ProjectCostDetailRepo
        {
            get
            {
                if (projectCostDetailRepo == null)
                {
                    projectCostDetailRepo = new ProjectCostDetailRepo(_context);
                }
                return projectCostDetailRepo;
            }
        }

        public ITaskStepRepo? TaskStepRepo
        {
            get
            {
                if (taskStepRepo == null)
                {
                    taskStepRepo = new TaskStepRepo(_context);
                }
                return taskStepRepo;
            }
        }
        public ITaskDetailRepo? TaskDetailRepo
        {
            get
            {
                if (taskDetailRepo == null)
                {
                    taskDetailRepo = new TaskDetailRepo(_context);
                }
                return taskDetailRepo;
            }
        }

        public IProjectRepo? ProjectRepo {
            get
            {
                if (projectRepo == null)
                {
                    projectRepo = new ProjectRepo(_context);
                }
                return projectRepo;
            }
        }




        //public ICompanyRepo? CopmanyRepo
        //{
        //    get
        //    {
        //        if (companyRepo == null)
        //        {
        //            companyRepo = new CopmanyRepo(_context);
        //        }
        //        return companyRepo;
        //    }
        //}
        #endregion
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public Modelmessage Save()
        {
            Modelmessage modelMessage = new Modelmessage();
            try
            {
                if (_context.SaveChanges() > 0)
                {
                    modelMessage.Message = $"Operation Successfull ";
                    modelMessage.IsSuccess = true;
                }
                else
                {
                    modelMessage.Message = $"Operation failled  ";
                    modelMessage.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    modelMessage.Message = ex.InnerException.Message;
                    modelMessage.IsSuccess = false;
                }
                else
                {
                    modelMessage.Message = ex.Message;
                    modelMessage.IsSuccess = false;
                }
            }
            return modelMessage;
        }
    }
}
