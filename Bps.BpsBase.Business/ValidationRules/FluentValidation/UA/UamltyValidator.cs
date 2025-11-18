using FluentValidation;
using Bps.BpsBase.Entities.Concrete.UA;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.UA
{
    public class UamltyValidator : AbstractValidator<UAMLTY>
    {
        #region ClientService

        #endregion ClientService

        public UamltyValidator()
        {
            RuleFor(p => p.UAKLNT).MaximumLength(4);
            RuleFor(p => p.STMLTR).Length(1,50).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
