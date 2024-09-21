namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public int price { get; set; }

        public Checkout(int price) 
        { 
            this.price = price;
        }

        public void Scan(string item)
        {
            //if (item.Equals("A"))
            //    this.price = 50;
            //else
            //    this.price = 30;
        }

        public int GetTotalPrice()
        {
            return this.price;
        }

    }
}
