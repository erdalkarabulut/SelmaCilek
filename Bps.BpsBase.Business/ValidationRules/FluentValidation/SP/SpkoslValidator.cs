using FluentValidation;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SP
{
    public class SpkoslValidator : AbstractValidator<SPKOSL>
    {
        #region ClientService

        #endregion ClientService

        public SpkoslValidator()
        {
            RuleFor(p => p.BELGEN).MaximumLength(20);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
