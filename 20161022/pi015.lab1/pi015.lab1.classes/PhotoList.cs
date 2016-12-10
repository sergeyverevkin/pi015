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
  /// Класс списка фотографий
  /// </summary>
  public class CPhotoList : List<CPhoto>
  {
    #region private const

    private const string PhotoFormatHeader = "PhotoFormat;1.0";
    private const string PhotoPostfix = ".photo";

    #endregion

    #region constructor

    /// <summary>
    /// Конструктор
    /// </summary>
    public CPhotoList()
    {
    }

    #endregion

    #region public methods

    /// <summary>
    /// Сохранение всех объектов в файлах
    /// </summary>
    /// <param name="sFileNamePrefix"></param>
    /// <param name="sSerialNumber"></param>
    public void SaveToFile(string sFileNamePrefix, string sSerialNumber)
    {
      h_SavePhotoList(sFileNamePrefix + PhotoPostfix, sSerialNumber);
    }

    /// <summary>
    /// Загрузка данных из файла по серийному номеру "памяти" (родителя)
    /// </summary>
    /// <param name="sName"></param>
    /// <param name="sSerialNumber"></param>
    public void LoadFromFile(string sName, string sSerialNumber)
    {
      h_LoadFromFile(sName + PhotoPostfix, sSerialNumber);
    }

    #endregion

    #region private methods

    private void h_LoadFromFile(string sName, string sSerialNumber)
    {
      using (Stream pFile = File.OpenRead(sName))
      {
        using (StreamReader pReader = new StreamReader(pFile, Encoding.UTF8))
        {
          string sHeader = pReader.ReadLine();
          if (!PhotoFormatHeader.Equals(sHeader))
          {
            throw new Exception(String.Format("Неизвестный формат файла: {0}", sHeader));
          }
          // читаем в цикле до конца файла
          while (!pReader.EndOfStream)
          {
            string sLine = pReader.ReadLine();
            string[] arCols = sLine.Split(';');
            if (arCols.Length != 5)
            {
              throw new Exception(String.Format("Неизвестный формат файла: неверное число полей {0}", sHeader));
            }
            string sSerialNumberOwner = arCols[4];
            if (sSerialNumber.Equals(sSerialNumberOwner))
            {
              CPhoto pPhoto = new CPhoto();
              pPhoto.Title = arCols[0];
              // ....
              // заполняем остальную часть данных
              Add(pPhoto);
            }
          }
        }
      }
    }

    private void h_SavePhotoList(string sFileName, string sSerialNumber)
    {
      using (Stream pFile = File.Create(sFileName))
      {
        using (StreamWriter pWriter = new StreamWriter(pFile, Encoding.UTF8))
        {
          pWriter.WriteLine(PhotoFormatHeader);

          foreach (CPhoto pPhoto in this)
          {
            string[] arCols =
            {
              pPhoto.Title,
              pPhoto.CreatedAt.ToLongDateString(),
              pPhoto.Rotation.ToString(),
              pPhoto.Size.ToString(CultureInfo.InvariantCulture),
              sSerialNumber
            };
            pWriter.WriteLine(String.Join(";", arCols));
          }
        }
      }
    }

    #endregion

  }
}
