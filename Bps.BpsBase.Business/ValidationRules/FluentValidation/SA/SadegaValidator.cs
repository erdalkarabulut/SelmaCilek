using FluentValidation;
using Bps.BpsBase.Entities.Concrete.SA;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SA
{
    public class SadegaValidator : AbstractValidator<SADEGA>
    {
        #region ClientService

        #endregion ClientService

        public SadegaValidator()
        {
            RuleFor(p => p.SADEGK).Length(1,4).NotNull();
            RuleFor(p => p.TESACT).NotNull();
            RuleFor(p => p.TESFZT).NotNull();
            RuleFor(p => p.GNIHT1).NotNull();
            RuleFor(p => p.GNIHT2).NotNull();
            RuleFor(p => p.GNIHT3).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
