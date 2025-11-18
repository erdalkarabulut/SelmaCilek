using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StaltgValidator : AbstractValidator<STALTG>
    {
        #region ClientService

        #endregion ClientService

        public StaltgValidator()
        {
            RuleFor(p => p.STANAK).Length(1,25);
            RuleFor(p => p.STALTK).Length(1,25);
            RuleFor(p => p.STALTN).Length(1,40);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
