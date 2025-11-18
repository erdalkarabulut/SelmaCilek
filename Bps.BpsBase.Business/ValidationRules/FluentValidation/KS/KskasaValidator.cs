using FluentValidation;
using Bps.BpsBase.Entities.Concrete.KS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.KS
{
    public class KskasaValidator : AbstractValidator<KSKASA>
    {
        #region ClientService

        #endregion ClientService

        public KskasaValidator()
        {
            RuleFor(p => p.KSTPKD).MaximumLength(20);
            RuleFor(p => p.KSKODU).MaximumLength(25);
            RuleFor(p => p.KSISIM).MaximumLength(40);
            RuleFor(p => p.HSPKOD).MaximumLength(25);
            RuleFor(p => p.KSDVCN).MaximumLength(10);
            RuleFor(p => p.UFRHSP).MaximumLength(25);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
