using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.Classes
{
  /// <summary>
  /// Группа, в которой участвует пользователь
  /// </summary>
  public class CSubject
  {
    /*
     name
     id
     reg_date
     count
      
     */
    public string Name;
    /// <summary>
    /// Идентификатор
    /// </summary>
    public string Id;

    public DateTime RegistrationDate;
    public int Count;
  }
}
