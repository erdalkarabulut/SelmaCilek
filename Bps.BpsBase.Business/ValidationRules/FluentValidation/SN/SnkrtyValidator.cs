using FluentValidation;
using Bps.BpsBase.Entities.Concrete.SN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SN
{
    public class SnkrtyValidator : AbstractValidator<SNKRTY>
    {
        #region ClientService

        #endregion ClientService

        public SnkrtyValidator()
        {
            RuleFor(p => p.OBJKEY).MaximumLength(50);
            RuleFor(p => p.SNFKOD).Length(1,50).NotNull();
            RuleFor(p => p.KRKTNO).Length(1,50).NotNull();
            RuleFor(p => p.GVALUE).Length(1,-1).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
