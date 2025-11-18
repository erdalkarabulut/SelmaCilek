using FluentValidation;
using Bps.BpsBase.Entities.Concrete.UA;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.UA
{
    public class UakltnValidator : AbstractValidator<UAKLTN>
    {
        #region ClientService

        #endregion ClientService

        public UakltnValidator()
        {
            RuleFor(p => p.KLMTIP).MaximumLength(1);
            RuleFor(p => p.TANIMI).Length(1,50).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
