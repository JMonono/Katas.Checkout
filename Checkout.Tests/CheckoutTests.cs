using Checkout.Concrete;
using Checkout.Listeners;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Checkout.Tests
{
    [TestClass]
    public class CheckoutTests : ICheckoutListener
    {
        private Money _total = new Money(0);

        [TestMethod]
        public void ScanAGivesTotalOf50()
        {
            // Arrange
            var checkout = new Scanner(this, new DiscountListener());

            // Act
            checkout.Scan(new Product("A"));

            // Assert
            Assert.AreEqual(new Money(50), _total);
        }

        [TestMethod]
        public void ScanBGivesTotalOf30()
        {
            // Arrange
            var checkout = new Scanner(this, new DiscountListener());

            // Act
            checkout.Scan(new Product("B"));

            // Assert
            Assert.AreEqual(new Money(30), _total);
        }

        [TestMethod]
        public void ScanCGivesTotalOf20()
        {
            // Arrange
            var checkout = new Scanner(this, new DiscountListener());

            // Act
            checkout.Scan(new Product("C"));

            // Assert
            Assert.AreEqual(new Money(20), _total);
        }

        [TestMethod]
        public void ScanDGivesTotalOf15()
        {
            // Arrange
            var checkout = new Scanner(this, new DiscountListener());

            // Act
            checkout.Scan(new Product("D"));

            // Assert
            Assert.AreEqual(new Money(15), _total);
        }

        [TestMethod]
        public void ScanningTwoAsGivesTotalOf100()
        {
            // Arrange
            var checkout = new Scanner(this, new DiscountListener());
            // Act
            checkout.Scan(new Product("A"));
            checkout.Scan(new Product("A"));

            // Assert
            Assert.AreEqual(new Money(100), _total);
        }

        [TestMethod]
        public void ScanningThreeAsGivesTotalOf130()
        {
            // Arrange
            var checkout = new Scanner(this, new DiscountListener());
            // Act
            checkout.Scan(new Product("A"));
            checkout.Scan(new Product("A"));
            checkout.Scan(new Product("A"));

            // Assert
            Assert.AreEqual(new Money(130), _total);
        }

        [TestMethod]
        public void ScanningTwoBsGivesTotalOf45()
        {
            // Arrange
            var checkout = new Scanner(this, new DiscountListener());
            // Act
            checkout.Scan(new Product("B"));
            checkout.Scan(new Product("B"));
            
            // Assert
            Assert.AreEqual(new Money(45), _total);
        }

        [TestMethod]
        public void ScanningThreeAsAnd3BsGivesTotalOf205()
        {
            // Arrange
            var checkout = new Scanner(this, new DiscountListener());
            // Act
            checkout.Scan(new Product("A"));
            checkout.Scan(new Product("A"));
            checkout.Scan(new Product("A"));
            checkout.Scan(new Product("B"));
            checkout.Scan(new Product("B"));
            checkout.Scan(new Product("B"));

            // Assert
            Assert.AreEqual(new Money(205), _total);
        }

        [TestMethod]
        public void ScanningSevenAsGivesTotalOf310()
        {
            // Arrange
            var checkout = new Scanner(this, new DiscountListener());
            // Act
            checkout.Scan(new Product("A"));
            checkout.Scan(new Product("A"));
            checkout.Scan(new Product("A"));
            checkout.Scan(new Product("A"));
            checkout.Scan(new Product("A"));
            checkout.Scan(new Product("A"));
            checkout.Scan(new Product("A"));

            // Assert
            Assert.AreEqual(new Money(310), _total);
        }

        [TestMethod]
        public void ScanningFiveBsGivesTotalOf120()
        {
            // Arrange
            var checkout = new Scanner(this, new DiscountListener());
            // Act
            checkout.Scan(new Product("B"));
            checkout.Scan(new Product("B"));
            checkout.Scan(new Product("B"));
            checkout.Scan(new Product("B"));
            checkout.Scan(new Product("B"));

            // Assert
            Assert.AreEqual(new Money(120), _total);
        }

        public void ItemScanned(Product item, Money currentTotal)
        {
            _total = currentTotal;
        }
    }
}
