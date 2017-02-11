using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLApp
{
  public partial class Form1: Form
  {
    private CPhone m_pPhone;

    public Form1()
    {
      InitializeComponent();
      m_pPhone = new CPhone();
      h_FillPhone();
      h_RefreshListview();
    }

    private void h_RefreshListview()
    {
      lvList.Items.Clear();

      bool bFormFilter = false;

      List<CContact> ar = bFormFilter 
      // запрос отфильтрованных данных от самой бизнес-модели
        ? m_pPhone.ContactList 
      // фильтрация данных осуществляется формой
        : m_pPhone.GetContactList(
          chFilterJan.Checked,
          chFilterFeb.Checked
        );;

      for (int ii = 0; ii < ar.Count; ii++) {
        CContact pContact = ar[ii];
        // фильтрация формой 
        if (bFormFilter && !h_IsFilterFits(pContact))
        {
          continue;
        }

        // #1+
        ListViewItem pItem =
          lvList.Items.Add((ii + 1).ToString(CultureInfo.InvariantCulture));
        pItem.ForeColor = Color.Peru;
        pItem.Tag = pContact.Id;

        // #2
        var pSubItem = new
          ListViewItem.ListViewSubItem();
        pSubItem.ForeColor = Color.Red;
        pSubItem.Text = pContact.Title;
        pItem.SubItems.Add(pSubItem);
        // #3
        pItem.SubItems.Add(pContact.Phone);
      }
    }

    private bool h_IsFilterFits(CContact pContact)
    {
      bool bPassed = true;
      if (pContact.BirthDate.Month == 1 && !chFilterJan.Checked)
      {
        bPassed = false;
      }
      if (pContact.BirthDate.Month == 2 && !chFilterFeb.Checked)
      {
        bPassed = false;
      }
      return bPassed;
    }

    #region not interested in



    private void button1_Click(object sender, EventArgs e)
    {
      h_FillPhone();

      CPhoneTool.SaveDOM("../$data/phone.xml", m_pPhone);
      CPhoneTool.SaveSAX("../$data/phoneSax.xml", m_pPhone);
      CPhoneTool.SaveXML("../$data/phoneXml.xml", m_pPhone);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      CPhone pPhone = new CPhone();
      CPhoneTool.LoadDOM("../$data/phone.xml", pPhone);
      foreach (var p in pPhone.ContactList) {
        MessageBox.Show(p.Title);
      }
      CPhoneTool.LoadSAX("../$data/phoneSax.xml",
        pPhone);
      foreach (var p in pPhone.ContactList) {
        MessageBox.Show(p.Title);
      }
      CPhone pPhone2;
      CPhoneTool.LoadXML("../$data/phoneXml.xml",
        out pPhone2);
    }

    #endregion



    private void h_FillPhone()
    {
      m_pPhone.ContactList.Add(
        new CContact(
          "Игорь Иванович",
          "+7 913 1212121",
          new DateTime(1990, 1, 1)));
      m_pPhone.ContactList.Add(
        new CContact(
          "Сергей Иванович",
          "+7 913 121221",
          new DateTime(1970, 2, 1)));
    }


    #region event handlers

    private void btnAdd_Click(object sender, EventArgs e)
    {
      CContact pContact = new CContact("", "", new DateTime(1980, 1, 1));
      using (ContactForm pContactForm = new ContactForm(pContact)) {
        DialogResult pResult = pContactForm.ShowDialog();
        if (pResult == DialogResult.OK) {
          // ссылку на объект передавали в форму, которая его дозаполнила
          m_pPhone.ContactList.Add(pContact);
        }
      }
    }

    #endregion

    private void chFilterJan_CheckedChanged(object sender, EventArgs e)
    {
      h_RefreshListview();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      // найти выбранную строку, взять идентификатор
      if (lvList.SelectedItems.Count == 0) return;
      ListViewItem pItem = lvList.SelectedItems[0];
      string sGuid = pItem.Tag as string;
      // получить объект по идентификатору для редактирования
      CContact pContact = m_pPhone.GetContact(sGuid);
      // передать его в форму-бланк
      using (ContactForm pContactForm = 
        new ContactForm(pContact)) {
        DialogResult pResult = 
          pContactForm.ShowDialog();
        if (pResult == DialogResult.OK) {
          m_pPhone.UpdateContact(pContact);
        }
      }
      
    }
  }
}
