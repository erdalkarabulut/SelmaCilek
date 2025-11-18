using FluentValidation;
using Bps.BpsBase.Entities.Concrete;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation
{
    public class DovkurValidator : AbstractValidator<DOVKUR>
    {
        #region ClientService

        #endregion ClientService

        public DovkurValidator()
        {
            RuleFor(p => p.DVCNKD).Length(1,20).NotNull();
            RuleFor(p => p.DOVTRH).NotNull();
            RuleFor(p => p.DVFYT1).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
