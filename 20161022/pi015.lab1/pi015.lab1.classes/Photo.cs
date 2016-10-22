#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion


namespace pi015.lab1.classes
{
  /// <summary>
  /// Класс фотографии
  /// </summary>
  public class CPhoto
  {
    /*
        дату
        поворот (портретный, ландшафтный)
        размер
        byte[]

*/
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAt
    {
      get;
      set;
    }
    /// <summary>
    /// Название фотографии
    /// </summary>
    public string Title
    {
      get;
      set;
    }
    /// <summary>
    /// Тип поворота
    /// </summary>
    public ERotation Rotation
    {
      get;
      set;
    }
    /// <summary>
    /// Размер в Мб
    /// </summary>
    public double Size
    {
      get;
      set;
    }

    /// <summary>
    /// Содержимое в формате RAW
    /// </summary>
    public byte[] Image
    {
      get;
      set;
    }
  }
}
