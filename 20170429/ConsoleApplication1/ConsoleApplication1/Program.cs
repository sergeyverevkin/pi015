using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
  class CFruit
  {
    public string Name;
    public double Sugar;
    public double Water;
  }

  class CApple: CFruit
  {
    public CApple()
    {
      Name = "Apple";
      Sugar = 10;
      Water = 90;
    }
  }
  class CPineapple: CFruit
  {
    public CPineapple()
    {
      Name = "Pineapple";
      Sugar = 20;
      Water = 80;
    }
  }


  class CBucket : List<CFruit>
  {
    
  }

  internal static class MyExtentions
  {
    internal static string GetSum(this double dSum)
    {
      return String.Format("%.2f", dSum);
    }
  }


  class Program
  {

    static void Main(string[] args)
    {
      //double dSum = 1.02;
      //Console.WriteLine(dSum.GetSum());


      CBucket p = new CBucket();
      p.Add(new CApple());
      p.Add(new CApple());
      p.Add(new CApple());
      p.Add(new CApple());
      p.Add(new CApple());
      p.Add(new CPineapple());
      p.Add(new CPineapple());
      p.Add(new CPineapple());
      Console.WriteLine("В корзине {0} фруктов", p.Count());
      IEnumerable<CFruit> arFruits = p
        .Where(pElement => 
          pElement is CApple && h_Check(pElement));
      string[] arApple = p
        .Select(pElement => pElement.Name)
        .ToArray();
      CFruit pBestApple = p
        .FirstOrDefault(pElement => 
          pElement is CApple);
      if (pBestApple == null)
      {
        // 
      }

      string pO = p
        .Where(pElement => pElement is CApple)
        .Select(pElement => pElement.Name)
        .FirstOrDefault(pElement => pElement.StartsWith("App"));



      Console.ReadKey();
    }

    private static bool h_Check(CFruit pElement)
    {
      return pElement.Sugar < 10;
    }
  }
}
