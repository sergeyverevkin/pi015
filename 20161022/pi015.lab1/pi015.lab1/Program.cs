#define EXTERNAL_CAMERA

#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using pi015.lab1.classes;

#endregion

namespace pi015.lab1
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void MainSequencedRun()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

#if EXTERNAL_CAMERA

      CCamera pCamera = new CCamera();
      pCamera.Name = "Фотоаппарат №1";
      pCamera.Brand = "Зенит-М";
      pCamera.Memory.Amount = 7;

      // заполнение внешней карты памяти
      CMemory pMemory = new CMemory();
      CPhoto pPhoto = new CPhoto() {
        Title = "adsf"
      };
      pMemory.PhotoList.Add(pPhoto);
      // копирование с карты памяти на внутреннюю память
      pCamera.CopyFromMemory(pMemory);




      // проверка, что есть хотя бы одна фотография во внутренней памяти
      if (!pCamera.GetPhotoList().Any())
      // pCamera.GetPhotoList().Count() == 0)
      {
        MessageBox.Show(@"Нет ни одной фотографии");
      }
      else {
        // запуск формы
        Form1 pMainForm = new Form1(pCamera);
        pMainForm.Text = "1";
        Application.Run(
          pMainForm
          );
        Form1 pMainForm2 = new Form1(pCamera);
        pMainForm2.Text = "2";
        Application.Run(
          pMainForm2
          );
      }
#else
        // запуск формы
        Form1 pMainForm = new Form1(pCamera);
        Application.Run(pMainForm);
#endif
    }


    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      CCamera pCamera = new CCamera();
      pCamera.Name = "Фотоаппарат №1";
      pCamera.Brand = "Зенит-М";
      pCamera.Memory.Amount = 7;

      // заполнение внешней карты памяти
      CMemory pMemory = new CMemory();
      CPhoto pPhoto = new CPhoto() {
        Title = "adsf"
      };
      pMemory.PhotoList.Add(pPhoto);
      // копирование с карты памяти на внутреннюю память
      pCamera.CopyFromMemory(pMemory);




      // проверка, что есть хотя бы одна фотография во внутренней памяти
      if (!pCamera.GetPhotoList().Any())
      // pCamera.GetPhotoList().Count() == 0)
      {
        MessageBox.Show(@"Нет ни одной фотографии");
      }
      else {
        // запуск формы
        Form1 pMainForm = new Form1(pCamera);
        pMainForm.Text = "Камера";
        Application.Run(
          pMainForm
          );
      }
    }
  }
}
