using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyTests.Tests
{
    [TestClass]
    public class DatabaseTesting : BaseTest
    {

    
        [TestMethod]
        public void VerifySelectSqlQuery()
        {
            var sqlQuery = "select * from OrdersTestData";

            var dataTable = DatabaseUtils.ExecuteSelectQuery(sqlQuery);

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"Product Name : {row["productName"]}, Quanitity : {row["quantity"]}");

            }
        }

        [TestMethod]
        public void VerifyNonSelectSqlQuery()
        {

            StringBuilder builder = new StringBuilder();

            builder.Append("Insert into ");
            builder.Append("OrdersTestData (productName, quantity,price, orderDate, customerName, streetNumber, city, state, zipCode, cardNumber, cardType, expirationDate)");
            builder.Append("Values");
            builder.Append("('ScreenSaver', 5, 100, '06/04/2020', 'Saurabh Dhingra', 12, 'Gurgaon', 'Haryana', '122001', '324523452364', 'Visa', '06/06/2020')");

            string sqlQuery = builder.ToString();

            int rowsAffected = DatabaseUtils.ExecuteNonSelectQuery(sqlQuery);

            Assert.AreEqual(1, rowsAffected);

        }
    }
}
