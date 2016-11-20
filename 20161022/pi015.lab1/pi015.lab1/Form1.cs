#define EXTERNAL_CAMERA

#region Usings

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using pi015.lab1.classes;

#endregion

namespace pi015.lab1
{
  public partial class Form1: Form
  {
    #region private variables

    /// <summary>
    /// Камера фото
    /// </summary>
    private CCamera m_pCamera;

    #endregion

    #region constructor

    /// <summary>
    /// .ctor
    /// </summary>
#if EXTERNAL_CAMERA
    public Form1(CCamera pCamera)
    {
      InitializeComponent();
      m_pCamera = pCamera;
    }
#else
    public Form1()
    {
      InitializeComponent();
      m_pCamera = new CCamera();
      m_pCamera.Name = "Фотоаппарат №1";
      m_pCamera.Brand = "Зенит-М";
      m_pCamera.Memory.Amount = 7;
    }
#endif
    #endregion

    #region event handlers

    private void Form1_Load(object sender, EventArgs e)
    {
      h_RefreshList();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      CPhoto pPhoto1 = new CPhoto() {
        CreatedAt = DateTime.Now,
        Title = "№ 001",
        Image = new byte[0],
        Rotation = ERotation.Landscape,
        Size = 10
      };
      CPhoto pPhoto2 = new CPhoto() {
        CreatedAt = DateTime.Now,
        Title = "№ 002",
        Image = new byte[0],
        Rotation = ERotation.Landscape,
        Size = 12
      };
      CPhoto pPhoto3 = new CPhoto() {
        CreatedAt = DateTime.Now,
        Title = "№ 003",
        Image = new byte[0],
        Rotation = ERotation.Portrait,
        Size = 8
      };
      try
      {
        m_pCamera.AddPhoto(pPhoto1);
        m_pCamera.AddPhoto(pPhoto2);
        m_pCamera.AddPhoto(pPhoto3);
      }
      catch (Exception pE)
      {
        MessageBox.Show(pE.Message);
      }
      h_RefreshList();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      string sSize = m_pCamera.Memory.GetMaxPhotoSize().ToString(
        CultureInfo.InvariantCulture);
      MessageBox.Show(String.Format(
        "Самая большая фотография имеет размер {0} Мб",
        sSize));

    }

    #endregion

    #region private methods


    //private void h_RefreshList2()
    //{
    //  CCamera pCamera = new CCamera();
    //  pCamera.Memory.Amount = 10;
    //  pCamera.AddPhoto(new CPhoto()
    //  {
    //    Title =" 12",// ...
    //  });
    //  IEnumerable<CPhoto> photoList = 
    //    pCamera.GetPhotoList();
    //  CPhoto pFirstOne = 
    //    photoList.First();
    //  MessageBox.Show(pFirstOne.Title);
    //}

    private void h_RefreshList()
    {
      //h_RefreshList2();
      listView1.Items.Clear();
      foreach (CPhoto pPhoto in m_pCamera.GetPhotoList())
      {
        ListViewItem pRow = new ListViewItem(new[]
        {
          pPhoto.Title,
          pPhoto.CreatedAt.ToString(CultureInfo.InvariantCulture),
          pPhoto.Size.ToString(CultureInfo.InvariantCulture)
        });
        listView1.Items.Add(pRow);
      }
    }

    #endregion

    private void button3_Click(object sender, EventArgs e)
    {
      string sFn = "$$" + Guid.NewGuid().ToString("N");

      m_pCamera.SaveToFile(sFn);
    }

    private void button4_Click(object sender, EventArgs e)
    {
      string[] arFiles = Directory.GetFiles(".", "$$*");
      string sWorkFile = arFiles.FirstOrDefault();
      if (String.IsNullOrEmpty(sWorkFile))
      {
        MessageBox.Show("Нет файлов для обработки (загрузки)");
        return;
      }
      // убираем дополнительное расширение найденного файла, чтобы найти базовое имя файла, 
      // от которого загружать
      string sName = Path.GetFileNameWithoutExtension(sWorkFile);
      m_pCamera.LoadFromFile(sName);
      h_RefreshList();
    }

    private void button5_Click(object sender, EventArgs e)
    {
      m_pCamera.Memory.Format();
      h_RefreshList();
    }
  }
}
