using System;
using System.Drawing;
using System.Threading;
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
      string sFieldValue = txtTaskList.Text;
      bool bStart = sFieldValue.StartsWith("123",
        StringComparison.CurrentCultureIgnoreCase);
      bool bContains = sFieldValue.Contains("234");
      DateTime dtNow = DateTime.Now;
      DayOfWeek dowToday = dtNow.DayOfWeek;
      bool bOddDay = (int)dowToday % 2 == 0;

      if (bStart && bContains && !bOddDay) // И
      {
        txtTaskList.BackColor = Color.Red;
      }
      if (bStart || bContains) // ИЛИ
      {

      }
      if (!bStart && !bContains) // НЕ 1 И НЕ 2 
      {

      }
      if (bStart && (bContains || bOddDay)) // И (1 ИЛИ 2)
      {

      }
      // И (1 ИЛИ 2)
      if (bStart) {
        if (bContains || bOddDay) {

        }
        else {
          // ...
        }
      }

      Color backColor;
      switch (dowToday) {
        case DayOfWeek.Monday: 
            backColor = Color.Blue;
            Color backColor2 = Color.Blue;
            button1.BackColor = backColor2;
          break;
        case DayOfWeek.Saturday:
            backColor = Color.Blue;
            Color backColor3 = Color.Blue;
            button1.BackColor = backColor3;
          break;
        case DayOfWeek.Sunday:
          backColor = Color.Brown;
          break;
        default:
          backColor = Color.Wheat;
          break;
      }
      button1.BackColor = backColor;


      if (String.IsNullOrEmpty(sFieldValue))
        txtTaskList.BackColor = Color.FromArgb(150, 93, 93);
      else
        txtTaskList.BackColor = Color.White;

      txtTaskList.BackColor = 
        String.IsNullOrEmpty(sFieldValue) 
        ? Color.FromArgb(150, 93, 93) 
        : Color.White;


      txtTaskList.BackColor =
        String.IsNullOrEmpty(sFieldValue)
        ? Color.FromArgb(150, 93, 93)
        : (
          sFieldValue.Length > 10
          ? Color.White
          : Color.DarkGreen);


      int iFunctionResult =
        (h_F1())
        ? h_F2()
        : 0;



      // loops
      for (int ii = 0; ii < 20; ii++) {
        button1.BackColor = Color.FromArgb(ii * 10, ii, ii * 10);
        Thread.Sleep(50);
        Application.DoEvents();
      }
      /*
      for (; true; Thread.Sleep(100))
      {
        Application.DoEvents();
      }
      */
      int[] arInt = { 10, 20, 30, 40 };
      foreach (int iInt in arInt) {
        Thread.Sleep(iInt);
      }

      int ii = 0;
      while (ii < 10)
      {
        if (ii == 3) 
          continue;
        if (ii > 2)
          break;
        //...
      }

    }

    private int h_F2()
    {
      return DateTime.Now.Minute;
    }

    private bool h_F1()
    {
      return true;
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
