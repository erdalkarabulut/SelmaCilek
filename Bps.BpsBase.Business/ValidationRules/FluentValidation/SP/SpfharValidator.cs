using FluentValidation;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SP
{
    public class SpfharValidator : AbstractValidator<SPFHAR>
    {
        #region ClientService

        #endregion ClientService

        public SpfharValidator()
        {
            RuleFor(p => p.SPORKD).MaximumLength(20);
            RuleFor(p => p.SPDGKD).MaximumLength(20);
            RuleFor(p => p.EVRAKN).MaximumLength(50);
            RuleFor(p => p.BELGEN).MaximumLength(20);
            RuleFor(p => p.CRHRKD).MaximumLength(20);
            RuleFor(p => p.CRKODU).MaximumLength(25);
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.STKNAM).Length(1,100).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.STFYNO).NotNull();
            RuleFor(p => p.GRDEPO).MaximumLength(4);
            RuleFor(p => p.CKDEPO).MaximumLength(4);
            RuleFor(p => p.AGOLKD).MaximumLength(20);
            RuleFor(p => p.PARTIN).MaximumLength(50);
            RuleFor(p => p.ISM1KD).MaximumLength(20);
            RuleFor(p => p.ISM2KD).MaximumLength(20);
            RuleFor(p => p.ISM3KD).MaximumLength(20);
            RuleFor(p => p.DVCNKD).MaximumLength(10);
            RuleFor(p => p.STDVCN).MaximumLength(20);
            RuleFor(p => p.OLCUKD).Length(1,20).NotNull();
            RuleFor(p => p.GROLBR).MaximumLength(20);
            RuleFor(p => p.TSEVRK).MaximumLength(50);
            RuleFor(p => p.GNACIK).MaximumLength(200);
            RuleFor(p => p.SADEGK).MaximumLength(4);
            RuleFor(p => p.ISPKOD).MaximumLength(20);
            RuleFor(p => p.ORDRID).MaximumLength(50);
            RuleFor(p => p.LINEID).MaximumLength(50);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
