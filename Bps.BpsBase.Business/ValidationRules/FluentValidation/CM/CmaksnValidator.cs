using FluentValidation;
using Bps.BpsBase.Entities.Concrete.CM;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.CM
{
    public class CmaksnValidator : AbstractValidator<CMAKSN>
    {
        #region ClientService

        #endregion ClientService

        public CmaksnValidator()
        {
            RuleFor(p => p.AKSNNO).NotNull();
            RuleFor(p => p.BELGEN).Length(1,20).NotNull();
            RuleFor(p => p.BELTRH).NotNull();
            RuleFor(p => p.CRKODU).Length(1,25).NotNull();
            RuleFor(p => p.GNACIK).MaximumLength(200);
            RuleFor(p => p.CMDRKD).Length(1,20).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
