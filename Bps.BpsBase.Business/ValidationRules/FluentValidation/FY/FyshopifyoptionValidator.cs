using FluentValidation;
using Bps.BpsBase.Entities.Concrete.FY;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.FY
{
    public class FyshopifyoptionValidator : AbstractValidator<FYShopifyOption>
    {
        #region ClientService

        #endregion ClientService

        public FyshopifyoptionValidator()
        {
            RuleFor(p => p.Cid).MaximumLength(50);
            RuleFor(p => p.product_id).MaximumLength(50);
            RuleFor(p => p.name).MaximumLength(50);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
