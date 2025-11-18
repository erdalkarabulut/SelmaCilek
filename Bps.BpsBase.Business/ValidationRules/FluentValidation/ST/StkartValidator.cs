using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StkartValidator : AbstractValidator<STKART>
    {
        #region ClientService

        #endregion ClientService

        public StkartValidator()
        {
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.STKNAM).Length(1,100).NotNull();
            RuleFor(p => p.STANKD).Length(1,20).NotNull();
            RuleFor(p => p.STALKD).MaximumLength(20);
            RuleFor(p => p.STG1KD).MaximumLength(20);
            RuleFor(p => p.STG2KD).MaximumLength(20);
            RuleFor(p => p.STG3KD).MaximumLength(20);
            RuleFor(p => p.STMLTR).Length(1,50).NotNull();
            RuleFor(p => p.STEKOD).MaximumLength(50);
            RuleFor(p => p.OLCUKD).Length(1,20).NotNull();
            RuleFor(p => p.SADEGK).MaximumLength(4);
            RuleFor(p => p.SAOLKD).Length(1,20).NotNull();
            RuleFor(p => p.MALGKD).MaximumLength(20);
            RuleFor(p => p.AGOLKD).MaximumLength(20);
            RuleFor(p => p.HCOLKD).MaximumLength(20);
            RuleFor(p => p.EANTKD).MaximumLength(20);
            RuleFor(p => p.EANKOD).MaximumLength(40);
            RuleFor(p => p.UGYBKD).MaximumLength(20);
            RuleFor(p => p.GTIPNO).MaximumLength(30);
            RuleFor(p => p.UROPTB).MaximumLength(20);
            RuleFor(p => p.STKIMG).MaximumLength(255);
            RuleFor(p => p.STYKOD).MaximumLength(50);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
