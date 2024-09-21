using NUnit.Framework;

namespace CheckoutKata.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        [Test]
        public void TestSingleItemForProductA()
        {
            string item = "A";
            int price = 50;
            var checkout = new Checkout();

            checkout.Scan(item);

            Assert.AreEqual(50, checkout.GetTotalPrice());
        }

        [Test]
        public void TestSingleItemForProductB()
        {
            string item = "B";
            int price = 30;
            var checkout = new Checkout();

            checkout.Scan(item);

            Assert.AreEqual(30, checkout.GetTotalPrice());
        }
    }
}
