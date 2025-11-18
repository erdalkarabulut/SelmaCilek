using FluentValidation;
using Bps.BpsBase.Entities.Concrete.CR;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.CR
{
    public class CrcariValidator : AbstractValidator<CRCARI>
    {
        #region ClientService

        #endregion ClientService

        public CrcariValidator()
        {
            RuleFor(p => p.CRHRKD).Length(1,20).NotNull();
            RuleFor(p => p.CRKODU).Length(1,25).NotNull();
            RuleFor(p => p.ADCRKD).MaximumLength(25);
            RuleFor(p => p.ASCRKD).MaximumLength(25);
            RuleFor(p => p.CRUNV1).Length(1,256).NotNull();
            RuleFor(p => p.CRUNV2).MaximumLength(256);
            RuleFor(p => p.CRBGKD).MaximumLength(20);
            RuleFor(p => p.CRHSP1).MaximumLength(25);
            RuleFor(p => p.CRHSP2).MaximumLength(25);
            RuleFor(p => p.CRHSP3).MaximumLength(25);
            RuleFor(p => p.CRDVCN).MaximumLength(10);
            RuleFor(p => p.CRDVC1).MaximumLength(10);
            RuleFor(p => p.CRDVC2).MaximumLength(10);
            RuleFor(p => p.VERGDA).Length(1,50).NotNull();
            RuleFor(p => p.VERGNO).Length(1,15).NotNull();
            RuleFor(p => p.TSICNO).MaximumLength(50);
            RuleFor(p => p.VERKML).MaximumLength(15);
            RuleFor(p => p.CRAKOD).MaximumLength(25);
            RuleFor(p => p.CRSKOD).MaximumLength(25);
            RuleFor(p => p.GNMAIL).MaximumLength(100);
            RuleFor(p => p.GNWEBA).MaximumLength(100);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
