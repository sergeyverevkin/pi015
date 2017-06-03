using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGamne
{
    public partial class Form1 : Form
    {
        Game m_pGame;
        Timer m_pTimer;

        public Form1()
        {
            InitializeComponent();
            m_pGame = new Game();
            m_pTimer = new Timer();
            m_pTimer.Tick += h_Tick;
            m_pTimer.Interval = 3000;
            m_pTimer.Start();
            h_Refresh();
        }

        private void h_Tick(object sender, EventArgs e)
        {
            h_Refresh();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            m_pGame.StartGame();
            h_Refresh();
        }

        private void h_Refresh()
        {
            lbPlayer1.Items.Clear();
            lock (m_pGame.PlayerList[0].CardList)
            {
                foreach (var pCard in m_pGame.PlayerList[0].CardList)
                {
                    lbPlayer1.Items.Add(pCard);
                }
            }
            lbPlayer2.Items.Clear();
            lock (m_pGame.PlayerList[1].CardList)
            {
                foreach (var pCard in m_pGame.PlayerList[1].CardList)
                {
                    lbPlayer2.Items.Add(pCard);
                }
            }
            lbDeck.Items.Clear();
            lock (m_pGame.MainDeck.CardList)
            {
                foreach (var pCard in m_pGame.MainDeck.CardList)
                {
                    lbDeck.Items.Add(pCard);
                }
            }
            lbTable.Items.Clear();
            lock (m_pGame.Table)
            {
                foreach (var pPair in m_pGame.Table)
                {
                    lbTable.Items.Add(pPair);
                }
            }
            lbReturn.Items.Clear();
            lock (m_pGame.Output)
            {
                foreach (var pCard in m_pGame.Output)
                {
                    lbReturn.Items.Add(pCard);
                }
            }

            ColorizePlayer(0, lbPlayer1);
            ColorizePlayer(1, lbPlayer2);

            
            labMainCard.Text = (m_pGame.MainCard == null) ? "нет" : m_pGame.MainCard.ToString();
        }

        private void ColorizePlayer(int iIndex, ListBox l)
        {
            if (m_pGame.Master == iIndex)
            {
                l.BackColor = Color.Bisque;
                // l.Enabled = true;
            }
            else
            {
                l.BackColor = Color.White;
                // l.Enabled = false;
            }

            if (m_pGame.Slave == iIndex)
            {
                l.BackColor = Color.Aqua;
                // l.Enabled = true;
            }
            else
            {
                l.BackColor = Color.White;
                // l.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            h_Turn(0, lbPlayer1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            h_Turn(1, lbPlayer2);

        }

        private void h_Turn(int iOwnerPlayerNum, ListBox lbPlayer)
        {
            if (lbPlayer.SelectedItem == null) return;
            var pCard = lbPlayer.SelectedItem as Card;
            if (m_pGame.Master == iOwnerPlayerNum)
            {
                m_pGame.TurnMaster(m_pGame.PlayerList[iOwnerPlayerNum],
                    pCard);
            }
            else
            if (m_pGame.Slave == iOwnerPlayerNum)
            {
                if (lbTable.SelectedItem == null) return;
                var pPair = lbTable.SelectedItem as Pair;
                m_pGame.TurnSlave(m_pGame.PlayerList[iOwnerPlayerNum],
                    pPair, pCard);
            }
            h_Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            h_Finish(0);
        }

        private void h_Finish(int iOwnerPlayerNum)
        {
            if (m_pGame.Master == iOwnerPlayerNum)
            {
                if (m_pGame.Table.Any(p => p.Card2 == null)) return;
                m_pGame.EndTurnDone();
            }
            else
            if (m_pGame.Slave == iOwnerPlayerNum)
            {
                if (!m_pGame.Table.Any(p => p.Card2 == null)) return;
                m_pGame.EndTurnTake();
            }
            h_Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            h_Finish(1);
        }
    }
}
