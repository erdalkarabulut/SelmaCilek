using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StkfiyValidator : AbstractValidator<STKFIY>
    {
        #region ClientService

        #endregion ClientService

        public StkfiyValidator()
        {
            RuleFor(p => p.STFYNO).NotNull();
            RuleFor(p => p.STHRTP).NotNull();
            RuleFor(p => p.TANIMI).Length(1,50).NotNull();
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.GFIYAT).NotNull();
            RuleFor(p => p.DVCNKD).Length(1,20).NotNull();
            RuleFor(p => p.SPORKD).MaximumLength(20);
            RuleFor(p => p.SPDGKD).MaximumLength(20);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
