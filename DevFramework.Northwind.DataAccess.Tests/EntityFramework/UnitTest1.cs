using System;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevFramework.Northwind.DataAccess.Tests.EntityFramework
{
    [TestClass]
    public class EntityFrameworkTests
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            EfProductDal productDal= new EfProductDal();
            var result = productDal.GetAll();
            Assert.AreEqual(81,result.Count);
        }
        public void Get_all_with_parameter_returns_filtered_products()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetAll(p=>p.ProductName.Contains("ab"));
            Assert.AreEqual(4, result.Count);
        }
    }
}
