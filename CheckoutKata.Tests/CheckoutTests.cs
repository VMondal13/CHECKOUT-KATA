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
            var checkout = new Checkout(price);

            checkout.Scan(item);

            Assert.AreEqual(50, checkout.GetTotalPrice());
        }

        [Test]
        public void TestSingleItemForProductB()
        {
            string item = "B";
            int price = 30;
            var checkout = new Checkout(price);

            checkout.Scan(item);

            Assert.AreEqual(30, checkout.GetTotalPrice());
        }

        [Test]
        public void TestSingleItemForProductC()
        {
            string item = "C";
            int price = 20;
            var checkout = new Checkout(price);

            checkout.Scan(item);

            Assert.AreEqual(20, checkout.GetTotalPrice());
        }

        [Test]
        public void TestSingleItemForProductD()
        {
            string item = "D";
            int price = 15;
            var checkout = new Checkout(price);

            checkout.Scan(item);

            Assert.AreEqual(15, checkout.GetTotalPrice());
        }
    }
}
