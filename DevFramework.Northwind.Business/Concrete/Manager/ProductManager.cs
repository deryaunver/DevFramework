using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.Aspects.Postsharp.TransactionAspect;
using DevFramework.Core.Aspects.Postsharp.ValidationAspect;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.Business.Concrete.Manager
{
    public class ProductManager : IProductService 
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product Get(int id)
        {
            return _productDal.Get(P => P.ProductID == id);
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            //ValidatorTool.Validate(new ProductValidator(), product);
            return _productDal.Add(product);
        }
        //Bu aspecti nasıl bir validator ile validate etmesini istiyorum.
        //Yani:ProductValidator Product ı valide ediyor.
        //bende dicemki ProdactValidator'a parametre olarak senin validate etmen gereken(product)
        //bulduğun zaman onu benim yerime validete et...
        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            //ValidatorTool.Validate(new ProductValidator(), product);
            return _productDal.Update(product);
        }
        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            #region Yöntem1
            //using (TransactionScope scope= new TransactionScope())
            //{
            //    try
            //    {
            //        _productDal.Add(product1);
            //        //business code
            //        _productDal.Update(product2);
            //        scope.Complete();

            //    }
            //    catch 
            //    {
            //        scope.Dispose();
            //    }
            //} 
            #endregion
            _productDal.Add(product1);
            //business code
            _productDal.Update(product2);

        }
    }
}
