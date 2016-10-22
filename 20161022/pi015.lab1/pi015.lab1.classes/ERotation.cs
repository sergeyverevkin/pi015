#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion


namespace pi015.lab1.classes
{
  /*
   * 
   * Фотоаппарат с фотографиями
   * 
   * Фотоаппарат
   *    Название
   *    Марка
   *    Память
   *             
   * Память
   *      объем (в количестве фотографии)
   *      фотографии[]
   *
   *  Фотографии
   *      дату
   *      поворот (портретный, ландшафтный)
   *      размер
   *      byte[]
   */


  /// <summary>
  /// поворот (портретный, ландшафтный)
  /// </summary>
  public enum ERotation
  {
    /// <summary>
    /// Portrait
    /// </summary>
    Portrait = 1,
    /// <summary>
    /// Landscape
    /// </summary>
    Landscape = 2,
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown = 0
  }
}
