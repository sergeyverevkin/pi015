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
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="sTitle"></param>
    /// <param name="sPhone"></param>
    /// <param name="dtBorn"></param>
    public CContact(string sTitle, string sPhone, DateTime dtBorn): this()
    {
      Title = sTitle;
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
      get;
      set;
    }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Phone
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
