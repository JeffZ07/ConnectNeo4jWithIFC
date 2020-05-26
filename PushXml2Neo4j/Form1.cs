using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Neo4j;
using System.Xml;

namespace PushXml2Neo4j
{
  public partial class Form1 : Form
  {
    string filePath = string.Empty;
    MemoryStream m_memStream = null;
    Dictionary<string, PendingNode> m_relationDic = null;
    public Form1()
    {
      InitializeComponent();
    }

    private void readxml(DBClient client)
    {
      if(OpenXML())
      {
        XmlDocument doc = new XmlDocument();
        doc.Load(m_memStream);
        XmlElement root = null;
        root = doc.DocumentElement;

        XmlNodeList m_entityNodes = root.SelectNodes("BuildingEntity");
        XmlNodeList m_relationNodes = root.SelectNodes("Relationship");
        makeRelationDic(m_relationNodes, client);

        Neo4j.Model.Node neo4jNode = new Neo4j.Model.Node();


        foreach (XmlNode xmlNode in m_entityNodes)
        {
          neo4jNode = new Neo4j.Model.Node();
          string IDValue = xmlNode.Attributes[0].Value;
          neo4jNode.Name = "Entity" + IDValue;
          Dictionary<string, object> props = new Dictionary<string, object>();
          //props.Add("Entity_ID", xmlNode.Attributes[0].Value);
          //props.Add("IFCGLOBALLYUNIQUEID", xmlNode.Attributes[1].Value);
          //props.Add("OwnerHistory", xmlNode.Attributes[2].Value);
          //props.Add("IFCLABEL", xmlNode.Attributes[3].Value);
          //props.Add("ObjectType", xmlNode.Attributes[5].Value);
          props.Add("Entity_ID", xmlNode.Attributes["Entity_ID"].Value);
          props.Add("IFCGLOBALLYUNIQUEID", xmlNode.Attributes["IFCGLOBALLYUNIQUEID"].Value);
          props.Add("OwnerHistory", xmlNode.Attributes["OwnerHistory"].Value);
          props.Add("IFCLABEL", xmlNode.Attributes["IFCLABEL"].Value);
          props.Add("Description", xmlNode.Attributes["Description"].Value);
          props.Add("ObjectType", xmlNode.Attributes["ObjectType"].Value);
          var elmid = client.Push(neo4jNode, props);
          if(m_relationDic.ContainsKey(IDValue))
            client.Relate(m_relationDic[IDValue], elmid, "contain", null);
        }

        client.Commit();

      }
    }

    private void makeRelationDic(XmlNodeList m_relationNodes, DBClient client)
    {
      m_relationDic = new Dictionary<string, PendingNode>();
      foreach (XmlNode relationElem in m_relationNodes)
      {
        Neo4j.Model.Node neo4jNode = new Neo4j.Model.Node();
        neo4jNode.Name = "Entity" + relationElem.Attributes[0].Value;
        Dictionary<string, object> props = new Dictionary<string, object>();
        props.Add("Entity_ID", relationElem.Attributes["Entity_ID"].Value);
        props.Add("IFCGLOBALLYUNIQUEID", relationElem.Attributes["IFCGLOBALLYUNIQUEID"].Value);
        props.Add("OwnerHistory", relationElem.Attributes["OwnerHistory"].Value);
        props.Add("IFCLABEL", relationElem.Attributes["IFCLABEL"].Value);
        props.Add("Description", relationElem.Attributes["Description"].Value);
        var elmid = client.Push(neo4jNode, props);

        XmlNode relationElemList = relationElem.SelectNodes("RelatedElements")[0];
        foreach (XmlNode subElem in relationElemList)
        {
          m_relationDic.Add(subElem.InnerText, elmid);
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


    public void Publish(DBClient client)
    {
      //foreach (var mepNode in mepGraph.Nodes)
      //{
      //}
      Neo4j.Model.Node node = new Neo4j.Model.Node();
      node.Name = "Test";
      Dictionary<string, object> props = new Dictionary<string, object>();
      props.Add("DateTimeStamp", System.DateTime.Now);
      //var elmAbParams = npNode.GetAllProperties();
      var elmid = client.Push(node, props);

      client.Commit();
    }

    private void FilePathBtn_Click_1(object sender, EventArgs e)
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

    private void button1_Click_1(object sender, EventArgs e)
    {
      string Host = "localhost";
      double Port = 7687;
      string Username = "neo4j";
      string Password = "111";

      //var client = new Neo4jClient(new Uri(string.Format("bolt://{0}:{1}", Host, Port)), Username, Password);
      var client = new Neo4jClient(new Uri(string.Format("neo4j://{0}:{1}", Host, Port)), Username, Password);
      //Publish(client);
      readxml(client);
    }
  }
}
