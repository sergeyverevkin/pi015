using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace GameField
{
  /// <summary>
  /// Ячейка поля
  /// </summary>
  public class CCell
  {
    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="iX"></param>
    /// <param name="iY"></param>
    /// <param name="enCellType"></param>
    public CCell(int iX, int iY, ECellType enCellType)
    {
      X = iX;
      Y = iY;
      CellType = enCellType;
      IsExit = (enCellType == ECellType.Place);
    }

    public int X
    {
      get;
      set;
    }
    public int Y
    {
      get;
      set;
    }
    public ECellType CellType
    {
      get;
      set;
    }

    public bool IsExit
    {
      get;
      set;
    }

    #region Overrides of Object

    /// <summary>
    /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </returns>
    public override string ToString()
    {
      return String.Format("{0},{1}: {2}", X, Y, CellType);
    }

    #endregion
  }

  /// <summary>
  /// Тип ячейки
  /// </summary>
  public enum ECellType
  {
    Empty = 0,
    Wall = 1,
    Place = 2,
    Box = 3,
    Worker = 4
  }


  public class CLevel
  {
    public List<CCell> Field
    {
      get;
      private set;
    }

    /// <summary>
    /// конструктор
    /// </summary>
    public CLevel()
    {
      Field = new List<CCell>();
    }

    /// <summary>
    /// Загрузка из файла
    /// </summary>
    /// <param name="sFileName"></param>
    public void Load(string sFileName)
    {
      // 1;;;;;;;;;;1
      string[] arLines = File.ReadAllLines(sFileName);
      for (int yy = 0; yy < arLines.Length; yy++) {
        string[] arRows = arLines[yy].Split(
          new[] { ';' }, StringSplitOptions.None);
        for (int xx = 0; xx < arRows.Length; xx++) {
          ECellType enType;
          string sValue = arRows[xx];
          // xx, yy 
          switch (sValue) {
            case "":
            case "0": {
                enType = ECellType.Empty;
                break;
              }
            case "1": {
                enType = ECellType.Wall;
                break;
              }
            case "2": {
                enType = ECellType.Place;
                break;
              }
            case "3": {
                enType = ECellType.Box;
                break;
              }
            case "4": {
                enType = ECellType.Worker;
                break;
              }
            default: {
                throw new Exception("Неверный формат файла, некорректное значение " + sValue);
              }
          }
          CCell pCell = new CCell(xx, yy, enType);
          Field.Add(pCell);
        }
      }
    }

    /// <summary>
    /// Конец ли игры
    /// </summary>
    /// <returns></returns>
    public bool IsFinished()
    {
      foreach (CCell p in Field) {
        if (p.CellType != ECellType.Box)
          continue;
        if (!p.IsExit)
          return false;
      }
      return true;
    }


    public bool Move(EDirection enDirection)
    {
      CCell pWorkerCell =
        Field.FirstOrDefault(
          p => p.CellType == ECellType.Worker);
      CCell pCellOnMyWay =
        h_FindNextCell(pWorkerCell, enDirection);
      if (pCellOnMyWay == null) {
        return false;
      }
      switch (pCellOnMyWay.CellType) {
        case ECellType.Wall:
          return false;
        case ECellType.Empty:
          break;
        case ECellType.Box:
          CCell pCellOnMyWay2 =
            h_FindNextCell(pCellOnMyWay, enDirection);
          if (pCellOnMyWay2 == null) {
            return false;
          }
          if (pCellOnMyWay2.CellType == ECellType.Wall) {
            return false;
          }
          if (pCellOnMyWay2.CellType == ECellType.Box) {
            return false;
          }

          pCellOnMyWay2.CellType = ECellType.Box;
          pCellOnMyWay.CellType = ECellType.Empty;

          break;
        default:
          return false;
          break;
      }
      pCellOnMyWay.CellType = ECellType.Worker;
      pWorkerCell.CellType = ECellType.Empty;
      return true;
    }

    private CCell h_FindNextCell(CCell pCell, EDirection enDirection)
    {
      int iDeltaX = 0;
      int iDeltaY = 0;
      switch (enDirection) {
        case EDirection.Left:
          iDeltaX = -1;
          break;
        case EDirection.Right:
          iDeltaX = +1;
          break;
        case EDirection.Up:
          iDeltaY = -1;
          break;
        case EDirection.Down:
          iDeltaY = +1;
          break;
      }
      return
        Field.FirstOrDefault(p =>
          p.X == pCell.X + iDeltaX &&
          p.Y == pCell.Y + iDeltaY
          );
    }
  }

  public enum EDirection
  {
    Left,
    Right,
    Up,
    Down
  }


  public class CGame
  {
    public int Scores
    {
      get;
      set;
    }
    private List<CLevel> m_pLevels;
    private int m_iCurrentLevel = 0;

    public CGame()
    {
      m_pLevels = new List<CLevel>();
    }

    /// <summary>
    /// Добавить уровень из файла (загрузить)
    /// </summary>
    /// <param name="sFileName"></param>
    public void AddLevel(string sFileName)
    {
      CLevel pLevel = new CLevel();
      pLevel.Load(sFileName);
      m_pLevels.Add(pLevel);
    }

    /// <summary>
    /// 
    /// </summary>
    public CLevel CurrentLevel
    {
      get
      {
        try
        {
          return m_pLevels[m_iCurrentLevel];
        }
        catch
        {
          return null;
        }
      }
    }

    public bool Move(EDirection enDirection)
    {
      return CurrentLevel.Move(enDirection);
    }

    public bool IsFinished()
    {
      return CurrentLevel.IsFinished();
    }
  }
}
