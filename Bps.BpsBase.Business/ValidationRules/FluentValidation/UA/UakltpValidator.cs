using FluentValidation;
using Bps.BpsBase.Entities.Concrete.UA;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.UA
{
    public class UakltpValidator : AbstractValidator<UAKLTP>
    {
        #region ClientService

        #endregion ClientService

        public UakltpValidator()
        {
            RuleFor(p => p.KLNKOD).MaximumLength(1);
            RuleFor(p => p.TANIMI).Length(1,50).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
