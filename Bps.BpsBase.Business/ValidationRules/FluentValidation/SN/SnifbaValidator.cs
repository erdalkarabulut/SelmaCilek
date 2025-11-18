using FluentValidation;
using Bps.BpsBase.Entities.Concrete.SN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SN
{
    public class SnifbaValidator : AbstractValidator<SNIFBA>
    {
        #region ClientService

        #endregion ClientService

        public SnifbaValidator()
        {
            RuleFor(p => p.SNTRKD).Length(1,20).NotNull();
            RuleFor(p => p.SINFKD).Length(1,20).NotNull();
            RuleFor(p => p.SNFKOD).Length(1,50).NotNull();
            RuleFor(p => p.SNFTAN).MaximumLength(50);
            RuleFor(p => p.GECBAS).NotNull();
            RuleFor(p => p.GECBIT).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
