using FluentValidation;
using Bps.BpsBase.Entities.Concrete.SN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SN
{
    public class SnkrtrValidator : AbstractValidator<SNKRTR>
    {
        #region ClientService

        #endregion ClientService

        public SnkrtrValidator()
        {
            RuleFor(p => p.KRKTNO).Length(1,50).NotNull();
            RuleFor(p => p.KRKTTN).Length(1,100).NotNull();
            RuleFor(p => p.DTTPKD).Length(1,20).NotNull();
            RuleFor(p => p.KRKTSY).NotNull();
            RuleFor(p => p.ONDASY).NotNull();
            RuleFor(p => p.FORMAT).MaximumLength(20);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
