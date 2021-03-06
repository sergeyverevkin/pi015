﻿namespace XMLApp
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
      this.button2 = new System.Windows.Forms.Button();
      this.panTop = new System.Windows.Forms.Panel();
      this.panLeft = new System.Windows.Forms.Panel();
      this.lvList = new System.Windows.Forms.ListView();
      this.colNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panRight = new System.Windows.Forms.Panel();
      this.panBottom = new System.Windows.Forms.Panel();
      this.btnAdd = new System.Windows.Forms.Button();
      this.chFilterJan = new System.Windows.Forms.CheckBox();
      this.chFilterFeb = new System.Windows.Forms.CheckBox();
      this.btnEdit = new System.Windows.Forms.Button();
      this.panTop.SuspendLayout();
      this.panLeft.SuspendLayout();
      this.panRight.SuspendLayout();
      this.panBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(33, 41);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Visible = false;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(33, 12);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 1;
      this.button2.Text = "button2";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Visible = false;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // panTop
      // 
      this.panTop.Controls.Add(this.panLeft);
      this.panTop.Controls.Add(this.panRight);
      this.panTop.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panTop.Location = new System.Drawing.Point(0, 0);
      this.panTop.Name = "panTop";
      this.panTop.Size = new System.Drawing.Size(551, 198);
      this.panTop.TabIndex = 2;
      // 
      // panLeft
      // 
      this.panLeft.Controls.Add(this.lvList);
      this.panLeft.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panLeft.Location = new System.Drawing.Point(0, 0);
      this.panLeft.Name = "panLeft";
      this.panLeft.Size = new System.Drawing.Size(440, 198);
      this.panLeft.TabIndex = 5;
      // 
      // lvList
      // 
      this.lvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNum,
            this.colName,
            this.colPhone});
      this.lvList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvList.FullRowSelect = true;
      this.lvList.GridLines = true;
      this.lvList.Location = new System.Drawing.Point(0, 0);
      this.lvList.MultiSelect = false;
      this.lvList.Name = "lvList";
      this.lvList.Size = new System.Drawing.Size(440, 198);
      this.lvList.TabIndex = 0;
      this.lvList.UseCompatibleStateImageBehavior = false;
      this.lvList.View = System.Windows.Forms.View.Details;
      // 
      // colNum
      // 
      this.colNum.Text = "#";
      // 
      // colName
      // 
      this.colName.Text = "  Имя";
      this.colName.Width = 96;
      // 
      // colPhone
      // 
      this.colPhone.Text = "Номер телефона";
      this.colPhone.Width = 148;
      // 
      // panRight
      // 
      this.panRight.Controls.Add(this.btnEdit);
      this.panRight.Controls.Add(this.button1);
      this.panRight.Controls.Add(this.button2);
      this.panRight.Dock = System.Windows.Forms.DockStyle.Right;
      this.panRight.Location = new System.Drawing.Point(440, 0);
      this.panRight.Name = "panRight";
      this.panRight.Size = new System.Drawing.Size(111, 198);
      this.panRight.TabIndex = 4;
      // 
      // panBottom
      // 
      this.panBottom.Controls.Add(this.chFilterFeb);
      this.panBottom.Controls.Add(this.chFilterJan);
      this.panBottom.Controls.Add(this.btnAdd);
      this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panBottom.Location = new System.Drawing.Point(0, 198);
      this.panBottom.Name = "panBottom";
      this.panBottom.Size = new System.Drawing.Size(551, 35);
      this.panBottom.TabIndex = 3;
      // 
      // btnAdd
      // 
      this.btnAdd.Location = new System.Drawing.Point(12, 6);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(75, 23);
      this.btnAdd.TabIndex = 0;
      this.btnAdd.Text = "Добавить";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // chFilterJan
      // 
      this.chFilterJan.AutoSize = true;
      this.chFilterJan.Checked = true;
      this.chFilterJan.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chFilterJan.Location = new System.Drawing.Point(120, 10);
      this.chFilterJan.Name = "chFilterJan";
      this.chFilterJan.Size = new System.Drawing.Size(137, 17);
      this.chFilterJan.TabIndex = 3;
      this.chFilterJan.Text = "Кто родился в январе";
      this.chFilterJan.UseVisualStyleBackColor = true;
      this.chFilterJan.CheckedChanged += new System.EventHandler(this.chFilterJan_CheckedChanged);
      // 
      // chFilterFeb
      // 
      this.chFilterFeb.AutoSize = true;
      this.chFilterFeb.Checked = true;
      this.chFilterFeb.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chFilterFeb.Location = new System.Drawing.Point(263, 10);
      this.chFilterFeb.Name = "chFilterFeb";
      this.chFilterFeb.Size = new System.Drawing.Size(145, 17);
      this.chFilterFeb.TabIndex = 4;
      this.chFilterFeb.Text = "Кто родился в феврале";
      this.chFilterFeb.UseVisualStyleBackColor = true;
      this.chFilterFeb.CheckedChanged += new System.EventHandler(this.chFilterJan_CheckedChanged);
      // 
      // btnEdit
      // 
      this.btnEdit.Location = new System.Drawing.Point(6, 169);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new System.Drawing.Size(93, 23);
      this.btnEdit.TabIndex = 6;
      this.btnEdit.Text = "Редактировать";
      this.btnEdit.UseVisualStyleBackColor = true;
      this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(551, 233);
      this.Controls.Add(this.panTop);
      this.Controls.Add(this.panBottom);
      this.MinimumSize = new System.Drawing.Size(475, 271);
      this.Name = "Form1";
      this.Text = "Номера телефонов";
      this.panTop.ResumeLayout(false);
      this.panLeft.ResumeLayout(false);
      this.panRight.ResumeLayout(false);
      this.panBottom.ResumeLayout(false);
      this.panBottom.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Panel panTop;
    private System.Windows.Forms.Panel panLeft;
    private System.Windows.Forms.Panel panRight;
    private System.Windows.Forms.Panel panBottom;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.ListView lvList;
    private System.Windows.Forms.ColumnHeader colNum;
    private System.Windows.Forms.ColumnHeader colName;
    private System.Windows.Forms.ColumnHeader colPhone;
    private System.Windows.Forms.CheckBox chFilterFeb;
    private System.Windows.Forms.CheckBox chFilterJan;
    private System.Windows.Forms.Button btnEdit;
  }
}

