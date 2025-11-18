using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StoptmValidator : AbstractValidator<STOPTM>
    {
        #region ClientService

        #endregion ClientService

        public StoptmValidator()
        {
            RuleFor(p => p.STKODU).MaximumLength(25);
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.STKNAM).MaximumLength(100);
            RuleFor(p => p.BELGEN).MaximumLength(20);
            RuleFor(p => p.MCBELG).MaximumLength(20);
            RuleFor(p => p.MGBELG).MaximumLength(20);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
