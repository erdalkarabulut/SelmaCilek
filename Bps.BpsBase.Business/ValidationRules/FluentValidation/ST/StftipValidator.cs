using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StftipValidator : AbstractValidator<STFTIP>
    {
        #region ClientService

        #endregion ClientService

        public StftipValidator()
        {
            RuleFor(p => p.STFTNO).NotNull();
            RuleFor(p => p.STHRTP).NotNull();
            RuleFor(p => p.TANIMI).Length(1,50).NotNull();
            RuleFor(p => p.GNONAY).NotNull();
            RuleFor(p => p.GNACIK).Length(1,200).NotNull();
            RuleFor(p => p.FUNCNM).MaximumLength(50);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
