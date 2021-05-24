using NUnit.Framework;
using System.Collections.Generic;
using PromotionEngine;

namespace PromotionTests
{
    [TestFixture]
    public class PromotionTest
    {
        // Test Cas: UnitName,  NumberOfUnits AND  ExpectedPrice  
        [Test]
        [TestCase("A", 1, 50)]
        [TestCase("A", 3, 130)]
        [TestCase("B", 1, 30)]
        [TestCase("B", 2, 45)]
        [TestCase("C", 1, 20)]
        [TestCase("D", 1, 15)]
        public void CalculateMethodTest(string unitName, int numberOfUnits, decimal expectedPrice)
        {
            Product product = new Product { UnitName = unitName, NumberOfUnits = numberOfUnits };
            IProductItem productItem = ProductFactory.GetPriceByUnit(product);
            decimal unitprice = productItem.CalculatePrice(product.NumberOfUnits);

            //  Assert.AreEqual(unitprice, expectedPrice);
            Assert.That(unitprice, Is.EqualTo(expectedPrice));
        }

        [Test]

        public void TestProductItem_C_And_D_Expected30_ForSingleUnit()
        {
            var units = new List<Product> {
                new Product { UnitName = "C", NumberOfUnits = 1 },
                new Product { UnitName = "D", NumberOfUnits = 1 }
            };

            decimal totalPrice = ProductFactory.GetTotalPrice(units);

            Assert.That(totalPrice, Is.EqualTo(30), "Expected 30 for single unit of C and D");
        }

        [Test]

        public void TestProductItem_A_B_And_C_Expected100_ForSingleUnit()
        {
            var units = new List<Product> {
                new Product { UnitName = "A", NumberOfUnits = 1 },
                new Product { UnitName = "B", NumberOfUnits = 1 },
                new Product { UnitName = "C", NumberOfUnits = 1 }
            };
            decimal totalPrice = ProductFactory.GetTotalPrice(units);

            Assert.That(totalPrice, Is.EqualTo(100), "Expected 100 for single unit of A,B and C");
        }

        [Test]
        public void TestProductItem_5A_5B_And_C_Expected370()
        {
            var units = new List<Product> {
                new Product { UnitName = "A", NumberOfUnits = 5 },
                new Product { UnitName = "B", NumberOfUnits = 5 },
                new Product { UnitName = "C", NumberOfUnits = 1 }
            };
            decimal totalPrice = ProductFactory.GetTotalPrice(units);

            Assert.That(totalPrice, Is.EqualTo(370), "Expected 370 for 5 unit of A, 5 unit of B and single unit of C");
        }

        [Test]
        public void TestProductItem_3A_5B_1C_And_1D_Expected280()
        {
            var units = new List<Product> {
                new Product { UnitName = "A", NumberOfUnits = 3 },
                new Product { UnitName = "B", NumberOfUnits = 5 },
                new Product { UnitName = "C", NumberOfUnits = 1 },
                new Product { UnitName = "D", NumberOfUnits = 1 }
            };

            decimal totalPrice = ProductFactory.GetTotalPrice(units);

            Assert.That(totalPrice, Is.EqualTo(280), "Expected 280 for 3 unit of A, 5 unit of B and single unit of C and D");
        }

    }
}
