using FluentValidation;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.IS
{
    public class IsyropValidator : AbstractValidator<ISYROP>
    {
        #region ClientService

        #endregion ClientService

        public IsyropValidator()
        {
            RuleFor(p => p.ISYRID).NotNull();
            RuleFor(p => p.ISOPKD).Length(1,20).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
