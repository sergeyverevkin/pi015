namespace Pi015.Intro.PWindowsForms
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
      if (disposing && (components != null)) {
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
      this.button1 = new System.Windows.Forms.Button();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.txtTaskList = new System.Windows.Forms.TextBox();
      this.treeView1 = new System.Windows.Forms.TreeView();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(238, 107);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Checked = true;
      this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBox1.Location = new System.Drawing.Point(45, 107);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(187, 17);
      this.checkBox1.TabIndex = 1;
      this.checkBox1.Text = "Использвоать верзний регистр";
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // txtTaskList
      // 
      this.txtTaskList.Location = new System.Drawing.Point(45, 12);
      this.txtTaskList.Multiline = true;
      this.txtTaskList.Name = "txtTaskList";
      this.txtTaskList.Size = new System.Drawing.Size(268, 85);
      this.txtTaskList.TabIndex = 2;
      this.txtTaskList.Text = "......";
      this.txtTaskList.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      // 
      // treeView1
      // 
      this.treeView1.Location = new System.Drawing.Point(45, 153);
      this.treeView1.Name = "treeView1";
      this.treeView1.Size = new System.Drawing.Size(268, 97);
      this.treeView1.TabIndex = 3;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(572, 262);
      this.Controls.Add(this.treeView1);
      this.Controls.Add(this.txtTaskList);
      this.Controls.Add(this.checkBox1);
      this.Controls.Add(this.button1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.TextBox txtTaskList;
    private System.Windows.Forms.TreeView treeView1;
  }
}

