using System.Collections.Generic;
using Bps.Core.Response;
using FluentValidation;

namespace Bps.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidatorTool
    {
        public static ListResponse<string> FluentValidate(IValidator validator, object entity)
        {
            var validationResult = new ListResponse<string>
            {
                Items = new List<string>(),
                Status = ResponseStatusEnum.OK
            };
            var result = validator.Validate(entity);

            if (result.Errors.Count > 0)
            {
                foreach (var error in result.Errors)
                {
                    validationResult.Items.Add(error.ErrorMessage);
                }
                validationResult.Status = ResponseStatusEnum.ERROR;
            }

            return validationResult;
        }
    }
}