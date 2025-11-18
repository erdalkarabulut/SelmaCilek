using FluentValidation;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SP
{
    public class SpdkdrValidator : AbstractValidator<SPDKDR>
    {
        #region ClientService

        #endregion ClientService

        public SpdkdrValidator()
        {
            RuleFor(p => p.DURKOD).MaximumLength(20);
            RuleFor(p => p.TANIMI).Length(1,50).NotNull();
            RuleFor(p => p.SPBLKJ).NotNull();
            RuleFor(p => p.TSBLKJ).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
