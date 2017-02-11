using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XMLApp
{
  /// <summary>
  /// Телефон
  /// </summary>
  [XmlRoot("pHoNe")]
  public class CPhone
  {
    #region constructors

    /// <summary>
    /// .ctor
    /// </summary>
    public CPhone()
    {
      ContactList = new List<CContact>();
    }

    #endregion

    #region public properties

    /// <summary>
    /// Список контактов
    /// </summary>
    [XmlArray("lst")]
    [XmlArrayItem("coNtaCt")]
    public List<CContact> ContactList
    {
      get;
      private set;
    }

    #endregion


    #region public methods

    /// <summary>
    /// Получить данные с учетом фильтра
    /// </summary>
    /// <param name="bCheckedJan"></param>
    /// <param name="bCheckedFeb"></param>
    /// <returns></returns>
    public List<CContact> GetContactList(bool bCheckedJan, bool bCheckedFeb)
    {
      List<CContact> arResult = new List<CContact>();
      foreach (var pC in ContactList)
      {
        if (!bCheckedJan && pC.BirthDate.Month == 1)
        {
          continue;
        }
        if (!bCheckedFeb && pC.BirthDate.Month == 2)
        {
          continue;
        }
        arResult.Add(pC);
      }
      return arResult;
    }

    #endregion
    /// <summary>
    /// Получить контакт по идентификатору
    /// </summary>
    /// <param name="sGuid"></param>
    /// <returns></returns>
    public CContact GetContact(string sGuid)
    {
      foreach (CContact p in ContactList)
      {
        if (p.Id == sGuid) return p;
      }
      return null;
    }

    /// <summary>
    /// Обновление данных
    /// </summary>
    /// <param name="pContact"></param>
    public void UpdateContact(CContact pContact)
    {
      // обновление данных в источнике по pContact.Id
    }
  }

  #region Класс контактов

  public class CContact
  {
    #region Конструкторы
    /// <summary>
    /// Конструктор
    /// </summary>
    protected CContact()
    {
      Id = Guid.NewGuid().ToString("N");
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="sTitle"></param>
    /// <param name="sPhone"></param>
    /// <param name="dtBorn"></param>
    public CContact(string sTitle, string sPhone, DateTime dtBorn)
      : this()
    {
      m_sTitle = sTitle;
      Phone = sPhone;
      BirthDate = dtBorn;
    }

    #endregion


    #region публичные свойства

    /// <summary>
    /// Наименование
    /// </summary>
    // [XmlIgnore]
    // [XmlElement("titLe")]
    public string Title
    {
      get
      {
        return m_sTitle;
      }
      set
      {
        string sValue = value.Trim();
        if (sValue.Length < 3) {
          // некорректная длина
          Exception pE =
            new ArgumentException("некорректная длина");
          throw pE;
        }
        m_sTitle = value;
      }
    }
    private string m_sTitle;

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Phone
    {
      get;
      set;
    }

    /// <summary>
    /// Email
    /// </summary>
    public string Email
    {
      get;
      set;
    }
    /// <summary>
    /// Id
    /// </summary>
    public string Id
    {
      get;
      set;
    }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate
    {
      get;
      set;
    }

    #endregion
  }

  #endregion
}
