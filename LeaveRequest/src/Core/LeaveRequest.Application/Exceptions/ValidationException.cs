

using FluentValidation.Results;

namespace LeaveRequest.Application.Exceptions
{
    public class ValidationException:Exception
    {
        public List<string> validatorErrors { get; set; } = default!;
        public ValidationException(ValidationResult validationResult)
        {
            validatorErrors = new List<string>();
            foreach( var errorResult in validationResult.Errors)
            {
                validatorErrors.Add(errorResult.ErrorMessage);
            }
        }
    }
}
