using System;

namespace Pi015.Intro.PDll
{
  /// <summary>
  /// Общесистемные утилиты
  /// </summary>
  public static class Tool
  {
    /// <summary>
    /// Получение даты и времени
    /// </summary>
    /// <returns></returns>
    public static string GetFormTitle()
    {
      if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
      {
        UserException pException = new UserException(
          "По субботам работать нельзя");
        //pException.Data["id"] = 1;
        throw pException;
      }
      return DateTime.Now.ToString();
    }
  }

  /// <summary>
  /// 
  /// </summary>
  public class UserException: Exception
  {
    public UserException(string sMessage) :
      base(sMessage)
    {
      
    }
  }

}
