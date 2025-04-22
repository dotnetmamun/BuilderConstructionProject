using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Infrastructure.Repositories
{
    public interface IPictureRepo : IGenericRepo<Picture>
    {

    }
    public class PictureRepo : GenericRepo<Picture>, IPictureRepo
    {
        public PictureRepo(InvContext context) : base(context)
        {
        }
    }
}
