using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Classes;

namespace WindowsFormsApplication1
{
  public partial class Form1: Form
  {
    private CDB m_pDb;


    public Form1()
    {
      InitializeComponent();
      /*
      comboBox1.Items.Clear();
      foreach (EStatus pI in 
System.Enum.GetValues(typeof(EStatus))) {
        comboBox1.Items.Add(pI);
      }
       */
      m_pDb = new CDB();

      h_RefreshProfiles();
    }

    private void h_RefreshProfiles()
    {
      cbUserList.Items.Clear();
      foreach (CProfile pUser in m_pDb.ProfileList)
      {
        cbUserList.Items.Add(pUser);
      }
    }

    private void comboBox1_MouseClick(object sender, MouseEventArgs e)
    {
/*
      object pV = comboBox1.SelectedItem;
      if (pV == null) return;
      label4.Text = ((EStatus) pV).ToString();
 */
    }
  }
}
