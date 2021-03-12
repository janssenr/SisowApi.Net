namespace SisowApi.Net.Resources
{
    public class Product
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public int NetPrice { get; set; }

        public int Total { get; set; }

        public int NetTotal { get; set; }

        public int Tax { get; set; }

        public int TaxRate { get; set; }

        public string Type { get; set; }
    }
}
