using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class CateringTest
    {
        [TestMethod]
        public void Check_that_catering_object_is_created()
        {
            // Arrange 
            Catering catering = new Catering();

            // Act

            //Assert
            Assert.IsNotNull(catering);
        }

        [TestMethod]
        public void AddMoneyTest()
        {
            // Arrange 
            Catering catering = new Catering();

            // Act
            decimal deposit = 1;
            decimal result = catering.AddMoney(deposit);

            //Assert
            Assert.AreEqual(deposit,result);
        }

        [TestMethod]
        public void SelectProductsTest()
        {
            // Arrange 
            Catering catering = new Catering();

            // Act          
            string productIdInput = "A1";
            int quantity = 2;
            catering.CurrentBalance = 20.00M;
            decimal test = 13.00M;
            decimal result2 = catering.SelectProducts(productIdInput, quantity);

            //Assert
            Assert.AreEqual(result2, test);
        }

        //[TestMethod]
        //public void CompleteTransactionTest()
        //{
        //    // Arrange 
        //    Catering catering = new Catering();
        //    // Act
        //    Dictionary<string, int> shoppingCart = new Dictionary<string, int>();
        //    shoppingCart.Add("A1", 2);
        //    List<CateringItem> test = new List<CateringItem>();
        //    test.Add(B);
        //    test.Add("B 1.50 25");
        //    items.Add(appList);
        //    List<CateringItem> result = catering.CompleteTransaction();
        //    //Assert
        //    CollectionAssert.AreEqual(shoppingCart, result);
        //}

        [TestMethod]
        public void GetNotesTest()
        {
            // Arrange 
            Catering catering = new Catering();

            // Act
            string[] input = { "A","A1" };
            string test = "You might need extra plates.";
            string result = catering.GetNotes(input);

            //Assert
            Assert.AreEqual(test, result);
        }

        //[TestMethod]
        //public void ReceiptPrinterTest()
        //{
        //    // Arrange 
        //    Catering catering = new Catering();
        //    // Act
        //    Dictionary<string, int> shoppingCart = new Dictionary<string, int>();
        //    shoppingCart.Add("A1", 2);
        //    List<string> result = catering.ReceiptPrinter();
        //    //Assert
        //    Assert.AreEqual(test, result);
        //}

        //[TestMethod]
        //public void GetTotalTest()
        //{
        //    // Arrange 
        //    Catering catering = new Catering();

        //    // Act
        //    Dictionary<string, int> shoppingCart = new Dictionary<string, int>();
        //    shoppingCart.Add("A1", 2);


        //    string total = "Total: $1.50";
        //    string input = "Total: $1.50";

        //    string result = catering.GetTotal();

        //    //Assert
        //    Assert.AreEqual(total, result);
        //}

        //[TestMethod]
        //public void PrintChangesTest()
        //{
        //    // Arrange 
        //    Catering catering = new Catering();

        //    // Act
        //    string change = "You received (1) fifties in change";
        //    decimal CurrentBalance = 50;
        //    string result = catering.PrintChange(CurrentBalance);

        //    //Assert
        //    Assert.AreEqual(change, result);
        //}
    }
}
