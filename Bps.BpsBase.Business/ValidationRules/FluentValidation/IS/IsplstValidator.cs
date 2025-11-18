using FluentValidation;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.IS
{
    public class IsplstValidator : AbstractValidator<ISPLST>
    {
        #region ClientService

        #endregion ClientService

        public IsplstValidator()
        {
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.URYRKD).Length(1,20).NotNull();
            RuleFor(p => p.ISPKOD).MaximumLength(20);
            RuleFor(p => p.GNREZV).NotNull();
            RuleFor(p => p.URRVNO).MaximumLength(10);
            RuleFor(p => p.URAKOD).MaximumLength(10);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
