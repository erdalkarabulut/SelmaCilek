using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GnklopValidator : AbstractValidator<GNKLOP>
    {
        #region ClientService

        #endregion ClientService

        public GnklopValidator()
        {
            RuleFor(p => p.PERSID).NotNull();
            RuleFor(p => p.ISOPKD).Length(1,20).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
