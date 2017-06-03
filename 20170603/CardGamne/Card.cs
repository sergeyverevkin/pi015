using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardGamne
{
    /// <summary>
    /// Исключение для определения конца игры
    /// </summary>
    public class GameOverException : Exception { }

    public enum EValue
    {
        _6, _7, _8, _9, _B, _D, _K, _T
    }
    public enum ESuit
    {
        Черв, Крест, Пик, Буб
    }

    /// <summary>
    /// Карта
    /// </summary>
    public class Card
    {
        public ESuit Suit { get; set; }
        public EValue Value { get; set; }

        public Card(ESuit enSuit, EValue enValue)
        {
            Suit = enSuit;
            Value = enValue;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}",
                Suit, Value);
        }
    }

    /// <summary>
    /// Колода карт
    /// </summary>
    public class Deck
    {
        public List<Card> CardList { get; set; }
        private Random m_pR;
        public Deck()
        {
            m_pR = new Random();
            CardList = new List<Card>();
            h_Fill();
        }




        private void h_Fill()
        {
            CardList.Clear();
            foreach (ESuit pSuit in Enum.GetValues(typeof(ESuit)))
            {
                foreach (EValue pValue in System.Enum.GetValues(typeof(EValue)))
                {
                    var pCard = new Card(pSuit, pValue);
                    CardList.Add(pCard);
                }
            }
        }

        public void Mix()
        {
            int iCnt = CardList.Count;

            for (int ii = 0; ii < 100; ii++)
            {
                var iPos = m_pR.Next(0, iCnt);
                var pCard = CardList[iPos];
                CardList.Remove(pCard);
                CardList.Add(pCard);
            }
        }
    }

    public class Player
    {
        protected Game m_pGame;

        public List<Card> CardList { get; set; }
        public string Name { get; set; }

        public bool RightTurn { get; set; }
        public bool RightReply { get; set; }
        public bool RightFinish { get; set; }
        public bool RightTake { get; set; }

        public Player(Game pGame, string sName)
        {
            m_pGame = pGame;
            Name = sName;
            CardList = new List<Card>();
        }
    }

    public class AIPlayer : Player
    {
        private Timer m_pTimer;
        private bool m_bLock;

        public AIPlayer(Game pGame) :
            base(pGame, "Компьютер " + Guid.NewGuid().ToString("N"))
        {
            m_pTimer = new Timer(OnTimer);
            var p = new TimeSpan(0, 0, 1);
            m_pTimer.Change(p, p);
        }

        private void OnTimer(object state)
        {
            bool bLock = m_bLock;
            m_bLock = true;
            if (bLock) return;
            try
            {
                if (RightTurn)
                {
                    bool bDoTurn = false;
                    if (m_pGame.Table.Count == 0)
                    {
                        bDoTurn = true;
                    }
                    if (bDoTurn)
                    {
                        // ...
                        Card pCard = CardList[0];
                        m_pGame.TurnMaster(this, pCard);
                    }
                    else
                    {
                        if (RightFinish)
                        {
                            m_pGame.EndTurnDone();
                        }
                    }
                }
                else
                if (RightReply)
                {
                    var pUncovered =
                        m_pGame.Table.Where(p => p.Card2 == null);
                    //...
                    var pCoveredPair =
                        pUncovered.FirstOrDefault();
                    if (pCoveredPair == null)
                    {
                        return;
                    }
                    Card pCard = h_GetSuitableCard(pCoveredPair);
                    //...
                    if (pCard == null)
                    {
                        m_pGame.EndTurnTake();
                    }
                    else
                    {
                        m_pGame.TurnSlave(this, pCoveredPair, pCard);
                    }
                }
            }
            finally
            {
                m_bLock = false;
            }
        }

        private Card h_GetSuitableCard(Pair pPair)
        {
            // ...
            return CardList[0];
        }
    }


    public class Pair
    {
        public Card Card1, Card2;
        public Pair(Card pCard1)
        {
            Card1 = pCard1;
        }
        /// <summary>
        /// Может ли вторая карта стать парой для первой
        /// </summary>
        /// <param name="enMainSuit">козырная масть</param>
        /// <param name="pCard2">отбивающая карта</param>
        /// <returns></returns>
        public bool Response(ESuit enMainSuit,
            Card pCard2)
        {
            if (pCard2.Suit == Card1.Suit)
            {
                if (pCard2.Value > Card1.Value)
                {
                    Card2 = pCard2;
                    return true;
                }
            }
            else
            {
                if (pCard2.Suit == enMainSuit)
                {
                    Card2 = pCard2;
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return String.Format("{0} <- {1}",
                Card1, Card2);
        }

    }

    public class Game
    {
        /// <summary>
        /// Колода
        /// </summary>
        public Deck MainDeck { get; set; }
        /// <summary>
        /// Отбой
        /// </summary>
        public List<Card> Output { get; set; }
        /// <summary>
        /// Раздача
        /// </summary>
        public List<Pair> Table { get; set; }
        /// <summary>
        /// Козырь
        /// </summary>
        public Card MainCard { get; set; }
        public List<Player> PlayerList { get; set; }
        /// <summary>
        /// Кто ходит
        /// </summary>
        public int Master { get; set; }
        /// <summary>
        /// Кому ходит
        /// </summary>
        public int Slave { get; set; }


        public Game()
        {
            MainDeck = new Deck();
            PlayerList = new List<Player>();
            Output = new List<Card>();
            Table = new List<Pair>();
            PlayerList.Add(new Player(this, "Петр"));
            PlayerList.Add(new AIPlayer(this));
        }

        public void StartGame()
        {
            MainDeck.Mix();
            h_GetCards();
            Card pMainCard = GetNextCard();
            if (pMainCard == null)
            {
                throw new GameOverException();
            }
            MainCard = pMainCard;
            MainDeck.CardList.Insert(0, pMainCard);

            Master = 0;
            Slave = h_GetNextSide(Master);

            h_SetDefaultRights();
        }

        private void h_SetDefaultRights()
        {
            h_SetUserRights(Master,
                            bRightTurn: true,
                            bRightReply: false,
                            bRightFinish: false,
                            bRightTake: false);
            h_SetUserRights(Slave,
                bRightTurn: false,
                bRightReply: false,
                bRightFinish: false,
                bRightTake: false);
        }

        private void h_SetUserRights(
            int iIndexPlayer,
            bool bRightTurn,
            bool bRightReply,
            bool bRightFinish,
            bool bRightTake)
        {
            PlayerList[iIndexPlayer].RightTurn = bRightTurn;
            PlayerList[iIndexPlayer].RightFinish = bRightFinish;
            PlayerList[iIndexPlayer].RightTake = bRightTake;
            PlayerList[iIndexPlayer].RightReply = bRightReply;
        }

        private void h_GetCards()
        {
            bool bExists;
            do
            {
                bExists = false;
                for (int jj = 0; jj < PlayerList.Count; jj++)
                {
                    if (PlayerList[jj].CardList.Count >= 6)
                    {
                        continue;
                    }
                    bExists = true;
                    var pCard = GetNextCard();
                    if (pCard == null)
                    {
                        return;
                    }
                    lock (PlayerList[jj].CardList)
                    {
                        PlayerList[jj].CardList.Add(pCard);
                    }
                }

            } while (bExists);
        }

        private int h_GetNextSide(int iCurrent)
        {
            int jj = 0;
            int iNext = iCurrent + 1;
            do
            {
                if (iNext >= PlayerList.Count)
                    iNext = 0;
            } while (PlayerList[iNext].CardList.Count == 0);
            if (iNext == iCurrent)
            {
                throw new GameOverException();
            }
            return iNext;
        }

        private Card GetNextCard()
        {
            int iLastCard = MainDeck.CardList.Count - 1;
            if (iLastCard < 0) return null;
            var pCard = MainDeck.CardList[iLastCard];
            MainDeck.CardList.RemoveAt(iLastCard);
            return pCard;
        }




        public void EndTurnTake()
        {
            var ar = PlayerList[Slave].CardList;
            ar.AddRange(Table.Select(p => p.Card1));
            ar.AddRange(Table
                .Select(p => p.Card2)
                .Where(p => p != null));

            Table.Clear();
            // -- дораздаются карты
            h_GetCards();

            h_CheckGameOver();

            // -- определяются стороны 
            Master = h_GetNextSide(Slave);
            Slave = h_GetNextSide(Master);
            h_SetDefaultRights();
        }

        public void EndTurnDone()
        {
            if (!PlayerList[Master].RightFinish)
            {
                return;
            }

            Output.AddRange(Table.Select(p => p.Card1));
            Output.AddRange(Table.Select(p => p.Card2));

            Table.Clear();
            // -- дораздаются карты
            h_GetCards();

            h_CheckGameOver();

            // -- определяются стороны 
            Master = Slave;
            Slave = h_GetNextSide(Master);
            h_SetDefaultRights();
        }

        private void h_CheckGameOver()
        {                      
            var ar = PlayerList
                .Select(p => p.CardList.Count)
                .Where(p => p > 0);
            if (ar.Count() <= 1)
            {
                throw new GameOverException();
            }
        }

        public void TurnMaster(Player pPlayer, Card pCard)
        {
            if (!pPlayer.RightTurn) return;
            var pPair = new Pair(pCard);
            if (Table.Count > 0)
            {
                var ar1 = Table.Select(p => p.Card1);
                var ar2 = Table
                    .Select(p => p.Card2)
                    .Where(p => p != null);
                var b1 = (ar1.Any(p => pCard.Value == p.Value));
                var b2 = (ar2.Any(p => pCard.Value == p.Value));
                if (!b1 && !b2) return;
            }

            Table.Add(pPair);
            pPlayer.CardList.Remove(pCard);

            h_SetUserRights(Slave,
                bRightTurn: false,
                bRightReply: true,
                bRightFinish: false,
                bRightTake: true);


        }

        public void TurnSlave(Player pPlayer,
            Pair pPair, Card pCard)
        {
            if (!pPlayer.RightReply) return;
            var pTablePair = Table.FirstOrDefault(p => p == pPair);
            if (pTablePair.Response(
                MainCard.Suit,
                pCard))
            {
                pPlayer.CardList.Remove(pCard);
            }
            // PlayerList[Master].RightTurn

            bool bUncovered =
                Table.Any(p => p.Card2 == null);
            if (!bUncovered)
            {
                PlayerList[Master].RightFinish = true;
                PlayerList[Slave].RightTake = false;
                PlayerList[Slave].RightReply = false;
            }

        }
    }

}
