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
            checkout = new Checkout(productData);
        }

        [Test]
        public void TestSingleItemForProductA()
        {
            checkout.Scan("A");

            Assert.AreEqual(50, checkout.GetTotalPrice());
        }


        [Test]
        public void TestSingleItemForProductB()
        {
            checkout.Scan("B");

            Assert.AreEqual(30, checkout.GetTotalPrice());
        }

        [Test]
        public void TestSingleItemForProductC()
        {
            checkout.Scan("C");

            Assert.AreEqual(20, checkout.GetTotalPrice());
        }

        [Test]
        public void TestSingleItemForProductD()
        {
            checkout.Scan("D");

            Assert.AreEqual(15, checkout.GetTotalPrice());
        }


    }
}
