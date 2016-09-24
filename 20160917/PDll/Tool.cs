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
      return DateTime.Now.ToString();
    }
  }
}
