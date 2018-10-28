using System;
using System.Data;
using System.Security;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Diagnostics;
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
        /// <returns>bool - true if file created</returns>
        public bool CreateXMLfile()
        {
            if (!File.Exists(FilePath))
            {
                try
                {
                    XDocument doc = XDocument.Parse(Capstone_Game_Platform.Properties.Resources.Cloud9DataXML);
                    doc.Save(FilePath);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error occured when trying to create default XML File at: " + FilePath, ex);
                }
            }
            else { throw new Exception("File Exsists at: " + FilePath); }
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
            } else
            {
                return false;
            }
        }

        public bool ValidateXmlFile()
        {
            try
            {
                StreamReader strmrStreamReader;
                strmrStreamReader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(Properties.Resources.Cloud9DataXSD));
                XmlSchema xSchema = new XmlSchema();
                xSchema = XmlSchema.Read(strmrStreamReader, null);
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(xSchema);
                settings.ValidationType = ValidationType.Schema;
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(Properties.Resources.Cloud9DataXML);
                XmlReader rdr = XmlReader.Create(new StringReader(xDoc.InnerXml), settings);
                while (rdr.Read())
                { }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}

