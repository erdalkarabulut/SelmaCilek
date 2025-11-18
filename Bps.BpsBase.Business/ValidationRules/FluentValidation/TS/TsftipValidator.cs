using FluentValidation;
using Bps.BpsBase.Entities.Concrete.TS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.TS
{
    public class TsftipValidator : AbstractValidator<TSFTIP>
    {
        #region ClientService

        #endregion ClientService

        public TsftipValidator()
        {
            RuleFor(p => p.TSFTNO).NotNull();
            RuleFor(p => p.TANIMI).Length(1,50).NotNull();
            RuleFor(p => p.TSHRTP).NotNull();
            RuleFor(p => p.SPORKD).MaximumLength(20);
            RuleFor(p => p.SPDGKD).MaximumLength(20);
            RuleFor(p => p.GNONAY).NotNull();
            RuleFor(p => p.GNACIK).Length(1,200).NotNull();
            RuleFor(p => p.FUNCNM).MaximumLength(50);
            RuleFor(p => p.DIZAYN).MaximumLength(200);
            RuleFor(p => p.FTFTNO).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
