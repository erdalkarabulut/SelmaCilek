using FluentValidation;
using Bps.BpsBase.Entities.Concrete.SN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SN
{
    public class SntynnValidator : AbstractValidator<SNTYNN>
    {
        #region ClientService

        #endregion ClientService

        public SntynnValidator()
        {
            RuleFor(p => p.OBJKEY).MaximumLength(50);
            RuleFor(p => p.SNFKOD).Length(1,50).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
