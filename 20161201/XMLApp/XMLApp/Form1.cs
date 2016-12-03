using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLApp
{
  public partial class Form1: Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      CPhone pPhone = new CPhone();
      pPhone.ContactList.Add(
        new CContact(
          "Игорь Иванович",
          "+7 913 1212121",
          new DateTime(1990, 1, 1)));
      pPhone.ContactList.Add(
        new CContact(
          "Сергей Иванович",
          "+7 913 121221",
          new DateTime(1970, 2, 1)));

      CPhoneTool.SaveDOM("../$data/phone.xml", pPhone);
      CPhoneTool.SaveSAX("../$data/phoneSax.xml", pPhone);
      CPhoneTool.SaveXML("../$data/phoneXml.xml", pPhone);
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
      foreach (var p in pPhone.ContactList)
      {
        MessageBox.Show(p.Title);
      }
      CPhone pPhone2; 
      CPhoneTool.LoadXML("../$data/phoneXml.xml", 
        out pPhone2);
    }
  }
}
