namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public int Price { get; set; }
        public Dictionary<string, int> ProductData { get; set; }
        public List<DiscountInfo> DiscountInfos { get; set; }
        public int ItemCount { get; set; }
        public Dictionary<string, int> ItemScanDetails { get; set; }

        public Checkout(Dictionary<string, int> productData, List<DiscountInfo> discountInfos)
        {
            this.Price = 0;
            this.ItemCount = 0;
            this.ProductData = productData;
            this.DiscountInfos = discountInfos;
            ItemScanDetails = new Dictionary<string, int>();
        }
        public void Scan(string item)
        {
            if (ItemScanDetails.ContainsKey(item))
                ItemScanDetails[item]++;
            else
                ItemScanDetails.Add(item, 1);

            //this.Price += this.ProductData[item];
            //this.ItemCount++;
        }

        public int GetTotalPrice()
        {
            foreach(var scannedItem in ItemScanDetails)
            {
                var discountInfo = DiscountInfos.Where(x => x.Item == scannedItem.Key).FirstOrDefault();
                if (discountInfo != null)
                {
                    if (scannedItem.Value == discountInfo.ItemCount)
                        this.Price += discountInfo.DiscountPrice;
                    else
                        this.Price += scannedItem.Value * this.ProductData[scannedItem.Key];

                }
                else
                    this.Price += scannedItem.Value * this.ProductData[scannedItem.Key];
            }
            
            return this.Price;
        }

    }
}
