namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public int Price { get; set; }
        public Dictionary<string, int> ProductData { get; set; }
        public List<DiscountInfo> DiscountInfos { get; set; }
        public Dictionary<string, int> ItemScanDetails { get; set; }
        public Checkout(Dictionary<string, int> productData, List<DiscountInfo> discountInfos)
        {
            Price = 0;
            ProductData = productData;
            DiscountInfos = discountInfos;
            ItemScanDetails = new Dictionary<string, int>();
        }
        public void Scan(string item)
        {
            if (ItemScanDetails.ContainsKey(item))
                ItemScanDetails[item]++;
            else
                ItemScanDetails.Add(item, 1);
        }

        public int GetTotalPrice()
        {
            foreach(var scannedItem in ItemScanDetails)
            {
                if (ProductData.ContainsKey(scannedItem.Key))
                {
                    var discountInfo = DiscountInfos.Where(x => x.Item == scannedItem.Key).FirstOrDefault();

                    if (discountInfo != null)
                    {
                        int multiplier = scannedItem.Value / discountInfo.ItemCount;
                        int additionalItemCount = scannedItem.Value % discountInfo.ItemCount;

                        Price += (multiplier * discountInfo.DiscountPrice)
                                        + (additionalItemCount * ProductData[scannedItem.Key]);

                    }
                    else
                    {
                        Price += scannedItem.Value * ProductData[scannedItem.Key];
                    }
                }
                
            }
            
            return Price;
        }

    }
}
