using System;
using System.Data;
using NUnit.Framework;
using Capstone_Game_Platform;
using System.IO;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest_XMLUtils
    {
        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public void UpdateXMLFile_TestMethod()
        {
            XMLUtils xmlUtils = new XMLUtils
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            xmlUtils.DeleteXMLfile();
            DataSet result = xmlUtils.ReadXMLfile();
            string orginalVal = result.Tables[0].Rows[0]["char_level"].ToString();
            //change the dataset
            result.Tables[0].Rows[0]["char_level"] = "100"; //changing from 1
            result.AcceptChanges();
            //save the file
            xmlUtils.UpdateXMLfile(result);
            //clean the local varriable
            result = null;
            result = xmlUtils.ReadXMLfile();
            string savedVal = result.Tables[0].Rows[0]["char_level"].ToString();
            Assert.AreNotEqual(orginalVal, savedVal, $"Expects the new saved value to be different.");
        }

        [Test]
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

        [Test]
        public void DeleteXMLFile_TestMethod()
        {
            XMLUtils xmlUtils = new XMLUtils
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            xmlUtils.CreateXMLfile();
            Assert.IsTrue(xmlUtils.DeleteXMLfile());
        }

        [Test]
        public void DeleteXMLFile_False_TestMethod()
        {
            XMLUtils xmlUtils = new XMLUtils
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            xmlUtils.DeleteXMLfile();
            Assert.IsFalse(xmlUtils.DeleteXMLfile());
        }

        [Test]
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
