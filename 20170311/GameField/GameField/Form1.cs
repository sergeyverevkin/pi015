using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;

namespace GameField
{
  public partial class Form1: Form
  {
    CGame m_pGame;

    public Form1()
    {
      InitializeComponent();
      m_pGame = new CGame();
      button2.Enabled = false;
      button3.Enabled = false;
      button4.Enabled = false;
      button5.Enabled = false;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      string[] arFiles = Directory.GetFiles("../../data", "*.csv");
      foreach (var sFilename in arFiles)
      {
        m_pGame.AddLevel(sFilename);  
      }
      if (m_pGame.CurrentLevel != null)
      {
        button2.Enabled = true;
        button3.Enabled = true;
        button4.Enabled = true;
        button5.Enabled = true;
      }

    }

    private void button2_Click(object sender, EventArgs e)
    {
      EDirection enDirection = EDirection.Up;
      h_Move(enDirection);
    }

    private void h_Move(EDirection enDirection)
    {
      if (m_pGame.Move(enDirection))
      {
        if (m_pGame.IsFinished())
        {
          button1.ForeColor = Color.Red;
        }
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      EDirection enDirection = EDirection.Right;
      h_Move(enDirection);
    }

    private void button4_Click(object sender, EventArgs e)
    {
      EDirection enDirection = EDirection.Down;
      h_Move(enDirection);

    }

    private void button5_Click(object sender, EventArgs e)
    {
      EDirection enDirection = EDirection.Left;
      h_Move(enDirection);

    }
  }
}
