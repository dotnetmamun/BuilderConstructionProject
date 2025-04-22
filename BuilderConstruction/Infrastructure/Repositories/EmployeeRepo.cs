using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Infrastructure.Repositories
{
    public interface IEmployeeRepo : IGenericRepo<Employee>
    {

    }
    public class EmployeeRepo : GenericRepo<Employee>, IEmployeeRepo
    {
        public EmployeeRepo(InvContext context) : base(context)
        {
        }
    }
}
