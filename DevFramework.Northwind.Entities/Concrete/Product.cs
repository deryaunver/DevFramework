using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace DevFramework.Northwind.Entities.Concrete
{
   public class Product:IEntity
    {
        public virtual int ProductID { get; set; }
        public virtual int CategoryID { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string QuantityPerUnit { get; set; }

        public virtual decimal UnitPrice { get; set; }
        public virtual Int16 UnitsInStock { get; set; }
    }
}
