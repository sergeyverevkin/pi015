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
  public class CCamera
  {

    #region constructor
    /// <summary>
    /// Конструктор
    /// </summary>
    public CCamera()
    {
      Memory = new CMemory();
    }
    #endregion

    #region properties
    /*    Название
     *    Марка
     *    Память
  */

    /// <summary>
    /// Название
    /// </summary>
    public string Name
    {
      get;
      set;
    }

    /// <summary>
    /// Марка
    /// </summary>
    public string Brand
    {
      get;
      set;
    }
    /// <summary>
    /// Память
    /// </summary>
    public CMemory Memory
    {
      get;
      private set;
    }

    #endregion

    #region public method

    /// <summary>
    /// Добавляет фотографию на память фотоаппарата, проверяя размер свободного "места"
    /// </summary>
    /// <param name="pPhoto"></param>
    public void AddPhoto(CPhoto pPhoto)
    {
      int iCount = Memory.PhotoList.Count();
      if (iCount >= Memory.Amount)
      {
        throw new Exception("Кончилось место!");
      }
      Memory.PhotoList.Add(pPhoto);
    }

    /// <summary>
    /// Получает фотографии
    /// </summary>
    /// <returns></returns>
    public IEnumerable<CPhoto> GetPhotoList()
    {
      return Memory.PhotoList;
    } 
    
    #endregion


  }
}
