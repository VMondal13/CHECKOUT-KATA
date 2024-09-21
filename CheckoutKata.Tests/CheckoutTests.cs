using NUnit.Framework;

namespace CheckoutKata.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        [Test]
        public void TestSingleItem()
        {
            string item = "A";
            int price = 50;
            var checkout = new Checkout();

            checkout.Scan(item);

            Assert.AreEqual(50, checkout.GetTotalPrice());
        }
    }
}
