using FluentValidation;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SP
{
    public class SpftipValidator : AbstractValidator<SPFTIP>
    {
        #region ClientService

        #endregion ClientService

        public SpftipValidator()
        {
            RuleFor(p => p.SPFTNO).NotNull();
            RuleFor(p => p.TANIMI).Length(1,50).NotNull();
            RuleFor(p => p.SPHRTP).NotNull();
            RuleFor(p => p.SPORKD).MaximumLength(20);
            RuleFor(p => p.SPDGKD).MaximumLength(20);
            RuleFor(p => p.GNONAY).NotNull();
            RuleFor(p => p.GNACIK).Length(1,200).NotNull();
            RuleFor(p => p.FUNCNM).MaximumLength(50);
            RuleFor(p => p.DIZAYN).MaximumLength(200);
            RuleFor(p => p.TSFTNO).NotNull();
            RuleFor(p => p.FTFTNO).NotNull();
            RuleFor(p => p.ORGTKD).MaximumLength(20);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
