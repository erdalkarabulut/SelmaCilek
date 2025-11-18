using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StvmizValidator : AbstractValidator<STVMIZ>
    {
        #region ClientService

        #endregion ClientService

        public StvmizValidator()
        {
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.MALHSP).NotNull();
            RuleFor(p => p.MALIYL).NotNull();
            RuleFor(p => p.MALIAY).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
