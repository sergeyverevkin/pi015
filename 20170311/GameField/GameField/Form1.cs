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
using System.Windows.Forms.VisualStyles;

namespace GameField
{
  public partial class Form1: Form
  {
    private const int Width = 20;
    private const int Height = 20;
    private CGame m_pGame;

    public Form1()
    {
      InitializeComponent();
      m_pGame = new CGame();
      button2.Enabled = false;
      button3.Enabled = false;
      button4.Enabled = false;
      button5.Enabled = false;
      DoubleBuffered = true;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      string[] arFiles = Directory.GetFiles("../../data", "*.csv");
      foreach (var sFilename in arFiles) {
        m_pGame.AddLevel(sFilename);
      }
      if (m_pGame.CurrentLevel != null) {
        button2.Enabled = true;
        button3.Enabled = true;
        button4.Enabled = true;
        button5.Enabled = true;
      }

      h_redraw();
    }

    private void h_redraw()
    {
      h_drawControls(m_pGame.CurrentLevel);
      h_drawField(m_pGame.CurrentLevel);
    }

    private void h_drawControls(CLevel pLevel)
    {
      const int Width = 20;
      const int Height = 20;

      panel1.SuspendLayout();
      try {
        //panel1.Controls.Clear();
        foreach (CCell pCell in pLevel.Field) {
          Control pControl = h_GetInCell(pCell);
          if (pControl == null) {
            pControl = new Button();
            // - для поиска по элементам управления
            pControl.Tag = pCell;
            // для "прямого" поиска
            pCell.Container = pControl;

            pControl.Parent = panel1;
            pControl.Width = Width;
            pControl.Height = Height;
            pControl.Left = pCell.X * Width;
            pControl.Top = pCell.Y * Height;
          }
          pControl.BackColor = h_GetCellColor(pCell);
        }
      }
      finally {
        panel1.ResumeLayout(true);
      }
    }

    private void h_drawField(CLevel pLevel)
    {
      pictureBoxField.SuspendLayout();
      try {
        Bitmap bmp = new Bitmap(pictureBoxField.Width, pictureBoxField.Height);
        using (Graphics g = Graphics.FromImage(bmp)) {
          g.Clear(Color.White);

          IEnumerable<CCell> pCellsNotWorker = pLevel.Field.Where(p=> p.CellType != ECellType.Worker);
          foreach (CCell pCell in pCellsNotWorker) {
            Color pColor = h_GetCellColor(pCell);
            SolidBrush pBrush = new SolidBrush(pColor);
            g.FillEllipse(pBrush, pCell.X*Width, pCell.Y*Height, Width, Height);
          }
          IEnumerable<CCell> pCellsWhereWorker = 
            pLevel.Field.Where(p => p.CellType == ECellType.Worker);
          foreach (CCell pCell in pCellsWhereWorker) {
            Color pColor = h_GetCellColor(pCell);
            SolidBrush pBrush = new SolidBrush(pColor);
            g.FillEllipse(pBrush, pCell.X * Width - 4, pCell.Y * Height - 4, Width + 4, Height + 4);
          }
          pictureBoxField.Image = bmp;
        }
      }
      finally {
        pictureBoxField.Invalidate();
        pictureBoxField.ResumeLayout(true);
      }
    }

    private Color h_GetCellColor(CCell pCell)
    {
      Color backColor = Color.Goldenrod;
      if (pCell.IsExit) {
        backColor = Color.Goldenrod;
      }
      else {
        switch (pCell.CellType) {
          case ECellType.Wall:
            backColor = Color.Gray;
            break;
          case ECellType.Empty:
            backColor = Color.WhiteSmoke;
            break;
          case ECellType.Box:
            backColor = Color.Green;
            break;
          case ECellType.Worker:
            backColor = Color.DarkRed;
            break;
        }
      }
      return backColor;
    }

    private Control h_GetInCell(CCell pCell)
    {
      if (pCell.Container != null)
        return (pCell.Container as Control);
      foreach (Control pC in panel1.Controls) {
        if (pC.Tag == null)
          continue;
        var pInCell = pC.Tag as CCell;
        if (pInCell == null)
          continue;
        if (pInCell.X == pCell.X && pInCell.Y == pCell.Y) {
          return pC;
        }
      }
      return null;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      EDirection enDirection = EDirection.Up;
      h_Move(enDirection);
    }

    private void h_Move(EDirection enDirection)
    {
      if (m_pGame.Move(enDirection)) {
        if (m_pGame.IsFinished()) {
          button1.ForeColor = Color.Red;
        }
      }
      h_redraw();
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

    //private void pictureBoxField_Paint(object sender, PaintEventArgs e)
    //{
    //  try
    //  {
    //    foreach (CCell pCell in m_pGame.CurrentLevel.Field)
    //    {
    //      Color pColor = h_GetCellColor(pCell);
    //      SolidBrush pBrush = new SolidBrush(pColor);
    //      e.Graphics.FillEllipse(pBrush, pCell.X*Width, pCell.Y*Height, Width, Height);
    //    }
    //  }
    //  finally
    //  {
    //    // panel1.ResumeLayout(true);
    //  }
    //}
  }
}
