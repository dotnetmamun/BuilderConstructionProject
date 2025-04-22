using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Infrastructure.Repositories
{
    public interface IUnitRepo : IGenericRepo<Unit>
    {

    }
    public class UnitRepo : GenericRepo<Unit>, IUnitRepo
    {
        public UnitRepo(InvContext context) : base(context)
        {
        }
    }
}
