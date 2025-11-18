using FluentValidation;
using Bps.BpsBase.Entities.Concrete.FY;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.FY
{
    public class FyshopifyimageValidator : AbstractValidator<FYShopifyImage>
    {
        #region ClientService

        #endregion ClientService

        public FyshopifyimageValidator()
        {
            RuleFor(p => p.Cid).MaximumLength(50);
            RuleFor(p => p.alt).MaximumLength(150);
            RuleFor(p => p.product_id).MaximumLength(50);
            RuleFor(p => p.admin_graphql_api_id).MaximumLength(150);
            RuleFor(p => p.src).MaximumLength(150);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
