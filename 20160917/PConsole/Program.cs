using System;
using Pi015.Intro.PDll;

namespace Pi015.Intro.PConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      int ii = 0;
      foreach (string sArg in args) {
        string sFormat = String.Format("Аргумент №{0}: {1}", ii++, sArg);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(sFormat);
        Console.ForegroundColor = ConsoleColor.Gray;
        sFormat = String.Format("Аргумент №{0}: {1}", ii++, sArg);
        Console.WriteLine(sFormat);
        //ii = ii + 1;
        //ii += 1;
        //ii++;
      }
      while (true) {
        ConsoleKeyInfo pKey = Console.ReadKey();
        if (pKey.KeyChar == 'a')
          break;
        if (pKey.KeyChar == 'q') {
          try {
            try {
              Console.WriteLine(Tool.GetFormTitle());
            }
            finally {
              Console.WriteLine("завершено");
            }
          }
          catch (UserException pE) {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Ошибка: {0}", pE.Message);
            // throw;
          }
          catch (Exception pE) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка: {0}", pE.Message);
            // throw;
          }

        }

      }
    }
  }
}
