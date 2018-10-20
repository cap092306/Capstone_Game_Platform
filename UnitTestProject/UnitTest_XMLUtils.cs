using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone_Game_Platform;
using System.IO;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest_XMLUtils
    {
        [TestMethod]
        public void CreateXMLFile_TestMethod()
        {
            XMLUtils xmlUtils = new XMLUtils
            {
                Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cloud9Data.xml")
            };
            xmlUtils.DeleteXMLfile();
            bool result = xmlUtils.CreateXMLfile();
            Assert.IsTrue(result, $"Expected true if file was created");
        }

        [TestMethod]
        public void ReadXMLFile_TestMethod()
        {
            XMLUtils xmlUtils = new XMLUtils
            {
                Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cloud9Data.xml")
            };
            xmlUtils.DeleteXMLfile();
            DataSet result = xmlUtils.ReadXMLfile();
            int tblCount = result.Tables.Count;
            Assert.AreEqual(5, tblCount, $"Expects 5 tables to be in default XML file.");
        }

        [TestMethod]
        public void UpdateXMLFile_TestMethod()
        {
            XMLUtils xmlUtils = new XMLUtils
            {
                Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cloud9Data.xml")
            };
            xmlUtils.DeleteXMLfile();
            DataSet result = xmlUtils.ReadXMLfile();
            string orginalVal = result.Tables[0].Rows[0]["player_name"].ToString();
            //change the dataset
            result.Tables[0].Rows[0]["player_name"] = "Dew"; //changing from DewDrop
            result.AcceptChanges();
            //save the file
            xmlUtils.UpdateXMLfile(result);
            //clean the local varriable
            result = null;
            result = xmlUtils.ReadXMLfile();
            string savedVal = result.Tables[0].Rows[0]["player_name"].ToString();
            Assert.AreNotEqual(orginalVal, savedVal, $"Expects the new saved value to be different.");
        }
    }
}
