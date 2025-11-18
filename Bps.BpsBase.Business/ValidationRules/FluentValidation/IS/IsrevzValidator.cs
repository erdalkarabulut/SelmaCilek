using FluentValidation;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.IS
{
    public class IsrevzValidator : AbstractValidator<ISREVZ>
    {
        #region ClientService

        #endregion ClientService

        public IsrevzValidator()
        {
            RuleFor(p => p.GNREZV).Length(1,50).NotNull();
            RuleFor(p => p.TANIMI).Length(1,50).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
