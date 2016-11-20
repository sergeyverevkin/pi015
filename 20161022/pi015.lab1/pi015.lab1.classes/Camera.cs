#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;

#endregion


namespace pi015.lab1.classes
{
  /// <summary>
  /// Класс памяти
  /// </summary>
  public class CCamera
  {
    #region private const
    /// <summary>
    /// Заголовок файла для идентификации (первая строка)
    /// </summary>
    private const string CameraFormatHeader = "CameraFormat;1.0";
    /// <summary>
    /// Расширение файла
    /// </summary>
    private const string CameraPostfix = ".info";

    #endregion


    #region constructor
    /// <summary>
    /// Конструктор
    /// </summary>
    public CCamera()
    {
      SerialNumber = Guid.NewGuid().ToString("N");
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

    /// <summary>
    /// Серийный номер камеры
    /// </summary>
    public string SerialNumber
    {
      get;
      set;
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
      if (iCount >= Memory.Amount) {
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


    /// <summary>
    /// Копирование фотографий с "внешней" карты памяти
    /// </summary>
    /// <param name="pMemory"></param>
    public void CopyFromMemory(CMemory pMemory)
    {
      foreach (CPhoto pPhoto in pMemory.PhotoList) {
        AddPhoto(pPhoto);
      }
    }

    /// <summary>
    /// Сохранение всех объектов в файлах
    /// </summary>
    /// <param name="sFileNamePrefix"></param>
    public void SaveToFile(string sFileNamePrefix)
    {
      h_SaveCameraInfo(sFileNamePrefix + CameraPostfix);
      Memory.SaveToFile(sFileNamePrefix, SerialNumber);
    }

    /// <summary>
    /// Загрузка из файла первой камеры
    /// </summary>
    /// <param name="sName"></param>
    public void LoadFromFile(string sName)
    {
      h_LoadCameraInfo(sName + CameraPostfix);
      Memory.LoadFromFile(sName, SerialNumber);
    }


    #endregion

    #region private methods

    /// <summary>
    /// В более правильной реализации, здесь дописывается в файл и 
    /// обновляются записи по уникальному ключу (серийный номер).
    /// Сейчас просто пишется в файл.
    /// </summary>
    /// <param name="sFileName"></param>
    private void h_SaveCameraInfo(string sFileName)
    {
      using (Stream pFile = File.Create(sFileName))
      {
        using (StreamWriter pWriter = new StreamWriter(pFile, Encoding.UTF8))
        {
          pWriter.WriteLine(CameraFormatHeader);
          string[] arCols =
          {
            SerialNumber, Name, Brand
          };
          pWriter.WriteLine(String.Join(";", arCols));
        }
      }
    }

    private void h_LoadCameraInfo(string sName)
    {
      using (Stream pFile = File.OpenRead(sName))
      {
        using (StreamReader pReader = new StreamReader(pFile, Encoding.UTF8))
        {
          string sHeader = pReader.ReadLine();
          if (!sHeader.Equals(CameraFormatHeader))
          {
            throw new Exception(String.Format("Неизвестный формат файла: {0}", sHeader));
          }
          // нет цикла, загружаем только первую камеру
          string sLine = pReader.ReadLine();
          string[] arCols = sLine.Split(';');
          if (arCols.Length != 3)
          {
            throw new Exception(String.Format("Неизвестный формат файла: неверное число полей {0}", sHeader));
          }
          SerialNumber = arCols[0];
          Name = arCols[1];
          Brand = arCols[2];
        }
      }
    }

    #endregion
  }
}
