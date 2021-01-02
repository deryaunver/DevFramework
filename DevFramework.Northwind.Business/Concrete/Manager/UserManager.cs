using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.Business.Concrete.Manager
{
   public class UserManager:IUserService
   {
       private IUserDal _userDal;

       public UserManager(IUserDal userDal)
       {
           _userDal = userDal;
       }

       public User GetByUserNameAndPassword(string username, string password)
       {
           return _userDal.Get(u => u.UserName == username & u.Password == password);
       }
    }
}
