using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.Entities.Models.Shopify.Siparis
{
    [Serializable]
    public class ShopifyOrder
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("admin_graphql_api_id")]
        public string AdminGraphqlApiId { get; set; }

        [JsonProperty("app_id")]
        public int AppId { get; set; }

        [JsonProperty("browser_ip")]
        public string BrowserIp { get; set; }

        [JsonProperty("buyer_accepts_marketing")]
        public bool BuyerAcceptsMarketing { get; set; }

        [JsonProperty("cancel_reason")]
        public string CancelReason { get; set; }

        [JsonProperty("cancelled_at")]
        public DateTime? CancelledAt { get; set; }

        [JsonProperty("cart_token")]
        public string CartToken { get; set; }

        [JsonProperty("checkout_id")]
        public long CheckoutId { get; set; }

        [JsonProperty("checkout_token")]
        public string CheckoutToken { get; set; }

        [JsonProperty("client_details")]
        public ClientDetails ClientDetails { get; set; }

        [JsonProperty("closed_at")]
        public DateTime? ClosedAt { get; set; }

        [JsonProperty("confirmation_number")]
        public string ConfirmationNumber { get; set; }

        [JsonProperty("confirmed")]
        public bool Confirmed { get; set; }

        [JsonProperty("contact_email")]
        public string ContactEmail { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("current_subtotal_price")]
        public string CurrentSubtotalPrice { get; set; }

        [JsonProperty("current_subtotal_price_set")]
        public PriceSet CurrentSubtotalPriceSet { get; set; }

        [JsonProperty("current_total_additional_fees_set")]
        public object CurrentTotalAdditionalFeesSet { get; set; }

        [JsonProperty("current_total_discounts")]
        public string CurrentTotalDiscounts { get; set; }

        [JsonProperty("current_total_discounts_set")]
        public PriceSet CurrentTotalDiscountsSet { get; set; }

        [JsonProperty("current_total_duties_set")]
        public object CurrentTotalDutiesSet { get; set; }

        [JsonProperty("current_total_price")]
        public string CurrentTotalPrice { get; set; }

        [JsonProperty("current_total_price_set")]
        public PriceSet CurrentTotalPriceSet { get; set; }

        [JsonProperty("current_total_tax")]
        public string CurrentTotalTax { get; set; }

        [JsonProperty("current_total_tax_set")]
        public PriceSet CurrentTotalTaxSet { get; set; }

        [JsonProperty("customer_locale")]
        public string CustomerLocale { get; set; }

        [JsonProperty("device_id")]
        public object DeviceId { get; set; }

        [JsonProperty("discount_codes")]
        public List<object> DiscountCodes { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("estimated_taxes")]
        public bool EstimatedTaxes { get; set; }

        [JsonProperty("financial_status")]
        public string FinancialStatus { get; set; }

        [JsonProperty("fulfillment_status")]
        public string FulfillmentStatus { get; set; }

        [JsonProperty("landing_site")]
        public string LandingSite { get; set; }

        [JsonProperty("landing_site_ref")]
        public object LandingSiteRef { get; set; }

        [JsonProperty("location_id")]
        public object LocationId { get; set; }

        [JsonProperty("merchant_of_record_app_id")]
        public object MerchantOfRecordAppId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("note")]
        public object Note { get; set; }

        [JsonProperty("note_attributes")]
        public List<object> NoteAttributes { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("order_number")]
        public int OrderNumber { get; set; }

        [JsonProperty("order_status_url")]
        public string OrderStatusUrl { get; set; }

        [JsonProperty("original_total_additional_fees_set")]
        public object OriginalTotalAdditionalFeesSet { get; set; }

        [JsonProperty("original_total_duties_set")]
        public object OriginalTotalDutiesSet { get; set; }

        [JsonProperty("payment_gateway_names")]
        public List<string> PaymentGatewayNames { get; set; }

        [JsonProperty("phone")]
        public object Phone { get; set; }

        [JsonProperty("po_number")]
        public object PoNumber { get; set; }

        [JsonProperty("presentment_currency")]
        public string PresentmentCurrency { get; set; }

        [JsonProperty("processed_at")]
        public DateTime? ProcessedAt { get; set; }

        [JsonProperty("reference")]
        public object Reference { get; set; }

        [JsonProperty("referring_site")]
        public string ReferringSite { get; set; }

        [JsonProperty("source_identifier")]
        public object SourceIdentifier { get; set; }

        [JsonProperty("source_name")]
        public string SourceName { get; set; }

        [JsonProperty("source_url")]
        public object SourceUrl { get; set; }

        [JsonProperty("subtotal_price")]
        public string SubtotalPrice { get; set; }

        [JsonProperty("subtotal_price_set")]
        public PriceSet SubtotalPriceSet { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("tax_exempt")]
        public bool TaxExempt { get; set; }

        [JsonProperty("tax_lines")]
        public List<TaxLine> TaxLines { get; set; }

        [JsonProperty("taxes_included")]
        public bool TaxesIncluded { get; set; }

        [JsonProperty("test")]
        public bool Test { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("total_discounts")]
        public string TotalDiscounts { get; set; }

        [JsonProperty("total_discounts_set")]
        public PriceSet TotalDiscountsSet { get; set; }

        [JsonProperty("total_line_items_price")]
        public string TotalLineItemsPrice { get; set; }

        [JsonProperty("total_line_items_price_set")]
        public PriceSet TotalLineItemsPriceSet { get; set; }

        [JsonProperty("total_outstanding")]
        public string TotalOutstanding { get; set; }

        [JsonProperty("total_price")]
        public string TotalPrice { get; set; }

        [JsonProperty("total_price_set")]
        public PriceSet TotalPriceSet { get; set; }

        [JsonProperty("total_shipping_price_set")]
        public PriceSet TotalShippingPriceSet { get; set; }

        [JsonProperty("total_tax")]
        public string TotalTax { get; set; }

        [JsonProperty("total_tax_set")]
        public PriceSet TotalTaxSet { get; set; }

        [JsonProperty("total_tip_received")]
        public string TotalTipReceived { get; set; }

        [JsonProperty("total_weight")]
        public int TotalWeight { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("user_id")]
        public object UserId { get; set; }

        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("discount_applications")]
        public List<object> DiscountApplications { get; set; }

        [JsonProperty("fulfillments")]
        public List<Fulfillment> Fulfillments { get; set; }

        [JsonProperty("line_items")]
        public List<LineItem> LineItems { get; set; }

        [JsonProperty("payment_terms")]
        public object PaymentTerms { get; set; }

        [JsonProperty("refunds")]
        public List<object> Refunds { get; set; }

        [JsonProperty("shipping_address")]
        public Address ShippingAddress { get; set; }

        [JsonProperty("shipping_lines")]
        public List<ShippingLine> ShippingLines { get; set; }
    }
    [Serializable]
    public class ClientDetails
    {
        [JsonProperty("accept_language")]
        public string AcceptLanguage { get; set; }

        [JsonProperty("browser_height")]
        public object BrowserHeight { get; set; }

        [JsonProperty("browser_ip")]
        public string BrowserIp { get; set; }

        [JsonProperty("browser_width")]
        public object BrowserWidth { get; set; }

        [JsonProperty("session_hash")]
        public object SessionHash { get; set; }

        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }
    }
    [Serializable]
    public class Money
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
    }
    [Serializable]
    public class PriceSet
    {
        [JsonProperty("shop_money")]
        public Money ShopMoney { get; set; }

        [JsonProperty("presentment_money")]
        public Money PresentmentMoney { get; set; }
    }
    [Serializable]
    public class TaxLine
    {
        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("price_set")]
        public PriceSet PriceSet { get; set; }

        [JsonProperty("channel_liable")]
        public bool ChannelLiable { get; set; }
    }
    [Serializable]
    public class Address
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("province")]
        public object Province { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("company")]
        public object Company { get; set; }

        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("province_code")]
        public object ProvinceCode { get; set; }
    }
    [Serializable]
    public class EmailMarketingConsent
    {
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("opt_in_level")]
        public string OptInLevel { get; set; }

        [JsonProperty("consent_updated_at")]
        public DateTime? ConsentUpdatedAt { get; set; }
    }
    [Serializable]
    public class SmsMarketingConsent
    {
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("opt_in_level")]
        public string OptInLevel { get; set; }

        [JsonProperty("consent_updated_at")]
        public DateTime? ConsentUpdatedAt { get; set; }

        [JsonProperty("consent_collected_from")]
        public string ConsentCollectedFrom { get; set; }
    }
    [Serializable]
    public class DefaultAddress
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("customer_id")]
        public long CustomerId { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("company")]
        public object Company { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("province")]
        public object Province { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("province_code")]
        public object ProvinceCode { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("country_name")]
        public string CountryName { get; set; }

        [JsonProperty("default")]
        public bool Default { get; set; }
    }
    [Serializable]
    public class Customer
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("note")]
        public object Note { get; set; }

        [JsonProperty("verified_email")]
        public bool VerifiedEmail { get; set; }

        [JsonProperty("multipass_identifier")]
        public object MultipassIdentifier { get; set; }

        [JsonProperty("tax_exempt")]
        public bool TaxExempt { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email_marketing_consent")]
        public EmailMarketingConsent EmailMarketingConsent { get; set; }

        [JsonProperty("sms_marketing_consent")]
        public SmsMarketingConsent SmsMarketingConsent { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("tax_exemptions")]
        public List<object> TaxExemptions { get; set; }

        [JsonProperty("admin_graphql_api_id")]
        public string AdminGraphqlApiId { get; set; }

        [JsonProperty("default_address")]
        public DefaultAddress DefaultAddress { get; set; }
    }
    [Serializable]
    public class Fulfillment
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("admin_graphql_api_id")]
        public string AdminGraphqlApiId { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("location_id")]
        public long LocationId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("order_id")]
        public long OrderId { get; set; }

        [JsonProperty("origin_address")]
        public object OriginAddress { get; set; }

        [JsonProperty("receipt")]
        public object Receipt { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("shipment_status")]
        public string ShipmentStatus { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("tracking_company")]
        public string TrackingCompany { get; set; }

        [JsonProperty("tracking_number")]
        public string TrackingNumber { get; set; }

        [JsonProperty("tracking_numbers")]
        public List<string> TrackingNumbers { get; set; }

        [JsonProperty("tracking_url")]
        public string TrackingUrl { get; set; }

        [JsonProperty("tracking_urls")]
        public List<string> TrackingUrls { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("line_items")]
        public List<LineItem> LineItems { get; set; }
    }
    [Serializable]
    public class LineItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("admin_graphql_api_id")]
        public string AdminGraphqlApiId { get; set; }

        [JsonProperty("attributed_staffs")]
        public List<object> AttributedStaffs { get; set; }

        [JsonProperty("current_quantity")]
        public int CurrentQuantity { get; set; }

        [JsonProperty("fulfillable_quantity")]
        public int FulfillableQuantity { get; set; }

        [JsonProperty("fulfillment_service")]
        public string FulfillmentService { get; set; }

        [JsonProperty("fulfillment_status")]
        public string FulfillmentStatus { get; set; }

        [JsonProperty("gift_card")]
        public bool GiftCard { get; set; }

        [JsonProperty("grams")]
        public int Grams { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("price_set")]
        public PriceSet PriceSet { get; set; }

        [JsonProperty("product_exists")]
        public bool ProductExists { get; set; }

        [JsonProperty("product_id")]
        public long ProductId { get; set; }

        [JsonProperty("properties")]
        public List<object> Properties { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("requires_shipping")]
        public bool RequiresShipping { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("taxable")]
        public bool Taxable { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("total_discount")]
        public string TotalDiscount { get; set; }

        [JsonProperty("total_discount_set")]
        public PriceSet TotalDiscountSet { get; set; }

        [JsonProperty("variant_id")]
        public long VariantId { get; set; }

        [JsonProperty("variant_inventory_management")]
        public object VariantInventoryManagement { get; set; }

        [JsonProperty("variant_title")]
        public string VariantTitle { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }

        [JsonProperty("tax_lines")]
        public List<TaxLine> TaxLines { get; set; }

        [JsonProperty("duties")]
        public List<object> Duties { get; set; }

        [JsonProperty("discount_allocations")]
        public List<object> DiscountAllocations { get; set; }
    }
    [Serializable]
    public class ShippingLine
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("carrier_identifier")]
        public object CarrierIdentifier { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("discounted_price")]
        public string DiscountedPrice { get; set; }

        [JsonProperty("discounted_price_set")]
        public PriceSet DiscountedPriceSet { get; set; }

        [JsonProperty("is_removed")]
        public bool IsRemoved { get; set; }

        [JsonProperty("phone")]
        public object Phone { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("price_set")]
        public PriceSet PriceSet { get; set; }

        [JsonProperty("requested_fulfillment_service_id")]
        public object RequestedFulfillmentServiceId { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("tax_lines")]
        public List<object> TaxLines { get; set; }

        [JsonProperty("discount_allocations")]
        public List<object> DiscountAllocations { get; set; }
    }

}


