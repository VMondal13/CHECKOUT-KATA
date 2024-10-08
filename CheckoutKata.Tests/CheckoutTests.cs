﻿using NUnit.Framework;

namespace CheckoutKata.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        Checkout checkout;

        [SetUp]
        public void SetUp()
        {
            var productData = new Dictionary<string, int>();
            productData.Add("A", 50);
            productData.Add("B", 30);
            productData.Add("C", 20);
            productData.Add("D", 15);


            List<DiscountInfo> discountInfos = new List<DiscountInfo>();
            discountInfos.Add(new DiscountInfo("A", 3, 130));
            discountInfos.Add(new DiscountInfo("B", 2, 45));

            checkout = new Checkout(productData, discountInfos);

        }

        [Test]
        public void Test_WhenSingleItemForProductA_ShouldReturnUnitPrice()
        {
            checkout.Scan("A");

            Assert.AreEqual(50, checkout.GetTotalPrice());
        }


        [Test]
        public void Test_WhenSingleItemForProductB_ShouldReturnUnitPrice()
        {
            checkout.Scan("B");

            Assert.AreEqual(30, checkout.GetTotalPrice());
        }

        [Test]
        public void Test_WhenSingleItemForProductC_ShouldReturnUnitPrice()
        {
            checkout.Scan("C");

            Assert.AreEqual(20, checkout.GetTotalPrice());
        }

        [Test]
        public void Test_WhenSingleItemForProductD_ShouldReturnUnitPrice()
        {
            checkout.Scan("D");

            Assert.AreEqual(15, checkout.GetTotalPrice());
        }

        [Test]
        public void Test_WhenMultipleItemForSameProductWithNoDiscount_ShouldReturnTotalPrice()
        {
            checkout.Scan("C");
            checkout.Scan("C");

            Assert.AreEqual(40, checkout.GetTotalPrice());
        }

        [Test]
        public void Test_WhenMultipleItemForMultipleProductWithNoDiscount_ShouldReturnTotalPrice()
        {
            checkout.Scan("C");
            checkout.Scan("D");
            checkout.Scan("A");
            checkout.Scan("B");

            Assert.AreEqual(115, checkout.GetTotalPrice());
        }

        [Test]
        public void Test_WhenMultipleItemForSameProductWithDiscount_ShouldReturnDiscountedPrice()
        {
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            Assert.AreEqual(130, checkout.GetTotalPrice());
        }

        [Test]
        public void Test_WhenMultipleItemForSameProductBWithDiscount_ShouldReturnDiscountedPrice()
        {
            checkout.Scan("B");
            checkout.Scan("B");

            Assert.AreEqual(45, checkout.GetTotalPrice());
        }

        [Test]
        public void Test_WhenMultipleItemForMultipleDiscountedProduct_ShouldReturnDiscountedPrice()
        {
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            Assert.AreEqual(175, checkout.GetTotalPrice());
        }

        [Test]
        public void Test_WhenMoreItemsForMultipleDiscountedProduct_ShouldReturnMixedPrice()
        {
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            Assert.AreEqual(255, checkout.GetTotalPrice());
        }

        [Test]
        public void Test_SpecialAndRegularProductTogether_ShouldReturnMixedPrice()
        {
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("A");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");

            Assert.AreEqual(305, checkout.GetTotalPrice());
        }

        [Test]
        public void Test_WhenDummyItemScanned_ShouldReturnZeroPrice()
        {
            checkout.Scan("X");
            Assert.AreEqual(0, checkout.GetTotalPrice());
        }

        [Test]
        public void Test_WhenNoItemScanned_ShouldReturnZeroPrice()
        {
            Assert.AreEqual(0, checkout.GetTotalPrice());
        }




    }
}
