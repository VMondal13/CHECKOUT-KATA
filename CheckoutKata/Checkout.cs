namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public int Price { get; set; }
        public Dictionary<string, int> ProductData { get; set; }

        public Checkout(Dictionary<string, int> productData)
        {
            this.ProductData = productData;
        }
        public void Scan(string item)
        {
            this.Price = this.ProductData[item];
        }

        public int GetTotalPrice()
        {
            return this.Price;
        }

    }
}
