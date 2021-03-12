# SisowApi.Net

With this library you can easily connect your custom website/webshop to Sisow.

## Getting Started

These instructions will get you a copy of the project up and running.

### Prerequisites

Your web server needs to support at least the following.

```
ASP.NET 4.5.1 or higher
```

### Installing

Installing this package can easily by using [Nuget Package](https://www.nuget.org/packages/SisowApi/).

```
Install-Package SisowApi
```

## Getting started

First you need to initialize the Sisow client and set your Merchant ID and Merchant Key. Optional to set your Shop ID.

```
var sisow = new SisowClient();
sisow.SetApiKey("merchantId", "merchantKey", "shopId");
```

If you initialized the client you can create your first payment. Below is an example of the request with the required parameters. For all the parameters check the [API documentation](https://www.sisow.nl/developers/).

```
var request = new TransactionRequest
{
	Payment = PaymentMethod.IDEAL,
	PurchaseId = "orderID",
	Amount = 100, // amount is in cents (100 equals 1,00)
	Description = "Webshop Order #", // description for consumer bank statement
	ReturnUrl = new Uri("https://mywebshop.com")
};
var payment = await sisow.Transactions.Create(request);
```

After creating the payment you can access the payment status by the payment.Status parameter, this parameter can have the value Open, Pending or Reservation. Optional you can save the payment.Id parameter to the database (this parameter is empty when payment equals ideal and no issuerid is set).

```
switch (payment.Status)
{
	case PaymentStatus.STATUS_Pending:
		// set order state to pending
		break;
	case PaymentStatus.STATUS_Reservation:
		// set order state to reservation
		break;
	default:
		// status open, send consumer to the issuer URL to complete the payment
		Response.Redirect(payment.IssuerUrl);
		break;
}
```

If the request for some reason fails a SisowException will be thrown. You can intercept this with a try/catch block. 

### Retrieve payment

If you want to know the actual payment status, you can retrieve the payment.

```
var payment = sisow.Transactions.Get("sisowTransactionId");
```

### Refunding payment

All the payment methods except the Giftcards and Pay Later payment methods support the refund API. For the pay later methods you need to use the invoices endpoint.

```
var refund = sisow.Transactions.Refund("sisowTransactionId", 100); // 100 is amount in cents (100 equals 1,00)
```

## Unit Testing

If you want to execute the unit test you need to insert your Merchant ID and Merchant key to the App.config file.

Once added you can execute all the unit tests.

## Contributing

If you want to make a contribution you can submit a pull request.

## Versioning

For the versions available, see the [tags on this repository](https://github.com/janssenr/SisowApi.Net/tags). 

## Authors

* **Rob Janssen**