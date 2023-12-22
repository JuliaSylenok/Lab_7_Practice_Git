using Lab_7;

namespace ProductTest
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void TestAddProduct_Successful()
        {
            List<Product> productsList = new List<Product>();
            Product product = new Product("TestProduct", 10.0, 5, Category.Electronics);

            Product.AddProduct(productsList, product);

            Assert.AreEqual(1, productsList.Count);
            Assert.AreEqual("TestProduct", productsList[0].Name);
        }

        //// DeleteProduct
        ///
        [TestMethod]
        public void TestDeleteProduct_Successful()
        {
            List<Product> productsList = new List<Product>();
            Product product = new Product("TestProduct", 10.0, 5, Category.Electronics);
            productsList.Add(product);

            bool result = Product.DeleteProduct(productsList, 0);

            Assert.IsTrue(result);
            Assert.AreEqual(0, productsList.Count);
        }

        [TestMethod]
        public void TestDeleteProduct_InvalidIndex()
        {
            List<Product> productsList = new List<Product>();

            bool result = Product.DeleteProduct(productsList, 0);

            Assert.IsFalse(result);
            Assert.AreEqual(0, productsList.Count);
        }

        [TestMethod]
        public void TestDeleteProduct_EmptyList()
        {
            List<Product> productsList = new List<Product>();

            bool result = Product.DeleteProduct(productsList, 0);

            Assert.IsFalse(result);
            Assert.AreEqual(0, productsList.Count);
        }

        //// FindProductsByPrice
        ///
        [TestMethod]
        public void TestFindProductsByPrice_SingleMatch()
        {

            List<Product> productsList = new List<Product>();
            Product product1 = new Product("Product1", 10.0, 5, Category.Electronics);
            Product product2 = new Product("Product2", 15.0, 7, Category.Clothing);
            productsList.Add(product1);
            productsList.Add(product2);

            List<Product> result = Product.FindProductsByPrice(productsList, 10.0);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Product1", result[0].Name);
        }

        [TestMethod]
        public void TestFindProductsByPrice_MultipleMatches()
        {

            List<Product> productsList = new List<Product>();
            Product product1 = new Product("Product1", 10.0, 5, Category.Electronics);
            Product product2 = new Product("Product2", 10.0, 7, Category.Clothing);
            productsList.Add(product1);
            productsList.Add(product2);

            List<Product> result = Product.FindProductsByPrice(productsList, 10.0);

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void TestFindProductsByPrice_NoMatch()
        {

            List<Product> productsList = new List<Product>();
            Product product1 = new Product("Product1", 15.0, 5, Category.Electronics);
            Product product2 = new Product("Product2", 20.0, 7, Category.Clothing);
            productsList.Add(product1);
            productsList.Add(product2);

            List<Product> result = Product.FindProductsByPrice(productsList, 10.0);

            Assert.AreEqual(0, result.Count);
        }



        [TestMethod]
        public void TestFindProductsByStockQuantity_SingleMatch()
        {

            List<Product> productsList = new List<Product>();
            Product product1 = new Product("Product1", 10.0, 5, Category.Electronics);
            Product product2 = new Product("Product2", 15.0, 7, Category.Clothing);
            productsList.Add(product1);
            productsList.Add(product2);

            List<Product> result = Product.FindProductsByStockQuantity(productsList, 5);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Product1", result[0].Name);
        }

        [TestMethod]
        public void TestFindProductsByStockQuantity_MultipleMatches()
        {

            List<Product> productsList = new List<Product>();
            Product product1 = new Product("Product1", 10.0, 5, Category.Electronics);
            Product product2 = new Product("Product2", 15.0, 5, Category.Clothing);
            productsList.Add(product1);
            productsList.Add(product2);

            List<Product> result = Product.FindProductsByStockQuantity(productsList, 5);

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void TestFindProductsByStockQuantity_NoMatch()
        {

            List<Product> productsList = new List<Product>();
            Product product1 = new Product("Product1", 10.0, 7, Category.Electronics);
            Product product2 = new Product("Product2", 15.0, 8, Category.Clothing);
            productsList.Add(product1);
            productsList.Add(product2);

            List<Product> result = Product.FindProductsByStockQuantity(productsList, 5);

            Assert.AreEqual(0, result.Count);
        }


        [TestMethod]
        public void CalculateTotalValue_EmptyList_ShouldReturnZero()
        {
            // Arrange
            List<Product> emptyList = new List<Product>();

            // Act
            Product.CalculateTotalValue(emptyList);

            // Assert
            Assert.AreEqual(0, Product.TotalValue);
        }

        [TestMethod]
        public void CalculateTotalValue_SingleProduct_ShouldReturnProductTotalValue()
        {
            // Arrange
            List<Product> productList = new List<Product>
        {
            new Product("Product1", 100, 5, Category.Electronics)
        };

            // Act
            Product.CalculateTotalValue(productList);

            // Assert
            Assert.AreEqual(600, Product.TotalValue);
        }

        [TestMethod]
        public void Parse_InvalidInput_ShouldThrowArgumentException()
        {
            // Arrange
            string input = "InvalidInput";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => Product.Parse(input));
        }


        [TestMethod]
        public void TryParse_InvalidInput_ShouldReturnFalseAndNullProduct()
        {
            // Arrange
            string input = "InvalidInput";
            Product product;

            // Act
            bool result = Product.TryParse(input, out product);

            // Assert
            Assert.IsFalse(result);
            Assert.IsNull(product);
        }
        [TestMethod]
        public void Product_DefaultConstructor_ShouldSetDefaultValues()
        {
            // Arrange
            string expectedName = "Name";
            double expectedPrice = 1;
            int expectedStockQuantity = 12;
            Category expectedCategory = default(Category);

            // Act
            Product product = new Product();

            // Assert
            Assert.AreEqual(expectedName, product.Name);
            Assert.AreEqual(expectedPrice, product.Price);
            Assert.AreEqual(expectedStockQuantity, product.StockQuantity);
            Assert.AreEqual(expectedCategory, product.Category);
        }
        [TestMethod]
        public void Product_ConstructorWithNameAndPrice_ShouldSetValues()
        {
            // Arrange
            string expectedName = "TestProduct";
            double expectedPrice = 50;
            int expectedStockQuantity = 10;
            Category expectedCategory = default(Category);

            // Act
            Product product = new Product(expectedName, expectedPrice);

            // Assert
            Assert.AreEqual(expectedName, product.Name);
            Assert.AreEqual(expectedPrice, product.Price);
            Assert.AreEqual(expectedStockQuantity, product.StockQuantity);
            Assert.AreEqual(expectedCategory, product.Category);
        }

        [TestMethod]
        public void TotalValueWithTax_ShouldCalculateTotalValueWithTax()
        {
            // Arrange
            double expectedPrice = 100;
            double expectedTotalValueWithTax = expectedPrice * 1.2;

            Product product = new Product("TestProduct", expectedPrice);

            // Act
            double actualTotalValueWithTax = product.TotalValueWithTax;

            // Assert
            Assert.AreEqual(expectedTotalValueWithTax, actualTotalValueWithTax, 0.001);
        }
    }
}