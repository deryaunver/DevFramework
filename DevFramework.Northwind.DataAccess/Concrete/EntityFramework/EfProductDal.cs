﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess.EntityFramewrok;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework
{
   public class EfProductDal:EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
    {
        public List<ProductDetail> GetProductDetails()
        {
            using (NorthwindContext context= new NorthwindContext())
            {
                var result = from p in context.Products
                    join c in context.Categories on p.CategoryID equals c.CategoryId
                    select new ProductDetail
                    {
                        ProductId = p.ProductID,
                        ProductName = p.ProductName,
                        CategoryName = c.CategoryName
                    };
                return result.ToList();
            }
            
        }
    }
}
