using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GntipiValidator : AbstractValidator<GNTIPI>
    {
        #region ClientService

        #endregion ClientService

        public GntipiValidator()
        {
            RuleFor(p => p.TIPKOD).Length(1,20).NotNull();
            RuleFor(p => p.TIPADI).Length(1,50).NotNull();
            RuleFor(p => p.TEKNAD).Length(1,6).NotNull();
            RuleFor(p => p.UTPKOD).MaximumLength(20);
            RuleFor(p => p.HRKTBL).Length(1,6).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
