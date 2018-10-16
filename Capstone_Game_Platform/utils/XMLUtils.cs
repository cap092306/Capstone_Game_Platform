using System;
using System.Data;
using System.Security;
using System.IO;
using System.Xml.Linq;

namespace Capstone_Game_Platform
{
    public class XMLUtils
    {
        /// <summary>
        /// Path to XML File
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Create new default XML File
        /// </summary>
        /// <param name="path"></param>
        /// <returns>bool - true if file created</returns>
        public bool CreateXMLfile()
        {
            if (!File.Exists(Path))
            {
                try
                {
                    XDocument doc = XDocument.Parse(Capstone_Game_Platform.Properties.Resources.Cloud9Data);
                    doc.Save(Path);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error occured when trying to create default XML File at: " + Path, ex);
                }
            }
            else { throw new Exception("File Exsists at: " + Path); }
        }

        /// <summary>
        /// Read XML File. If file is not found, default XML file is created and read.
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet ReadXMLfile()
        {
            if (!File.Exists(Path))
            {
                CreateXMLfile();
            }

            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Path);
                return ds;
            }
            catch (SecurityException ex)
            {
                throw new Exception("Can not access XML File at: " + Path, ex);
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
                ds.WriteXml(Path);
                return true;
            }
            catch (SecurityException ex)
            {
                throw new Exception("Can not access XML File at: " + Path, ex);
            }
        }

        /// <summary>
        /// Deletes XML File
        /// </summary>
        /// <returns>bool - true if file deleted/ false if there was no file to delete</returns>
        public bool DeleteXMLfile()
        {
            if (File.Exists(Path))
            {
                try
                {
                    File.Delete(Path);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error occured when trying to Delete XML File at: " + Path, ex);
                }
            } else
            {
                return false;
            }
        }

    }
}

