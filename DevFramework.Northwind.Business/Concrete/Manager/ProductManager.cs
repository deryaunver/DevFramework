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
  public  class ProductManager:IProductService
  {
      private IProductDal _productDal;

      public ProductManager(IProductDal productDal)
      {
          _productDal = productDal;
      }

      public List<Product> GetAll()
      {
          return _productDal.GetAll();
      }

        public Product Get(int id)
        {
            return _productDal.Get(P => P.ProductID == id);
        }

        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }
    }
}
