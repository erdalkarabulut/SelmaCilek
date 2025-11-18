using FluentValidation;
using Bps.BpsBase.Entities.Concrete;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation
{
    public class LockedValidator : AbstractValidator<LOCKED>
    {
        #region ClientService

        #endregion ClientService

        public LockedValidator()
        {
            RuleFor(p => p.TABLNM).MaximumLength(6);
            RuleFor(p => p.KULKOD).Length(1,20).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
