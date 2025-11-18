using FluentValidation;
using Bps.BpsBase.Entities.Concrete.FY;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.FY
{
    public class FyshopifyorderValidator : AbstractValidator<FYShopifyOrder>
    {
        #region ClientService

        #endregion ClientService

        public FyshopifyorderValidator()
        {
            RuleFor(p => p.Cid).MaximumLength(50);
            RuleFor(p => p.SName).MaximumLength(50);
            RuleFor(p => p.CustomerId).MaximumLength(50);
            RuleFor(p => p.CustomerName).MaximumLength(50);
            RuleFor(p => p.Source).MaximumLength(50);
            RuleFor(p => p.FinancialStatus).MaximumLength(50);
            RuleFor(p => p.order_status_url).MaximumLength(250);
            RuleFor(p => p.fulfillment_status).MaximumLength(50);
            RuleFor(p => p.Stocks).MaximumLength(50);
            RuleFor(p => p.shipment_status).MaximumLength(50);
            RuleFor(p => p.shipping_code).MaximumLength(50);
            RuleFor(p => p.CRKODU).MaximumLength(25);
            RuleFor(p => p.Amount).MaximumLength(50);
            RuleFor(p => p.CurrencyCode).MaximumLength(50);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
