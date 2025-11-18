using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GnorgaValidator : AbstractValidator<GNORGA>
    {
        #region ClientService

        #endregion ClientService

        public GnorgaValidator()
        {
            RuleFor(p => p.ORGTKD).MaximumLength(20);
            RuleFor(p => p.TANIMI).MaximumLength(50);
            RuleFor(p => p.KULKOD).Length(1,20).NotNull();
            RuleFor(p => p.GNNAME).MaximumLength(50);
            RuleFor(p => p.GNSNAM).MaximumLength(50);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
