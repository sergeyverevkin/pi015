
using System;

namespace Pi015.ConsoleAlg
{

  #region class Program

  internal class Program
  {

    #region private static methods

    private static void Main(string[] args)
    {
      //


      // --------------------------------------
      int[] ar = new
        int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 9, 10 };
      int[] ar2 = new int[4];
      ar2[0] = 0;
      ar2[1] = 3;
      ar2[2] = 4;
      ar2[3] = 3;
      int iMod = 4 % 2; // 0


      char[] arLetters = {'а', 'е', 'и', 'о'};
      string sSentence = "Я считаю все символы-гласные!";

      Console.WriteLine(SumEven(new int[0]));
      Console.WriteLine(SumEven(new[] { 1, 2, 3, 4 }));
      Console.WriteLine(SumEven(new[] { 1, 3, 4 }));

      Console.ReadKey();
      // --------------------------------------
    }

    private static int SumEven(int[] ar)
    {
      //....
      for (; false; )
      {
        
      }
      int iSum = 0;
      for (int ii = 0; ii < ar.Length; ii++)
      {
        // 0,1,2,3
        iSum += ar[ii];
      }

      return iSum;
    }

    #endregion



  }

  #endregion


}
