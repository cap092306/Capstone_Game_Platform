﻿using System;
using System.Data;
using System.Security;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Reflection;

namespace Capstone_Game_Platform
{
    public class XMLUtils
    {
        /// <summary>
        /// Path to XML File
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Create new default XML File
        /// </summary>
        /// <param name="path"></param>
        /// <returns>bool - true if file created, false if file exists</returns>
        public bool CreateXMLfile()
        {
            if (!File.Exists(FilePath))
            {
                try
                {
                    XDocument doc = XDocument.Parse(Properties.Resources.Cloud9DataXML);
                    doc.Save(FilePath);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error occured when trying to create default XML File at: " + FilePath, ex);
                }
            }
            return false;
        }

        /// <summary>
        /// Read XML File. If file is not found, default XML file is created and read.
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet ReadXMLfile()
        {
            if (!File.Exists(FilePath))
            {
                CreateXMLfile();
            }

            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(FilePath);
                return ds;
            }
            catch (SecurityException ex)
            {
                throw new Exception("Can not access XML File at: " + FilePath, ex);
            }
        }

        /// <summary>
        /// Save Data Set to XML file
        /// </summary>
        /// <param name="ds">Data Set</param>
        /// <returns>bool - true if file writen</returns>
        public bool UpdateXMLfile(DataSet ds)
        {
            try
            {
                ds.AcceptChanges(); 
                ds.WriteXml(FilePath);
                return true;
            }
            catch (SecurityException ex)
            {
                throw new Exception("Can not access XML File at: " + FilePath, ex);
            }
        }

        /// <summary>
        /// Deletes XML File
        /// </summary>
        /// <returns>bool - true if file deleted/ false if there was no file to delete</returns>
        public bool DeleteXMLfile()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    File.Delete(FilePath);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error occured when trying to Delete XML File at: " + FilePath, ex);
                }
            } 
            return false;
        }

        /// <summary>
        /// Validates file, if no file exsists, file is created then validated
        /// </summary>
        /// <returns>Bool - returns true if file is validated</returns>
        public bool ValidateXmlFile()
        {
            if (!File.Exists(FilePath))
            {
                CreateXMLfile();
            }

            try
            {
                XmlTextReader reader = new XmlTextReader(Properties.Resources.Cloud9DataXSD);
                XmlSchema xSchema = new XmlSchema();
                xSchema = XmlSchema.Read(reader, ValidationEventHandler);
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(xSchema);
                settings.ValidationType = ValidationType.Schema;
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(FilePath);
                XmlReader rdr = XmlReader.Create(new StringReader(xDoc.InnerXml), settings);
                while (rdr.Read())
                { }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured when trying to validate XML File at: " + FilePath, ex);
            }
        }

        private static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            XmlSeverityType type = XmlSeverityType.Warning;
            if (Enum.TryParse("Error", out type))
            {
                if (type == XmlSeverityType.Error)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}

