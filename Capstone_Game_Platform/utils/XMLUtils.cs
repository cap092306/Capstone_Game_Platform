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
    /// Read XML File
    /// </summary>
    /// <param name="path">Full Path to XML File</param>
    /// <returns>DataSet</returns>
    public DataSet ReadXMLfile()
    {
        try
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Path);
            return ds;
        } catch (SecurityException ex)
        {
            throw new Exception("Can not access XML File at: "  + Path, ex);
        }
    }

    /// <summary>
    /// Save Data Set to XML file
    /// </summary>
    /// <param name="path">Full Path to XML file</param>
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

