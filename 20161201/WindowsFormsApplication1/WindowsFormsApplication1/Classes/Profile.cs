using System;
using System.Collections.Generic;

namespace WindowsFormsApplication1.Classes
{
  /// <summary>
  /// Профиль пользователя
  /// </summary>
  public class CProfile
  {
    /*
     nickname
     fio
     avatar
     birthday
     reg_date
     status
     last_date
     signature 
     comment[]
     subject[]
     rank
     */
    /// <summary>
    /// Никнейм на сайте
    /// </summary>
    public string Nickname;
    /// <summary>
    /// Содержимое изображения аватара
    /// </summary>
    public byte[] Avatar;
    /// <summary>
    /// Дата регистрации
    /// </summary>
    public DateTime RegistrationDate;
    /// <summary>
    /// ФИО пользователя
    /// </summary>
    public string Fio;
    /// <summary>
    /// статус пользователя
    /// </summary>
    public EStatus Status;
    // ....
    /// <summary>
    /// Список групп
    /// </summary>
    public List<CSubject> SubjectList;
    /// <summary>
    /// Список комментариев
    /// </summary>
    public List<CComment> CommentList;

    /// <summary>
    /// .ctor
    /// </summary>
    public CProfile()
    {
      CommentList = new List<CComment>();
      SubjectList = new List<CSubject>();
    }

    #region Overrides of Object

    /// <summary>
    /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </returns>
    public override string ToString()
    {
      return Nickname;
    }

    #endregion
  }
}
