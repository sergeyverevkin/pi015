using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  public partial class Form1: Form
  {
    private Timer m_pRefreshTimer;
    private GameModel m_pGame; 

    public Form1()
    {
      InitializeComponent();
      m_pGame = new GameModel();

      m_pRefreshTimer = new Timer();
      m_pRefreshTimer.Interval = 500;
      m_pRefreshTimer.Tick += m_pTimer_Tick;
    }

    void m_pTimer_Tick(object sender, EventArgs e)
    {
      // Если командовать игрой самостоятельно:
      // 1. Ждем цикла игры
      // 2. Несколько игроков "ломают" логику
      // m_pGame.Tick();
      labDirection.Text = m_pGame.Direction.ToString();
      CPosition pPos = m_pGame.Position;
      labX.Text = String.Format("{0}", pPos.X);
      labY.Text = String.Format("{0}", pPos.Y);
      Application.DoEvents();
    }

    private void button6_Click(object sender, EventArgs e)
    {
      m_pRefreshTimer.Start();

    }

    private void button1_Click(object sender, EventArgs e)
    {
      m_pGame.Start();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      m_pGame.Stop();
    }

    private void button5_Click(object sender, EventArgs e)
    {
      m_pRefreshTimer.Stop();
    }

    private void btnTurn_Click(object sender, EventArgs e)
    {
      string sTag = (string) ((sender as Control).Tag);
      int iTag = Int32.Parse(sTag);
      switch (iTag)
      {
        case 1:
          m_pGame.Turn(EDirection.West);
          break;
        case 2:
          m_pGame.Turn(EDirection.North);
          break;
        case 3:
          m_pGame.Turn(EDirection.East);
          break;
        case 4:
          m_pGame.Turn(EDirection.South);
          break;
      }
    }
  }
}
