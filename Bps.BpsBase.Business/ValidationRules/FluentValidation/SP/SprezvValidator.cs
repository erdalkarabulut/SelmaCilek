using FluentValidation;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SP
{
    public class SprezvValidator : AbstractValidator<SPREZV>
    {
        #region ClientService

        #endregion ClientService

        public SprezvValidator()
        {
            RuleFor(p => p.BELGEN).MaximumLength(20);
            RuleFor(p => p.SPBLNO).MaximumLength(20);
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.STKNAM).Length(1,100).NotNull();
            RuleFor(p => p.OLCUKD).Length(1,20).NotNull();
            RuleFor(p => p.CKDEPO).MaximumLength(4);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
