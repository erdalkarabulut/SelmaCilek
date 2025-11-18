using FluentValidation;
using Bps.BpsBase.Entities.Concrete.SN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SN
{
    public class SnsnkrValidator : AbstractValidator<SNSNKR>
    {
        #region ClientService

        #endregion ClientService

        public SnsnkrValidator()
        {
            RuleFor(p => p.SNFKOD).Length(1,50).NotNull();
            RuleFor(p => p.KRKTNO).Length(1,50).NotNull();
            RuleFor(p => p.SATIRN).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
