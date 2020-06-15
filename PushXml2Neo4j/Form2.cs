using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;



namespace PushXml2Neo4j
{
  public partial class Form2 : Form
  {
    string filePath = string.Empty;
    MemoryStream m_memStream = null;
    Dictionary<string, TreeNode> m_relationDic = null;
    Dictionary<string, TreeNode> m_containDic = null;
    Dictionary<string, TreeNode> m_unNamedDic = null;
    public Form2()
    {
      InitializeComponent();
    }
    private void readxml()
    {
      if (OpenXML())
      {
        XmlDocument doc = new XmlDocument();
        doc.Load(m_memStream);
        XmlElement root = null;
        root = doc.DocumentElement;

        XmlNodeList m_entityNodes = root.SelectNodes("BuildingEntity");
        XmlNodeList m_relationNodes = root.SelectNodes("Relationship");
        XmlNodeList m_ContainNodes = root.SelectNodes("Container");
        m_unNamedDic = new Dictionary<string, TreeNode>();
        makeRelationDic(m_relationNodes);
        makeContainDic(m_ContainNodes);

        Neo4j.Model.Node neo4jNode = new Neo4j.Model.Node();


        foreach (XmlNode xmlNode in m_entityNodes)
        {
          if (xmlNode.Attributes.Count > 0)
          {
            string EleType = xmlNode.Attributes["Type"].Value;
            string ObjType;
            try
            {
               ObjType = xmlNode.Attributes["ObjectType"].Value;

            }catch
            {
              ObjType = "";
            }

            string EleId = xmlNode.Attributes[1].Value;
            if(m_unNamedDic.Keys.Contains(EleId))
            {
              m_unNamedDic[EleId].Text = EleType+": " + ObjType;
            }
     
            //Dictionary<string, object> props = new Dictionary<string, object>();
            //for (int i = 0; i < xmlNode.Attributes.Count - 1; i++)
            //{
            //  props.Add(xmlNode.Attributes[i].Name, xmlNode.Attributes[i].Value);
            //}

            if (m_relationDic.ContainsKey(EleId))
              m_relationDic[EleId].Nodes.Add(EleType + ObjType);
            if (m_containDic.ContainsKey(EleId))
              m_containDic[EleId].Nodes.Add(EleType + ObjType);
          }

          //props.Add("Entity_ID", xmlNode.Attributes["Entity_ID"].Value);
          //props.Add("IFCGLOBALLYUNIQUEID", xmlNode.Attributes["IFCGLOBALLYUNIQUEID"].Value);
          //props.Add("OwnerHistory", xmlNode.Attributes["OwnerHistory"].Value);
          //props.Add("IFCLABEL", xmlNode.Attributes["IFCLABEL"].Value);
          //props.Add("Description", xmlNode.Attributes["Description"].Value);
          //props.Add("ObjectType", xmlNode.Attributes["ObjectType"].Value);
        }



      }
    }

    private void makeRelationDic(XmlNodeList m_relationNodes)
    {
      m_relationDic = new Dictionary<string, TreeNode>();
      foreach (XmlNode relationElem in m_relationNodes)
      {
        //neo4jNode.Name = "Entity" + relationElem.Attributes[0].Value;   
        string Name = relationElem.Attributes["RelatingObject"].Value;
        Dictionary<string, object> props = new Dictionary<string, object>();
        props.Add("Entity_ID", relationElem.Attributes["Entity_ID"].Value);
        props.Add("IFCGLOBALLYUNIQUEID", relationElem.Attributes["IFCGLOBALLYUNIQUEID"].Value);
        props.Add("OwnerHistory", relationElem.Attributes["OwnerHistory"].Value);
        props.Add("IFCLABEL", relationElem.Attributes["IFCLABEL"].Value);
        props.Add("Description", relationElem.Attributes["Description"].Value);
        TreeNode treeNode = this.treeView1.Nodes.Add(Name);
        if (!m_unNamedDic.Keys.Contains(Name))
        {
          m_unNamedDic.Add(Name, treeNode);
        }
        XmlNode relationElemList = relationElem.SelectNodes("RelatedElements")[0];
        foreach (XmlNode subElem in relationElemList)
        {
          m_relationDic.Add(subElem.InnerText, treeNode);
        }

      }
    }

    private void makeContainDic(XmlNodeList m_ContainNodes)
    {
      m_containDic = new Dictionary<string, TreeNode>();
      foreach (XmlNode relationElem in m_ContainNodes)
      {
        //neo4jNode.Name = "Entity" + relationElem.Attributes[0].Value;   
        string Name = relationElem.Attributes["RelatingObject"].Value;
        Dictionary<string, object> props = new Dictionary<string, object>();
        props.Add("Entity_ID", relationElem.Attributes["Entity_ID"].Value);
        props.Add("IFCGLOBALLYUNIQUEID", relationElem.Attributes["IFCGLOBALLYUNIQUEID"].Value);
        props.Add("OwnerHistory", relationElem.Attributes["OwnerHistory"].Value);
        props.Add("IFCLABEL", relationElem.Attributes["IFCLABEL"].Value);
        props.Add("Description", relationElem.Attributes["Description"].Value);
        TreeNode treeNode = this.treeView1.Nodes.Add(Name);
        if (!m_unNamedDic.Keys.Contains(Name))
        {
          m_unNamedDic.Add(Name, treeNode);
        }


        XmlNode relationElemList = relationElem.SelectNodes("RelatedElements")[0];
        foreach (XmlNode subElem in relationElemList)
        {
          m_containDic.Add(subElem.InnerText, treeNode);
        }

      }
    }

    private bool OpenXML()
    {
      bool result = false;
      try
      {
        Stream fileStream = File.OpenRead(FilePathBox.Text);
        MemoryStream ms = new MemoryStream();
        fileStream.CopyTo(ms);
        m_memStream = ms;
        ms.Seek(0, SeekOrigin.Begin);

        fileStream.Close();
        result = true;
      }
      catch (Exception)
      {
        result = false;
      }
      return result;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      readxml();
    }

    private void FilePathBtn_Click(object sender, EventArgs e)
    {
      bool result = false;
      using (OpenFileDialog openFileDialog = new OpenFileDialog())
      {
        openFileDialog.RestoreDirectory = true;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          //Get the path of specified file
          filePath = openFileDialog.FileName;

          string filename = openFileDialog.FileName;
          try
          {
            Stream fileStream = openFileDialog.OpenFile();
            MemoryStream ms = new MemoryStream();
            fileStream.CopyTo(ms);
            m_memStream = ms;
            ms.Seek(0, SeekOrigin.Begin);

            FilePathBox.Text = filename;
            fileStream.Close();


            result = true;
          }
          catch (Exception)
          {
            result = false;
          }
          finally
          {
            openFileDialog.Dispose();
          }

        }
      }
    }
  }
}
