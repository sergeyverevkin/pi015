using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pi015.Intro.PWindowsForms
{
  public partial class Form1: Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      h_CheckEmpty();
    }

    private void h_CheckEmpty()
    {
      if (String.IsNullOrEmpty(txtTaskList.Text))
      {
        txtTaskList.BackColor = Color.FromArgb(150, 93, 93);
      }
      else
      {
        txtTaskList.BackColor = Color.White;
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      /* MessageBox.Show("!"); */
      Text = 
        // <имя объекта>.<имя метода>()
        Pi015.Intro.PDll.Tool.GetFormTitle();
    }
  }
}
