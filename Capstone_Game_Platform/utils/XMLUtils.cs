using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;
using System.Security;
using System.IO;


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
                File.Create(Path);
                //TBD create default XML File content
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured when trying to create default XML File at: " + Path, ex);
            }
        } else { throw new Exception("File Exsists at: " + Path); }
    }

    /// <summary>
    /// Create new XML Data Tag
    /// </summary>
    public void CreateXMLTag(string parentElement, string childElement)
    {
        //open file
        //find parent element
        //create child element
        //save file
    }

    /// <summary>
    /// Read XML File
    /// </summary>
    /// <param name="path">Full Path to XML File</param>
    /// <returns>DataSet</returns>
    public DataSet ReadXMLfile(string path)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.ReadXml(path);
            return ds;
        } catch (SecurityException ex)
        {
            throw new Exception("Can not access XML File at: "  + path, ex);
        }
    }

    /// <summary>
    /// Update XML Data Element
    /// </summary>
    /// <param name="path"></param>
    /// <param name="parentElement"></param>
    /// <param name="xmlContent"></param>
    public void UpdateXMLfile(string parentElement, string xmlContent)
    {
        //open file 
        //find parent element in file
        //write xml content
        //save file
    }

    /// <summary>
    /// Save Data Set to XML file
    /// </summary>
    /// <param name="path">Full Path to XML file</param>
    /// <param name="ds">Data Set</param>
    public void UpdateXMLfile(string path, DataSet ds)
    {
        try
        {
            ds.WriteXml(path, XmlWriteMode.WriteSchema);
        }
        catch (SecurityException ex)
        {
            throw new Exception("Can not access XML File at: " + path, ex);
        }
    }

    public void DeleteXMLfile(string path)
    {
        if (File.Exists(path))
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured when trying to Delete XML File at: " + path, ex);
            }
        }

    }
}

