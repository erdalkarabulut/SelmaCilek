using FluentValidation;
using Bps.BpsBase.Entities.Concrete.FY;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.FY
{
    public class FyshopifyvariantValidator : AbstractValidator<FYShopifyVariant>
    {
        #region ClientService

        #endregion ClientService

        public FyshopifyvariantValidator()
        {
            RuleFor(p => p.Cid).MaximumLength(50);
            RuleFor(p => p.product_id).MaximumLength(50);
            RuleFor(p => p.title).MaximumLength(150);
            RuleFor(p => p.inventory_policy).MaximumLength(150);
            RuleFor(p => p.option1).MaximumLength(150);
            RuleFor(p => p.option2).MaximumLength(150);
            RuleFor(p => p.option3).MaximumLength(150);
            RuleFor(p => p.barcode).MaximumLength(150);
            RuleFor(p => p.fulfillment_service).MaximumLength(150);
            RuleFor(p => p.inventory_management).MaximumLength(150);
            RuleFor(p => p.sku).MaximumLength(150);
            RuleFor(p => p.weight_unit).MaximumLength(50);
            RuleFor(p => p.inventory_item_id).MaximumLength(50);
            RuleFor(p => p.admin_graphql_api_id).MaximumLength(150);
            RuleFor(p => p.image_id).MaximumLength(50);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
