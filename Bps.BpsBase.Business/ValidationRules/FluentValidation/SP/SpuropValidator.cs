using FluentValidation;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SP
{
    public class SpuropValidator : AbstractValidator<SPUROP>
    {
        #region ClientService

        #endregion ClientService

        public SpuropValidator()
        {
            RuleFor(p => p.BELGEN).MaximumLength(20);
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.STKNAM).Length(1,100).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.SATIRN).NotNull();
            RuleFor(p => p.TIPKOD).Length(1,20).NotNull();
            RuleFor(p => p.HARKOD).Length(1,20).NotNull();
            RuleFor(p => p.DVCNKD).MaximumLength(10);
            RuleFor(p => p.GNACIK).MaximumLength(-1);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
