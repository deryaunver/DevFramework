using System;
using System.Linq;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspects.Postsharp.ValidationAspect
{
    [Serializable]
   public class FluentValidationAspect:OnMethodBoundaryAspect
   {
      Type _validatorType;

      public FluentValidationAspect(Type validatorType)
      {
          _validatorType = validatorType;
      }

      public override void OnEntry(MethodExecutionArgs args)
      {
          //IValidator validator = (IValidator)Activator.CreateInstance(_validatorType);
          var validator = (IValidator)Activator.CreateInstance(_validatorType);
          var entityType = _validatorType.BaseType.GetGenericArguments()[0];
          var entities = args.Arguments.Where(t => t.GetType() == entityType);
          foreach (var entity in entities)
          {
               // ValidatorTool.FluentValidate((IValidator<object>)validator,entity); 
                ValidatorTool.FluentValidate((IValidator<object>)validator,entity); 
                //ValidatorTool.FluentValidate(validator,entity); 
          }

      }
    }
}
