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
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            xmlUtils.DeleteXMLfile();
            bool result = xmlUtils.CreateXMLfile();
            Assert.IsTrue(result, $"Expected true if file was created");
        }

        [TestMethod]
        public void CreateXMLFile_False_TestMethod()
        {
            XMLUtils xmlUtils = new XMLUtils
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            xmlUtils.DeleteXMLfile();
            xmlUtils.CreateXMLfile();
            bool result = xmlUtils.CreateXMLfile();
            Assert.IsFalse(result, $"Excepected false file has already been created");
        }

        [TestMethod]
        public void CreateXMLFile_Exception_TestMethod()
        {
            Exception expectedExcetpion = null;
            try
            {
                XMLUtils xmlUtils = new XMLUtils
                {
                    FilePath = ""
                };
                xmlUtils.DeleteXMLfile();
                bool result = xmlUtils.CreateXMLfile();
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }
            Assert.IsNotNull(expectedExcetpion);
        }

        [TestMethod]
        public void ReadXMLFile_TestMethod()
        {
            XMLUtils xmlUtils = new XMLUtils
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            xmlUtils.DeleteXMLfile();
            DataSet result = xmlUtils.ReadXMLfile();
            int tblCount = result.Tables.Count;
            Assert.AreEqual(5, tblCount, $"Expects 5 tables to be in default XML file.");
        }

        [TestMethod]
        public void ReadXMLFile_Exception_TestMethod()
        {
            Exception expectedExcetpion = null;
            try
            {
                XMLUtils xmlUtils = new XMLUtils
                {
                    FilePath = ""
                };
                DataSet result = xmlUtils.ReadXMLfile();
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }
            Assert.IsNotNull(expectedExcetpion);
        }

        [TestMethod]
        public void UpdateXMLFile_TestMethod()
        {
            XMLUtils xmlUtils = new XMLUtils
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
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

        [TestMethod]
        public void UpdateXMLFile_Exception_TestMethod()
        {
            Exception expectedExcetpion = null;
            try
            {
                XMLUtils xmlUtils = new XMLUtils
                {
                    FilePath = ""
                };
                xmlUtils.DeleteXMLfile();
                DataSet result = new DataSet();
                xmlUtils.UpdateXMLfile(result);
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }
            Assert.IsNotNull(expectedExcetpion);
        }

        [TestMethod]
        public void DeleteXMLFile_TestMethod()
        {
            XMLUtils xmlUtils = new XMLUtils
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            Assert.IsTrue(xmlUtils.DeleteXMLfile());
        }

        [TestMethod]
        public void DeleteXMLFile_False_TestMethod()
        {
            XMLUtils xmlUtils = new XMLUtils
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            xmlUtils.DeleteXMLfile();
            Assert.IsFalse(xmlUtils.DeleteXMLfile());
        }

        [TestMethod]
        public void ValidateXMLFile_TestMethod()
        {
            XMLUtils xmlUtils = new XMLUtils
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            xmlUtils.DeleteXMLfile();
            Assert.IsTrue(xmlUtils.ValidateXmlFile());
        }
    }
}
