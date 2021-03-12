using SisowApi.Net.Resources;
using SisowApi.Net.Types;
using System;
using System.Collections.Generic;

namespace SisowApi.Tests.Helpers
{
    public static class SisowHelper
    {
        public static string GenerateRandomString(int length = 16)
        {
            var characters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var charactersLength = characters.Length;
            var randomString = "";
            for (int i = 0; i < length; i++)
            {
                randomString += characters[new Random().Next(charactersLength - 1)];
            }
            return randomString;
        }

        public static TransactionRequest Transaction()
        {
            return new TransactionRequest
            {
                Payment = PaymentMethod.AFTERPAY,
                PurchaseId = GenerateRandomString(),
                Amount = 100,
                Description = "unit test",
                TestMode = true,
                ReturnUrl = new Uri("https://www.sisow.nl"),
                Currency = "EUR",
                IpAddress = "1.1.1.1",
                Gender = "m",
                BirthDate = new DateTime(1970, 1, 1),
                BillingAddress = new Address
                {
                    FirstName = "Test",
                    LastName = "Approved",
                    Email = "info@sisow.nl",
                    Address1 = "Binnen Parallelweg 14",
                    Address2 = "",
                    Zip = "5701PH",
                    City = "Helmond",
                    CountryCode = "NL",
                    Phone = "0612345678"
                },
                ShippingAddress = new Address
                {
                    FirstName = "Test",
                    LastName = "Approved",
                    Email = "info@sisow.nl",
                    Address1 = "Binnen Parallelweg 14",
                    Address2 = "",
                    Zip = "5701PH",
                    City = "Helmond",
                    CountryCode = "NL",
                    Phone = "0612345678"
                },
                Products = new List<Product>
                {
                    new Product
                    {
                        Id = "test",
                        Description = "Test product",
                        Quantity = 1,
                        NetPrice = 79,
                        Total = 100,
                        NetTotal = 79,
                        Tax = 21,
                        TaxRate = 2100
                    }
                }
            };
        }
    }
}
