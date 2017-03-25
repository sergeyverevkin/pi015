namespace WindowsFormsApplication1
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.button5 = new System.Windows.Forms.Button();
      this.button6 = new System.Windows.Forms.Button();
      this.labX = new System.Windows.Forms.Label();
      this.labY = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.btnDown = new System.Windows.Forms.Button();
      this.btnRight = new System.Windows.Forms.Button();
      this.btnLeft = new System.Windows.Forms.Button();
      this.btnUp = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.labDirection = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.button2);
      this.groupBox1.Controls.Add(this.button1);
      this.groupBox1.Location = new System.Drawing.Point(25, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(200, 100);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Игра";
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(26, 56);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(127, 31);
      this.button2.TabIndex = 3;
      this.button2.Text = "Стоп";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(26, 19);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(127, 31);
      this.button1.TabIndex = 2;
      this.button1.Text = "Старт";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.button5);
      this.groupBox2.Controls.Add(this.button6);
      this.groupBox2.Location = new System.Drawing.Point(260, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(200, 100);
      this.groupBox2.TabIndex = 5;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Автообновление";
      // 
      // button5
      // 
      this.button5.Location = new System.Drawing.Point(26, 56);
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size(127, 31);
      this.button5.TabIndex = 3;
      this.button5.Text = "Стоп";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new System.EventHandler(this.button5_Click);
      // 
      // button6
      // 
      this.button6.Location = new System.Drawing.Point(26, 19);
      this.button6.Name = "button6";
      this.button6.Size = new System.Drawing.Size(127, 31);
      this.button6.TabIndex = 2;
      this.button6.Text = "Старт";
      this.button6.UseVisualStyleBackColor = true;
      this.button6.Click += new System.EventHandler(this.button6_Click);
      // 
      // labX
      // 
      this.labX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.labX.ForeColor = System.Drawing.SystemColors.HotTrack;
      this.labX.Location = new System.Drawing.Point(559, 29);
      this.labX.Name = "labX";
      this.labX.Size = new System.Drawing.Size(60, 23);
      this.labX.TabIndex = 6;
      this.labX.Text = "-";
      // 
      // labY
      // 
      this.labY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.labY.ForeColor = System.Drawing.SystemColors.HotTrack;
      this.labY.Location = new System.Drawing.Point(559, 59);
      this.labY.Name = "labY";
      this.labY.Size = new System.Drawing.Size(60, 27);
      this.labY.TabIndex = 7;
      this.labY.Text = "-";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(466, 39);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(14, 13);
      this.label1.TabIndex = 8;
      this.label1.Text = "X";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(466, 67);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(14, 13);
      this.label2.TabIndex = 9;
      this.label2.Text = "Y";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.btnDown);
      this.groupBox3.Controls.Add(this.btnRight);
      this.groupBox3.Controls.Add(this.btnLeft);
      this.groupBox3.Controls.Add(this.btnUp);
      this.groupBox3.Location = new System.Drawing.Point(625, 12);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(177, 110);
      this.groupBox3.TabIndex = 6;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Управление";
      // 
      // btnDown
      // 
      this.btnDown.Location = new System.Drawing.Point(58, 69);
      this.btnDown.Name = "btnDown";
      this.btnDown.Size = new System.Drawing.Size(51, 31);
      this.btnDown.TabIndex = 5;
      this.btnDown.Tag = "4";
      this.btnDown.Text = "Вниз";
      this.btnDown.UseVisualStyleBackColor = true;
      this.btnDown.Click += new System.EventHandler(this.btnTurn_Click);
      // 
      // btnRight
      // 
      this.btnRight.Location = new System.Drawing.Point(113, 43);
      this.btnRight.Name = "btnRight";
      this.btnRight.Size = new System.Drawing.Size(55, 31);
      this.btnRight.TabIndex = 4;
      this.btnRight.Tag = "3";
      this.btnRight.Text = "Вправо";
      this.btnRight.UseVisualStyleBackColor = true;
      this.btnRight.Click += new System.EventHandler(this.btnTurn_Click);
      // 
      // btnLeft
      // 
      this.btnLeft.Location = new System.Drawing.Point(6, 43);
      this.btnLeft.Name = "btnLeft";
      this.btnLeft.Size = new System.Drawing.Size(46, 31);
      this.btnLeft.TabIndex = 3;
      this.btnLeft.Tag = "1";
      this.btnLeft.Text = "Влево";
      this.btnLeft.UseVisualStyleBackColor = true;
      this.btnLeft.Click += new System.EventHandler(this.btnTurn_Click);
      // 
      // btnUp
      // 
      this.btnUp.Location = new System.Drawing.Point(58, 18);
      this.btnUp.Name = "btnUp";
      this.btnUp.Size = new System.Drawing.Size(51, 31);
      this.btnUp.TabIndex = 2;
      this.btnUp.Tag = "2";
      this.btnUp.Text = "Вверх";
      this.btnUp.UseVisualStyleBackColor = true;
      this.btnUp.Click += new System.EventHandler(this.btnTurn_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(466, 94);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(75, 13);
      this.label3.TabIndex = 10;
      this.label3.Text = "Направление";
      // 
      // labDirection
      // 
      this.labDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.labDirection.ForeColor = System.Drawing.SystemColors.HotTrack;
      this.labDirection.Location = new System.Drawing.Point(559, 86);
      this.labDirection.Name = "labDirection";
      this.labDirection.Size = new System.Drawing.Size(60, 27);
      this.labDirection.TabIndex = 11;
      this.labDirection.Text = "-";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(857, 139);
      this.Controls.Add(this.labDirection);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.labY);
      this.Controls.Add(this.labX);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.Label labX;
    private System.Windows.Forms.Label labY;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Button btnLeft;
    private System.Windows.Forms.Button btnUp;
    private System.Windows.Forms.Button btnRight;
    private System.Windows.Forms.Button btnDown;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label labDirection;
  }
}

