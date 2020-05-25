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
        Neo4j.Model.Node neo4jNode = new Neo4j.Model.Node();

        //XmlNode xmlNode = m_entityNodes[3];
        //neo4jNode.Name = "Entity" + xmlNode.Attributes[0].Value;
        //Dictionary<string, object> props = new Dictionary<string, object>();
        ////props.Add("ID", xmlNode.Attributes[0].Value);
        //props.Add("DateTimeStamp", System.DateTime.Now);
        //var elmid = client.Push(neo4jNode, props);
        //client.Commit();

        foreach (XmlNode xmlNode in m_entityNodes)
        {
          neo4jNode = new Neo4j.Model.Node();
          neo4jNode.Name = "Entity" + xmlNode.Attributes[0].Value;
          Dictionary<string, object> props = new Dictionary<string, object>();
          props.Add("ID", xmlNode.Attributes[0].Value);
          var elmid = client.Push(neo4jNode, props);
          client.Commit();
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
