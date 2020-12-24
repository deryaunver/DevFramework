using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.Concrete;
using FluentNHibernate.Mapping;

namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate.Mappings
{
    public class ProductMap:ClassMap<Product>
    {
        public ProductMap()
        {
            Table(@"Products");
            LazyLoad();
            Id(x => x.ProductID).Column("ProductID");
            Map(x => x.CategoryID).Column("CategoryID");
            Map(x => x.ProductName).Column("ProductName");
            Map(x => x.UnitPrice).Column("UnitPrice");
            Map(x => x.UnitsInStock).Column("UnitsInStock");
            Map(x => x.QuantityPerUnit).Column("QuantityPerUnit");
        }
    }
}
