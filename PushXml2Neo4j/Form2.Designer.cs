namespace PushXml2Neo4j
{
  partial class Form2
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.treeView1 = new System.Windows.Forms.TreeView();
      this.button1 = new System.Windows.Forms.Button();
      this.FilePathBtn = new System.Windows.Forms.Button();
      this.FilePathBox = new System.Windows.Forms.TextBox();
      this.XmlPath = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // treeView1
      // 
      this.treeView1.Location = new System.Drawing.Point(71, 116);
      this.treeView1.Name = "treeView1";
      this.treeView1.Size = new System.Drawing.Size(628, 851);
      this.treeView1.TabIndex = 0;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(131, 61);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(608, 35);
      this.button1.TabIndex = 11;
      this.button1.Text = "Show";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // FilePathBtn
      // 
      this.FilePathBtn.Location = new System.Drawing.Point(652, 20);
      this.FilePathBtn.Name = "FilePathBtn";
      this.FilePathBtn.Size = new System.Drawing.Size(87, 21);
      this.FilePathBtn.TabIndex = 10;
      this.FilePathBtn.Text = "Assign";
      this.FilePathBtn.UseVisualStyleBackColor = true;
      this.FilePathBtn.Click += new System.EventHandler(this.FilePathBtn_Click);
      // 
      // FilePathBox
      // 
      this.FilePathBox.Location = new System.Drawing.Point(131, 20);
      this.FilePathBox.Name = "FilePathBox";
      this.FilePathBox.Size = new System.Drawing.Size(504, 21);
      this.FilePathBox.TabIndex = 9;
      // 
      // XmlPath
      // 
      this.XmlPath.AutoSize = true;
      this.XmlPath.Location = new System.Drawing.Point(45, 24);
      this.XmlPath.Name = "XmlPath";
      this.XmlPath.Size = new System.Drawing.Size(59, 12);
      this.XmlPath.TabIndex = 8;
      this.XmlPath.Text = "Xml Path:";
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(857, 993);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.FilePathBtn);
      this.Controls.Add(this.FilePathBox);
      this.Controls.Add(this.XmlPath);
      this.Controls.Add(this.treeView1);
      this.Name = "Form2";
      this.Text = "Form2";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TreeView treeView1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button FilePathBtn;
    private System.Windows.Forms.TextBox FilePathBox;
    private System.Windows.Forms.Label XmlPath;
  }
}