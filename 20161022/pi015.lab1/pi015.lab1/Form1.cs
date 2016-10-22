#region Usings

using System;
using System.Globalization;
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
    public Form1()
    {
      InitializeComponent();
      m_pCamera = new CCamera
      {
        Name = "Фотоаппарат №1", 
        Brand = "Зенит-М", 
        Memory =
        {
          Amount = 7
        }
      };
    }

    #endregion

    #region event handlers

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

    private void h_RefreshList()
    {
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


  }
}
