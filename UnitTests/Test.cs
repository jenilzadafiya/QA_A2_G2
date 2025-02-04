using NUnit.Framework;
using QA_A2_G2;

namespace UnitTests
{
    [TestFixture]
    public class ProductTests
    {
        // ================================================
        // Jenil's Tests (ProdID + IncreaseStock)
        // ================================================
        [Test]
        public void ProdID_SetValidValue_NoException()
        {
            var product = new Product(10, "Laptop", 1000m, 50);
            Assert.That(() => product.ProdID = 50000, Throws.Nothing);
        }

        [Test]
        public void ProdID_SetBelowMin_ThrowsException()
        {
            var product = new Product(10, "Laptop", 1000m, 50);
            Assert.That(() => product.ProdID = 4, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void ProdID_SetAboveMax_ThrowsException()
        {
            var product = new Product(10, "Laptop", 1000m, 50);
            Assert.That(() => product.ProdID = 50001, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void IncreaseStock_ValidAmount_UpdatesStock()
        {
            var product = new Product(10, "Laptop", 1000m, 50);
            product.IncreaseStock(10);
            Assert.That(product.StockAmount, Is.EqualTo(60));
        }

        [Test]
        public void IncreaseStock_ExceedMax_ThrowsException()
        {
            var product = new Product(10, "Laptop", 1000m, 500000);
            Assert.That(() => product.IncreaseStock(1), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void IncreaseStock_ZeroAmount_NoChange()
        {
            var product = new Product(10, "Laptop", 1000m, 50);
            product.IncreaseStock(0);
            Assert.That(product.StockAmount, Is.EqualTo(50));
        }

        // ================================================
        // Precious's Tests (ProdName + DecreaseStock)
        // ================================================
        [Test]
        public void ProdName_SetValidName_NoException()
        {
            var product = new Product(10, "Phone", 500m, 100);
            Assert.That(() => product.ProdName = "Smartphone", Throws.Nothing);
        }

        [Test]
        public void ProdName_SetEmptyName_ThrowsException()
        {
            var product = new Product(10, "Phone", 500m, 100);
            Assert.That(() => product.ProdName = "", Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ProdName_SetSpecialCharacters_Allowed()
        {
            var product = new Product(10, "Phone", 500m, 100);
            Assert.That(() => product.ProdName = "Product#123", Throws.Nothing);
        }

        [Test]
        public void DecreaseStock_ValidAmount_UpdatesStock()
        {
            var product = new Product(10, "Phone", 500m, 100);
            product.DecreaseStock(10);
            Assert.That(product.StockAmount, Is.EqualTo(90));
        }

        [Test]
        public void DecreaseStock_BelowMin_ThrowsException()
        {
            var product = new Product(10, "Phone", 500m, 5);
            Assert.That(() => product.DecreaseStock(1), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void DecreaseStock_ZeroAmount_NoChange()
        {
            var product = new Product(10, "Phone", 500m, 100);
            product.DecreaseStock(0);
            Assert.That(product.StockAmount, Is.EqualTo(100));
        }

        // ================================================
        // Meet's Tests (ItemPrice + StockAmount)
        // ================================================
        [Test]
        public void ItemPrice_SetValidValue_NoException()
        {
            var product = new Product(10, "Tablet", 300m, 75);
            Assert.That(() => product.ItemPrice = 5000m, Throws.Nothing);
        }

        [Test]
        public void ItemPrice_SetBelowMin_ThrowsException()
        {
            var product = new Product(10, "Tablet", 300m, 75);
            Assert.That(() => product.ItemPrice = 4.99m, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void ItemPrice_SetAboveMax_ThrowsException()
        {
            var product = new Product(10, "Tablet", 300m, 75);
            Assert.That(() => product.ItemPrice = 5001m, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void StockAmount_SetValidValue_NoException()
        {
            var product = new Product(10, "Tablet", 300m, 75);
            Assert.That(() => product.StockAmount = 100, Throws.Nothing);
        }

        [Test]
        public void StockAmount_SetBelowMin_ThrowsException()
        {
            var product = new Product(10, "Tablet", 300m, 75);
            Assert.That(() => product.StockAmount = 4, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void StockAmount_SetAboveMax_ThrowsException()
        {
            var product = new Product(10, "Tablet", 300m, 75);
            Assert.That(() => product.StockAmount = 500001, Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
