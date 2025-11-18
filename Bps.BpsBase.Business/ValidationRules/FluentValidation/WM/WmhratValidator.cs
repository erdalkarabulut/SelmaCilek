using FluentValidation;
using Bps.BpsBase.Entities.Concrete.WM;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.WM
{
    public class WmhratValidator : AbstractValidator<WMHRAT>
    {
        #region ClientService

        #endregion ClientService

        public WmhratValidator()
        {
            RuleFor(p => p.STFTNO).NotNull();
            RuleFor(p => p.WMHRKD).Length(1,20).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
