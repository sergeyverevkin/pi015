#region Usings

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

    #region private const
    /// <summary>
    /// Заголовок файла для идентификации (первая строка)
    /// </summary>
    private const string MemoryFormatHeader = "MemoryFormat;1.0";
    /// <summary>
    /// Расширение файла
    /// </summary>
    private const string MemoryPostfix = ".memory";

    #endregion


    #region constructor
    /// <summary>
    /// Конструктор
    /// </summary>
    public CMemory()
    {
      SerialNumber = Guid.NewGuid().ToString("N");

      PhotoList = new CPhotoList();
    }
    #endregion

    #region properties

    /// <summary>
    /// Серийный номер памяти
    /// </summary>
    public string SerialNumber
    {
      get;
      set;
    }

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
    public CPhotoList PhotoList
    {
      get;
      private set;
    }

    #endregion

    #region public methods

    /// <summary>
    /// Загрузка состояния объекта память из файла
    /// </summary>
    /// <param name="sName"></param>
    /// <param name="sCameraSerialNumber"></param>
    /// <returns></returns>
    public bool LoadFromFile(string sName, string sCameraSerialNumber)
    {
      // загружаем память по серийному номеру камеры
      if (!h_LoadFromFile(sName + MemoryPostfix, sCameraSerialNumber))
      {
        return false;
      }
      // загружаем фотографии по серийному номеру уже загруженной памяти
      PhotoList.LoadFromFile(sName, this.SerialNumber);
      return true;
    }


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

    /// <summary>
    /// Сохранение состояния памяти
    /// </summary>
    /// <param name="sFileName"></param>
    /// <param name="sCameraSerialNumber"></param>
    public void SaveToFile(string sFileName, string sCameraSerialNumber)
    {
      h_SaveMemory(sFileName + MemoryPostfix, sCameraSerialNumber);
      PhotoList.SaveToFile(sFileName, SerialNumber);
    }

    /// <summary>
    /// Очистка памяти
    /// </summary>
    public void Format()
    {
      PhotoList.Clear();
    }

    #endregion



    #region private methods
    private bool h_LoadFromFile(string sFileName, string sCameraSerialNumber)
    {
      using (Stream pFile = File.OpenRead(sFileName)) {
        using (StreamReader pReader = new StreamReader(pFile, Encoding.UTF8)) {
          string sHeader = pReader.ReadLine();
          if (!MemoryFormatHeader.Equals(sHeader)) {
            throw new Exception(String.Format("Неизвестный формат файла: неверный заголовок {0}", sHeader));
          }
          string sFirstLine = pReader.ReadLine();
          string[] arCols = sFirstLine.Split(';');
          if (arCols.Length != 3) {
            throw new Exception(String.Format("Неизвестный формат файла: неверное число полей {0}", sFirstLine));
          }
          string sCameraSerialNumberFromFile = arCols[1];
          if (sCameraSerialNumber.Equals(sCameraSerialNumberFromFile)) {
            SerialNumber = arCols[0];
            Amount = Int32.Parse(arCols[2]);
            return true;
          }
        }
      }
      return false;
    }

    private void h_SaveMemory(string sFileName, string sCameraSerialNumber)
    {
      using (Stream pFile = File.Create(sFileName)) {
        using (StreamWriter pWriter = new StreamWriter(pFile, Encoding.UTF8)) {
          pWriter.WriteLine(MemoryFormatHeader);
          string[] arRows = { SerialNumber, sCameraSerialNumber, Amount.ToString(CultureInfo.InvariantCulture) };
          pWriter.WriteLine(String.Join(";", arRows));
        }
      }
    }

    #endregion
  }
}
