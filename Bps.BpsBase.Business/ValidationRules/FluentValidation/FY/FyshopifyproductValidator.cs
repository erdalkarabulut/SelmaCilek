using FluentValidation;
using Bps.BpsBase.Entities.Concrete.FY;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.FY
{
    public class FyshopifyproductValidator : AbstractValidator<FYShopifyProduct>
    {
        #region ClientService

        #endregion ClientService

        public FyshopifyproductValidator()
        {
            RuleFor(p => p.Cid).MaximumLength(50);
            RuleFor(p => p.title).MaximumLength(150);
            RuleFor(p => p.vendor).MaximumLength(150);
            RuleFor(p => p.product_type).MaximumLength(150);
            RuleFor(p => p.handle).MaximumLength(150);
            RuleFor(p => p.template_suffix).MaximumLength(150);
            RuleFor(p => p.published_scope).MaximumLength(150);
            RuleFor(p => p.tags).MaximumLength(500);
            RuleFor(p => p.status).MaximumLength(150);
            RuleFor(p => p.admin_graphql_api_id).MaximumLength(150);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
