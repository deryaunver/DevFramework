using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidatorTool
    {
        //IValidator: buraya productValidator gelebilri,categoryValidator Gelebilir .
        //Bunların herbirinin aslında Base i :IValidator dür.
        //T entity:tüm nesnelerin basei , product,category...
        public static void FluentValidate<T>(IValidator<T> validator, T entity)
        {

            var result = validator.Validate(entity);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    

        //public static void FluentValidate(IValidator validator, object entity)
        //{

        //    var result = validator.Validate((IValidationContext) entity);
        //    if (result.Errors.Count > 0)
        //    {
        //        throw new ValidationException(result.Errors);
        //    }
        //}


    }
}
