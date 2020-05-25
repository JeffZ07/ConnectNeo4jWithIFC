namespace PushXml2Neo4j
{
  partial class Form1
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
      this.XmlPath = new System.Windows.Forms.Label();
      this.FilePathBox = new System.Windows.Forms.TextBox();
      this.FilePathBtn = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // XmlPath
      // 
      this.XmlPath.AutoSize = true;
      this.XmlPath.Location = new System.Drawing.Point(32, 63);
      this.XmlPath.Name = "XmlPath";
      this.XmlPath.Size = new System.Drawing.Size(59, 12);
      this.XmlPath.TabIndex = 4;
      this.XmlPath.Text = "Xml Path:";
      // 
      // FilePathBox
      // 
      this.FilePathBox.Location = new System.Drawing.Point(118, 59);
      this.FilePathBox.Name = "FilePathBox";
      this.FilePathBox.Size = new System.Drawing.Size(504, 21);
      this.FilePathBox.TabIndex = 5;
      // 
      // FilePathBtn
      // 
      this.FilePathBtn.Location = new System.Drawing.Point(639, 59);
      this.FilePathBtn.Name = "FilePathBtn";
      this.FilePathBtn.Size = new System.Drawing.Size(87, 21);
      this.FilePathBtn.TabIndex = 6;
      this.FilePathBtn.Text = "Assign";
      this.FilePathBtn.UseVisualStyleBackColor = true;
      this.FilePathBtn.Click += new System.EventHandler(this.FilePathBtn_Click_1);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(118, 144);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(608, 35);
      this.button1.TabIndex = 7;
      this.button1.Text = "Publish";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click_1);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(758, 235);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.FilePathBtn);
      this.Controls.Add(this.FilePathBox);
      this.Controls.Add(this.XmlPath);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label XmlPath;
    private System.Windows.Forms.TextBox FilePathBox;
    private System.Windows.Forms.Button FilePathBtn;
    private System.Windows.Forms.Button button1;
  }
}

