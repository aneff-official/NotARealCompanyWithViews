namespace NotARealCompanyWithViews.Models
{
    /* Abiding the provided schema:
        {
            "id": "a unique identifier for the record",
            “customer_id”: “a unique identifier for the customer”
            “customer_email”: “customers email address”,
            "customer_forenames": "customers first names",
            "customer_surname": "customers last name",
            "customer_address": "customers address",
            "product_name": "product name purchased by customer",
            "product_sku": "product sku purchased by customer",
            "product_quantity": "quantity of item purchased",
            "product_price": "product price in purchased currency"
            "shipping_address": "full address where product was shipped",
            “purchased_on”: "date time representation of when product was purchased",
            "purchased_on_date”: “date representation of the day the purchase occurred in local time”,
        }
    */

    public class OrderDTO
    {
        // Can be either string, int or Guid depending on the database design
        public string? Id { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerEmail { get; set; } = string.Empty;
        public string? CustomerForenames { get; set; } = string.Empty;
        public string? CustomerSurname { get; set; } = string.Empty;
        public string? CustomerAddress { get; set; } = string.Empty;
        public string? ProductName { get; set; } = string.Empty;
        public string? ProductSku { get; set; } = string.Empty;
        public int? ProductQuantity { get; set; }
        public decimal? ProductPrice { get; set; }
        public string? ShippingAddress { get; set; } = string.Empty;
        public DateTime? PurchasedOn { get; set; }
        public DateOnly? PurchasedOnDate { get; set; }
    }
}
