# NotARealCompanyWithViews

## Brief Overview & Instructions

This project is targeting .NET 8, so make sure you have the [prerequisites](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed. Building and running the solution is most comfortable with Visual Studio (running on `https://localhost:7084/`).

Alternatively, you may use a `dotnet` command to run the solution from root directory and navigate to `http://localhost:5244/`

```bash
dotnet run
```

- The solution provides a nicely-styled SPA, imitating a data load and demonstrating the population of a prototype table with all the essential information.
- MVC approach is used for a hands-on experience
- Logging & Error handling included
- Versatile methods of reading & aggregating the data
- Closely followed structure and proper mapping to C# classes
- Dependency injection for custom services
- One instance of a HttpClient that will be making `async` **GET** requests
- Improved error redirects
- Shared JSON Serializer Options
- Intuitive variable names and clean code

#### Although there is no properly defined URL to use, in this solution we have 3 different approaches that achieve the same result:
- Using the local file from `Sample/sales.json`
- Editing `Constants/Constants.cs`:
    - Modify the base URL through changing `API_BASE_URL` to the preferred location
    - Modify the request URL through changing `API_REQUEST_URL` to the preferred action
    - Modify `IS_LOCAL` by setting it to `false`, as it currently defaults to `true`
- Integrate this solution to your project and/or test with tools like **Postman** to hit the endpoint

### API Endpoint

**URL**: `/order/aggregate`

**Method**: `GET`

**Query Parameters**:

- `ordersFromInput` (IEnumerable\<OrderInputData\>): The raw input data.

The desired format is met through DTOs and we have our output in the same **SAMPLE** folder.
There is no interactive method of exporting a JSON file in this iteration.
It is done automatically, rewriting the existing `output.json` if exists.
The constants used for this are `LOCAL_JSON_PATH_INPUT` and `LOCAL_JSON_PATH_OUTPUT`.

JSON format:
```json
{
    "id": "a unique identifier for the record",
    "customer_id": "a unique identifier for the customer"
    "customer_email": "customers email address",
    "customer_forenames": "customers first names",
    "customer_surname": "customers last name",
    "customer_address": "customers address",
    "product_name": "product name purchased by customer",
    "product_sku": "product sku purchased by customer",
    "product_quantity": "quantity of item purchased",
    "product_price": "product price in purchased currency"
    "shipping_address": "full address where product was shipped",
    "purchased_on": "date time representation of when product was purchased",
    "purchased_on_date": "date representation of the day the purchase occurred in local time",
}
```

C# equivalent:
```csharp
public class OrderDTO
{
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
```
