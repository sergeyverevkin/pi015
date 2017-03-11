using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;
using WcfServiceLibrary1;

namespace WCFServer
{
  public partial class ServerForm: Form
  {
    /// <summary>
    /// Хост сервиса
    /// </summary>
    private ServiceHost m_pHost;

    public ServerForm()
    {
      string sUri = "http://127.0.0.1:8081/Service1";
      string sMetaUri = "http://127.0.0.1:8081/Service1Mex";
      BasicHttpBinding pBinding =
        new BasicHttpBinding();
      pBinding.Security.Transport.ClientCredentialType = 
        HttpClientCredentialType.None;
      
      ServiceMetadataBehavior pSmb = new ServiceMetadataBehavior();
      pSmb.HttpGetEnabled = true;
      pSmb.HttpGetUrl = new Uri(sMetaUri);
      pSmb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;

      m_pHost = new ServiceHost(typeof(Service1));
      m_pHost.Description.Behaviors.Add(pSmb);
      m_pHost.AddServiceEndpoint(
        typeof(IService1), 
        pBinding, 
        sUri);
      m_pHost.AddServiceEndpoint(
        typeof(IMetadataExchange), 
        MetadataExchangeBindings.CreateMexHttpBinding(), 
        sMetaUri);

      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      button1.Enabled = false;
      button2.Enabled = true;
      if (m_pHost.State != CommunicationState.Opened)
      {
        m_pHost.Open();      
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      button1.Enabled = true;
      button2.Enabled = false;
      if (m_pHost.State == CommunicationState.Opened) {
        m_pHost.Close();
      }
    }
  }
}
