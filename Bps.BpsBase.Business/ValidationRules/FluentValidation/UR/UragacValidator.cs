using FluentValidation;
using Bps.BpsBase.Entities.Concrete.UR;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.UR
{
    public class UragacValidator : AbstractValidator<URAGAC>
    {
        #region ClientService

        #endregion ClientService

        public UragacValidator()
        {
            RuleFor(p => p.PARENT).NotNull();
            RuleFor(p => p.GNREZV).Length(1,50).NotNull();
            RuleFor(p => p.URAKOD).MaximumLength(50);
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.URYRKD).Length(1,20).NotNull();
            RuleFor(p => p.URKLTP).MaximumLength(1);
            RuleFor(p => p.SIRALM).MaximumLength(50);
            RuleFor(p => p.OLCUKD).Length(1,20).NotNull();
            RuleFor(p => p.STMLTR).Length(1,50).NotNull();
            RuleFor(p => p.AURKOD).MaximumLength(50);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
