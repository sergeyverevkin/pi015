using System;
using System.Threading;

namespace WindowsFormsApplication1
{

  public enum EDirection
  {
    North, West, East, South
  }

  /// <summary>
  /// Позиция
  /// </summary>
  public class CPosition
  {
    public int X;
    public int Y;

    public CPosition(int iX, int iY)
    {
      X = iX;
      Y = iY;
    }
  }

  class GameModel
  {
    private Timer m_pGameTimer;

    private int m_iWidth;
    private int m_iHeight;
    private CPosition m_pPosition;
    private EDirection m_enDirection;

    #region .ctor

    /// <summary>
    /// .ctor
    /// </summary>
    public GameModel()
    {
      m_pGameTimer = new Timer(h_GameTick);
    
      m_iWidth = 100;
      m_iHeight = 100;
      m_pPosition = new CPosition(10, 10);
    }

    #endregion

    #region public methods

    /// <summary>
    /// Старт игры
    /// </summary>
    public void Start()
    {
      TimeSpan tsStart = new TimeSpan(0, 0, 0, 0, 500);
      TimeSpan tsPeriod = new TimeSpan(0, 0, 0, 0, 500);
      m_pGameTimer.Change(tsStart, tsPeriod);
    }

    /// <summary>
    /// Остановка игры (пауза)
    /// </summary>
    public void Stop()
    {
      m_pGameTimer.Change(Timeout.Infinite, Timeout.Infinite);
    }

    /// <summary>
    /// Смена направления
    /// </summary>
    /// <param name="enDirection"></param>
    public void Turn(EDirection enDirection)
    {
      m_enDirection = enDirection;
    }

    /// <summary>
    /// Если хотим сами командовать ходом игры
    /// </summary>
    public void Tick()
    {
      h_GameTick(null);
    }

    #endregion

    #region private methods

    private void h_GameTick(object state)
    {
      lock (this)
      {
        switch (m_enDirection)
        {
          case EDirection.East:
            lock (m_pPosition)
            {
              if (m_pPosition.X == m_iWidth)
                m_pPosition.X = 0;
              m_pPosition.X++;
            }
            break;
          case EDirection.West:
            lock (m_pPosition)
            {
              if (m_pPosition.X == 0)
                m_pPosition.X = m_iWidth;
              m_pPosition.X--;
            }
            break;
          case EDirection.South:
            lock (m_pPosition)
            {
              if (m_pPosition.Y == m_iHeight)
              {
                m_pPosition.Y = 0;
              }
              else
              {
                m_pPosition.Y++;
              }
            }
            break;
          case EDirection.North:
            lock (m_pPosition)
            {
              if (m_pPosition.Y == 0)
                m_pPosition.Y = m_iWidth;
              m_pPosition.Y--;
            }
            break;
        }
      }
    }

    #endregion

    #region public properties

    public CPosition Position
    {
      get
      {
        return m_pPosition;
      }
    }
    public EDirection Direction
    {
      get
      {
        return m_enDirection;
      }
    }

    #endregion
  }
}
