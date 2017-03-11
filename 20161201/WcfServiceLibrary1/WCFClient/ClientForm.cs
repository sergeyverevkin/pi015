using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using WCFClient.ServiceReference1;

namespace WCFClient
{
  public partial class ClientForm: Form
  {
    public ClientForm()
    {
      InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
      string sUrlService = "http://127.0.0.1:8081/Service1";
      BasicHttpBinding pBinding = new BasicHttpBinding();
      EndpointAddress pEndpointAddress = new EndpointAddress(sUrlService);
      Service1Client pClient = new ServiceReference1.Service1Client(
        pBinding,
        pEndpointAddress);
      try
      {
        textBox1.Text = pClient.GetData((int) numericUpDown1.Value);
      }
      catch (Exception pE)
      {
        textBox1.Text = "[ERROR] " + pE.Message;
      }
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }
  }
}
