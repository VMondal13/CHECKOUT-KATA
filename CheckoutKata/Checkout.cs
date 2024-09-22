namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public int Price { get; set; }
        public Dictionary<string, int> ProductData { get; set; }
        public List<DiscountInfo> DiscountInfos { get; set; }
        public int ItemCount { get; set; }
        public string ItemName { get; set; }

        public Checkout(Dictionary<string, int> productData, List<DiscountInfo> discountInfos)
        {
            this.Price = 0;
            this.ItemCount = 0;
            this.ProductData = productData;
            this.DiscountInfos = discountInfos;
        }
        public void Scan(string item)
        {
            this.ItemName = item;
            this.Price += this.ProductData[item];
            this.ItemCount++;
        }

        public int GetTotalPrice()
        {
            var discountInfo = DiscountInfos.Where(x => x.Item == ItemName).FirstOrDefault();
            if (discountInfo != null && this.ItemCount == discountInfo.ItemCount)
                return discountInfo.DiscountPrice;
            return this.Price;
        }

    }
}
