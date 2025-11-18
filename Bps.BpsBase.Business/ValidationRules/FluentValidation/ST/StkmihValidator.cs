using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StkmihValidator : AbstractValidator<STKMIH>
    {
        #region ClientService

        #endregion ClientService

        public StkmihValidator()
        {
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.MALHSP).NotNull();
            RuleFor(p => p.MALIYL).NotNull();
            RuleFor(p => p.MALIAY).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
