using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GnyetbValidator : AbstractValidator<GNYETB>
    {
        #region ClientService

        #endregion ClientService

        public GnyetbValidator()
        {
            RuleFor(p => p.YetkId).NotNull();
            RuleFor(p => p.MNUNAM).Length(1,50).NotNull();
            RuleFor(p => p.MNUTAG).NotNull();
            RuleFor(p => p.MENUKD).Length(1,20).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
