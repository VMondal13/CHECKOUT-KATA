using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class DiscountInfo
    {
        public string Item { get; set; }
        public int Count { get; set; }
        public int DiscountPrice { get; set; }
        public DiscountInfo(string item, int count, int discountPrice) 
        { 
            this.Item = item;
            this.Count = count;
            this.DiscountPrice = discountPrice;
        }
    }
}
