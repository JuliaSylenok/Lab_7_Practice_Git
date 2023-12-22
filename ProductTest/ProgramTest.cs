using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_7;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ProductTest
{
    [TestClass]
    public class ProgramTests
    {

        [TestMethod]
        public void DisplayFoundProducts_ShouldReturnFoundProductsString_WhenProductsFound()
        {
            // Arrange
            List<Product> productList = new List<Product>
            {
                new Product("Product1", 10.0, 5, Category.Electronics),
                new Product("Product2", 20.0, 10, Category.Clothing)
            };

            // Act
            string result = Program.DisplayFoundProducts(productList);

            // Assert
            string expected = "Found products:\n";
            expected += "Product's name: Product1, Price: 10, Stock quantity: 5, Category: 0\n";
            expected += "Product's name: Product2, Price: 20, Stock quantity: 10, Category: 1\n";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DisplayFoundProducts_ShouldReturnNotFoundMessage_WhenNoProductsFound()
        {
            // Arrange
            List<Product> productList = new List<Product>();

            // Act
            string result = Program.DisplayFoundProducts(productList);

            // Assert
            string expected = "No products found.";
            Assert.AreEqual(expected, result);
        }
        //[TestMethod]
        //public void DisplayFoundProducts_WhenNoProductsFound_ReturnsNoProductsFoundString()
        //{
        //    // Arrange
        //    var productList = new List<Product>();

        //    // Act
        //    string result = Program.DisplayFoundProducts(productList);

        //    // Assert
        //    string expected = "No products found.";
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void DisplayFoundProducts_WhenProductsFound_ReturnsResultStringUsingToString()
        //{
        //    // Arrange
        //    var productList = new List<Product>
        //    {
        //        new Product("Product1", 10.0),
        //        new Product("Product2", 20.0)
        //    };

        //    // Act
        //    string result = Program.DisplayFoundProducts(productList);

        //    // Assert
        //    string expected = "Found products:\n";
        //    foreach (var product in productList)
        //    {
        //        expected += product.ToString() + "\n";
        //    }

        //    Assert.AreEqual(expected, result);
        //}
        //[TestMethod]
        //public void DisplayInformation_NoProducts_ReturnsNoProductsAdded()
        //{
        //    // Arrange
        //    var productList = new List<Product>();

        //    // Act
        //    string result = Program.DisplayInformation();

        //    // Assert
        //    Assert.AreEqual("\nProduct information:\nNo products added.\n", result);
        //}



    }
}
