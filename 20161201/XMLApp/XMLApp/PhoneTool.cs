using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XMLApp
{

  #region статический класс CPhoneTool

  /// <summary>
  /// Инструментарий телефона
  /// </summary>
  public static class CPhoneTool
  {
    #region static methods

    /// <summary>
    /// Список контактов
    /// </summary>
    public static void SaveDOM(string sFileName, CPhone pPhone)
    {
      // DOM - document object model
      XmlDocument pDocument = new XmlDocument();
      pDocument.InnerXml = "<storage/>";

      XmlElement pE = pDocument.CreateElement("phone");
      pDocument.DocumentElement.AppendChild(pE);

      foreach (CContact pC in pPhone.ContactList)
      {
        XmlElement pCNode = pDocument.CreateElement("contact");
        pE.AppendChild(pCNode);


        var pAttr = pDocument.CreateAttribute("date");
        pAttr.Value = pC.BirthDate.ToShortDateString();
        pCNode.Attributes.Append(pAttr);

        XmlElement pP1Node = pDocument.CreateElement("phone");
        pP1Node.InnerText = pC.Phone;
        pCNode.AppendChild(pP1Node);
        XmlElement pP2Node = pDocument.CreateElement("title");
        pP2Node.InnerText = pC.Title;
        pCNode.AppendChild(pP2Node);
      }
      pDocument.Save(sFileName);

    }

    public static void LoadDOM(string sFileName, CPhone pPhone)
    {
      pPhone.ContactList.Clear();
      // DOM - document object model
      XmlDocument pDocument = new XmlDocument();
      pDocument.Load(sFileName);
      XmlNode pPhoneNode = pDocument.DocumentElement
        .ChildNodes[0];
      // XPath
      XmlNodeList pT = pPhoneNode
        .SelectNodes("//phone");
      //foreach (XmlNode pN in pT) {
      //  MessageBox.Show(pN.FirstChild.Value);
      //}
    }

    /// <summary>
    /// Считывание через SAX
    /// </summary>
    /// <param name="sFileName"></param>
    /// <param name="pPhone"></param>
    public static void LoadSAX(string sFileName, CPhone pPhone)
    {
      // SAX - simple API XML
      pPhone.ContactList.Clear();
      using (Stream pStream = File.OpenRead(
        sFileName))
      {
        using (XmlReader pReader = XmlReader.Create(pStream))
        {
          pReader.Read();
          if (!pReader.ReadToFollowing("phone"))
            return;
          if (!pReader.ReadToFollowing("contact"))
            return;
          //while (pReader.NodeType != XmlNodeType.Element)
          //{
          //  pReader.Read();
          //}
          // pReader.ReadStartElement();
          while ((pReader.NodeType == XmlNodeType.Element) &&
                 pReader.Name == "contact")
          {
            CContact pC = h_ReadContact(pReader);
            pPhone.ContactList.Add(pC);
          }
          // pRea
        }
      }
    }

    private static CContact h_ReadContact(XmlReader pReader)
    {
      string sDate = pReader.GetAttribute("date");
      pReader.ReadToFollowing("phone");
      string sPhone = pReader.ReadElementString();
      pReader.ReadToFollowing("title");
      string sTitle = pReader.ReadElementString();
      var pC = new CContact(sTitle, sPhone, DateTime.Parse(sDate));
      while (pReader.NodeType != XmlNodeType.Element)
      {
        pReader.Read();
        if (pReader.NodeType == XmlNodeType.None)
        {
          break;
        }
      }
      return pC;
    }

    /// <summary>
    /// Сохранение через SAX
    /// </summary>
    /// <param name="sFileName"></param>
    /// <param name="pPhone"></param>
    public static void SaveSAX(string sFileName, CPhone pPhone)
    {
      using (Stream pStream = File.Create(
        sFileName))
      {
        XmlWriterSettings pSettings = new XmlWriterSettings()
        {
          Indent = true,
          Encoding = Encoding.GetEncoding(1251),
        };

        using (XmlWriter pWriter = XmlWriter.Create(
          pStream, pSettings))
        {
          pWriter.WriteStartDocument();
          pWriter.WriteStartElement("root");
          pWriter.WriteStartElement("phone");
          foreach (var pC in pPhone.ContactList)
          {
            pWriter.WriteStartElement("contact");
            pWriter.WriteAttributeString("date", pC.BirthDate.ToShortDateString());
            pWriter.WriteElementString("phone", pC.Phone);
            pWriter.WriteElementString("title", pC.Title);
            pWriter.WriteEndElement();
          }
          pWriter.WriteEndElement();
          pWriter.WriteEndElement();
          pWriter.WriteEndDocument();
        }
      }
    }


    /// <summary>
    /// Сохранить с помощью сериализации
    /// </summary>
    /// <param name="sFileName"></param>
    /// <param name="pPhone"></param>
    public static void SaveXML(string sFileName, CPhone pPhone)
    {
      using (Stream pStream = File.Create(
        sFileName))
      {
        XmlSerializer pX = new XmlSerializer(pPhone.GetType());
        pX.Serialize(pStream, pPhone);
      }

    }

    /// <summary>
    /// Считать из сериализации
    /// </summary>
    /// <param name="sFileName"></param>
    /// <param name="pPhone"></param>
    public static void LoadXML(string sFileName,
      out CPhone pPhone)
    {
      using (Stream pStream = File.OpenRead(
        sFileName))
      {
        XmlSerializer pX = new XmlSerializer(typeof (CPhone));
        pPhone = (CPhone) pX.Deserialize(pStream);
      }
    }

    #endregion
  }

  #endregion
}
