using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess.EntityFramewrok;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.DataAccess.Concrete
{
   public class EfUserDal:EfEntityRepositoryBase<User,NorthwindContext>,IUserDal
    {
    }
}
