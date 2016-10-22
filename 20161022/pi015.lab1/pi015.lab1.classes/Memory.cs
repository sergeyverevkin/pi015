#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion


namespace pi015.lab1.classes
{
  /// <summary>
  /// Класс памяти
  /// </summary>
  public class CMemory
  {
    /*    Название
     *    Марка
     *    Память
  */

    #region constructor
    /// <summary>
    /// Конструктор
    /// </summary>
    public CMemory()
    {
      PhotoList = new List<CPhoto>();
    }
    #endregion

    #region properties

    /*
   * Память
   *      объем (в количестве фотографии)
   *      фотографии[]
*/

    /// <summary>
    /// Объем (количество фотографий)
    /// </summary>
    public int Amount
    {
      get;
      set;
    }

    /// <summary>
    /// Список фотографий
    /// </summary>
    public List<CPhoto> PhotoList
    {
      get;
      private set;
    }

    #endregion

    #region public methods
    /// <summary>
    /// Поиск самой большой фотографии по объему в Мб
    /// </summary>
    /// <returns></returns>
    public double GetMaxPhotoSize()
    {
      double dMax = 0;
      foreach (CPhoto pPhoto in PhotoList) {
        if (pPhoto.Size > dMax) {
          dMax = pPhoto.Size;
        }
      }
      return dMax;
    }

    #endregion
  }
}
