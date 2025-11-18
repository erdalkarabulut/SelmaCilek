using FluentValidation;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SP
{
    public class SphrplValidator : AbstractValidator<SPHRPL>
    {
        #region ClientService

        #endregion ClientService

        public SphrplValidator()
        {
            RuleFor(p => p.BELGEN).Length(1,20).NotNull();
            RuleFor(p => p.GNREZV).Length(1,50).NotNull();
            RuleFor(p => p.URAKOD).Length(1,50).NotNull();
            RuleFor(p => p.SATIRN).NotNull();
            RuleFor(p => p.PKKODU).Length(1,25).NotNull();
            RuleFor(p => p.PKTNAM).Length(1,100).NotNull();
            RuleFor(p => p.PLNMKT).NotNull();
            RuleFor(p => p.ACIKLM).MaximumLength(255);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
