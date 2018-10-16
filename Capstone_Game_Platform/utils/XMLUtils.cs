using System;
using System.Data;
using System.Security;
using System.IO;
using System.Xml.Linq;

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
    public void CreateXMLfile()
    {
        if (!File.Exists(Path))
        {
            try
            {
                XDocument doc = XDocument.Parse(Capstone_Game_Platform.Properties.Resources.Cloud9Data);
                doc.Save(Path);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured when trying to create default XML File at: " + Path, ex);
            }
        } else { throw new Exception("File Exsists at: " + Path); }
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
    public void UpdateXMLfile(DataSet ds)
    {
        try
        {
            ds.WriteXml(Path, XmlWriteMode.WriteSchema);
        }
        catch (SecurityException ex)
        {
            throw new Exception("Can not access XML File at: " + Path, ex);
        }
    }

    /// <summary>
    /// Deletes XML File
    /// </summary>
    public void DeleteXMLfile()
    {
        if (File.Exists(Path))
        {
            try
            {
                File.Delete(Path);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured when trying to Delete XML File at: " + Path, ex);
            }
        }
    }

}

