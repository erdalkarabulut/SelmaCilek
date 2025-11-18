using FluentValidation;
using Bps.BpsBase.Entities.Concrete.CR;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.CR
{
    public class CradrsValidator : AbstractValidator<CRADRS>
    {
        #region ClientService

        #endregion ClientService

        public CradrsValidator()
        {
            RuleFor(p => p.CRKODU).Length(1,25).NotNull();
            RuleFor(p => p.TANIMI).Length(1,50).NotNull();
            RuleFor(p => p.ADRESS).Length(1,500).NotNull();
            RuleFor(p => p.MAHAKD).MaximumLength(20);
            RuleFor(p => p.SEMTKD).MaximumLength(20);
            RuleFor(p => p.ILCEKD).MaximumLength(20);
            RuleFor(p => p.SEHRKD).MaximumLength(20);
            RuleFor(p => p.ULKEKD).Length(1,20).NotNull();
            RuleFor(p => p.ISYTEL).MaximumLength(15);
            RuleFor(p => p.CEPTEL).MaximumLength(15);
            RuleFor(p => p.ISYFAX).MaximumLength(15);
            RuleFor(p => p.GNONOT).MaximumLength(50);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
