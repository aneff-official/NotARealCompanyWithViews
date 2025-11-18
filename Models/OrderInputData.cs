using System.Text.Json.Serialization;

namespace NotARealCompanyWithViews.Models
{
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Skip)]
    public class OrderInputData
    {
        public AddressInfo? BillingAddress { get; set; }
        public DateTime? CompletedAt { get; set; }
        public CustomerInfo? Customer { get; set; }
        public IEnumerable<object>? Discounts { get; set; }
        public string? Id { get; set; }
        public IEnumerable<OrderItem>? Items { get; set; }
        public IEnumerable<object>? Notes { get; set; }
        public PaymentInfo? Payment { get; set; }
        public ProcessorResponse? ProcessorResponse { get; set; }
        public ReferralInfo? Referral { get; set; }
        public AddressInfo? ShippingAddress { get; set; }
        public string? Source { get; set; }
        public DateTime? StartedAt { get; set; }
        public string? Status { get; set; }
    }

    /*
        "referral": {
            "identifier": "1111111111",
            "landing_page": "/specials/extraspecials/example",
            "site": "http://example.com"
        },
    */
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Skip)]
    public class ReferralInfo
    {
        public string? Identifier { get; set; }
        public string? LandingPage { get; set; }
        public string? Site { get; set; }
    }

    // Billing and Shipping Address share the same structure

    /*
        "shipping_address": {
            "address": "49491 Jackson Forks",
            "city": "Port Lonzo",
            "country": "Comoros",
            "lat": "80.5739",
            "lon": "-133.4117",
            "name": "Trevor Abernathy",
            "state": "Delaware"
        }

        "billing_address": {
            "address": "45952 Jayde Estate",
            "city": "New Timmothy",
            "country": "Samoa",
            "lat": "7.2043",
            "lon": "-148.1544",
            "name": "Trevor Abernathy",
            "state": "New Hampshire"
        }
    */
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Skip)]
    public class AddressInfo
    {
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Lat { get; set; }
        public string? Lon { get; set; }
        public string? Name { get; set; }
        public string? State { get; set; }
    }


    /*
        "customer": {
            "company": "Flatley, Turner and Greenholt",
            "country": "Ghana",
            "created_at": "2014-07-04T14:44:01.018Z",
            "email": "holly.zieme@hotmail.com",
            "first": "Trevor",
            "id": 7349,
            "last": "Abernathy"s
        }
    */
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Skip)]
    public class CustomerInfo
    {
        public string? Company { get; set; }
        public string? Country { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? Email { get; set; }
        public string? First { get; set; }
        public int? Id { get; set; }
        public string? Last { get; set; }
    }

    /*
        {
            "discounts": [],
            "fulfillment": "download",
            "gift_card": false,
            "grams": "0",
            "price": 1012,
            "quantity": 3,
            "requires_shipping": false,
            "sku": "ALBUM-235",
            "taxable": true,
            "taxes": [],
            "title": "How To Dismantle An Atomic Bomb",
            "vendor": "U2"
        }
    */
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Skip)]
    public class OrderItem
    {
        public string[]? Discounts { get; set; }
        public string? Fulfillment { get; set; }
        public bool? GiftCard { get; set; }
        public string? Grams { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public bool? RequiresShipping { get; set; }
        public string? Sku { get; set; }
        public bool? Taxable { get; set; }
        public string[]? Taxes { get; set; }
        public string? Title { get; set; }
        public string? Vendor { get; set; }

    }

    /*
        "payment": {
            "amount": 12936,
            "authorization": "XXXXXXXXXXX",
            "gateway": "stripe",
            "last_four": "4242"
        }
    */
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Skip)]
    public class PaymentInfo
    {
        public decimal? Amount { get; set; }
        public string? Authorization { get; set; }
        public string? Gateway { get; set; }
        public string? LastFour { get; set; }
    }

    /*
        "processor_response": {
            "amount": 100,
            "amount_refunded": 0,
            "application_fee": null,
            "balance_transaction": "txn_ZZZZZ",
            "captured": true,
            "created": 1701184637,
            "currency": "usd",
            "customer": null,
            "description": "Charge for Trevor Abernathy",
            "dispute": null,
            "failure_code": null,
            "failure_message": null,
            "fraud_details": {},
            "id": "ch_XXXXXXXX",
            "invoice": null,
            "livemode": false,
            "object": "charge",
            "paid": true,
            "receipt_email": null,
            "receipt_number": null,
            "refunded": false,
            "refunds": {
                "data": [],
                "has_more": false,
                "object": "list",
                "total_count": 0,
                "url": "/v1/charges/XYZ/refunds"
            },
            "shipping": null,
            "source": {
                "brand": "Visa",
                "country": "US",
                "customer": null,
                "cvc_check": "pass",
                "exp_month": 8,
                "exp_year": 2019,
                "funding": "credit",
                "id": "card_XYZZ",
                "last4": "4242",
                "name": "Trevor Abernathy",
                "object": "card"
            },
            "statement_descriptor": null,
            "status": "succeeded"
        },
    */
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Skip)]
    public class ProcessorResponse
    {
        public decimal? Amount { get; set; }
        public decimal? AmountRefunded { get; set; }
        public string? ApplicationFee { get; set; }
        public string? BalanceTransaction { get; set; }
        public bool? Captured { get; set; }
        public int? Created { get; set; }
        public string? Currency { get; set; }
        public CustomerInfo? Customer { get; set; }
        public string? Description { get; set; }
        public string? Dispute { get; set; }
        public int? FailureCode { get; set; }
        public string? FailureMessage { get; set; }
        public object? FraudDetails { get; set; }
        public string? Id { get; set; }
        public string? Invoice { get; set; }
        public bool? Livemode { get; set; }
        public string? Object { get; set; }
        public bool? Paid { get; set; }
        public string? ReceiptEmail { get; set; }
        public string? ReceiptNumber { get; set; }
        public bool? Refunded { get; set; }
        public RefundInfo? Refunds { get; set; }
        public string? Shipping { get; set; }
        public SourceInfo? Source { get; set; }
        public string? StatementDescriptor { get; set; }
        public string? Status { get; set; }
    }

    /*
        "refunds": {
            "data": [],
            "has_more": false,
            "object": "list",
            "total_count": 0,
            "url": "/v1/charges/XYZ/refunds"
        }
    */
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Skip)]
    public class RefundInfo
    {
        public IEnumerable<object>? Data { get; set; }
        public bool? HasMore { get; set; }
        public string? Object { get; set; }
        public int? TotalCount { get; set; }
        public string? Url { get; set; }
    }

    /*
        "source": {
            "brand": "Visa",
            "country": "US",
            "customer": null,
            "cvc_check": "pass",
            "exp_month": 8,
            "exp_year": 2019,
            "funding": "credit",
            "id": "card_XYZZ",
            "last4": "4242",
            "name": "Trevor Abernathy",
            "object": "card"
        }
    */
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Skip)]
    public class SourceInfo
    {
        public string? Brand { get; set; }
        public string? Country { get; set; }
        public CustomerInfo? Customer { get; set; }
        public string? CvcCheck { get; set; }
        public int? ExpMonth { get; set; }
        public int? ExpYear { get; set; }
        public string? Funding { get; set; }
        public string? Id { get; set; }
        public string? Last4 { get; set; }
        public string? Name { get; set; }
        public string? Object { get; set; }
    }
}
