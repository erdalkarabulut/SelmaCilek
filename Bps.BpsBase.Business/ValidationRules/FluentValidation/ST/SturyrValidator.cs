using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class SturyrValidator : AbstractValidator<STURYR>
    {
        #region ClientService

        #endregion ClientService

        public SturyrValidator()
        {
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.URYRKD).Length(1,20).NotNull();
            RuleFor(p => p.ABCGOS).MaximumLength(1);
            RuleFor(p => p.STNGKD).MaximumLength(20);
            RuleFor(p => p.YNSPSV).NotNull();
            RuleFor(p => p.EMNSTK).NotNull();
            RuleFor(p => p.OLCUKD).MaximumLength(20);
            RuleFor(p => p.URDEPO).MaximumLength(4);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
