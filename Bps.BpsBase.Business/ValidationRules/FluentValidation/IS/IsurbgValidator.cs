using FluentValidation;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.IS
{
    public class IsurbgValidator : AbstractValidator<ISURBG>
    {
        #region ClientService

        #endregion ClientService

        public IsurbgValidator()
        {
            RuleFor(p => p.ISPKOD).MaximumLength(20);
            RuleFor(p => p.SIRASI).NotNull();
            RuleFor(p => p.GNREZV).NotNull();
            RuleFor(p => p.URRVNO).MaximumLength(10);
            RuleFor(p => p.URAKOD).MaximumLength(10);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
