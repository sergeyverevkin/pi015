using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
  class CParameter
  {
    public int Min
    {
      get;
      set;
    }
    public int Max
    {
      get;
      set;
    }
  }

  class Program
  {
    private static object SyncRoot = new object();
    private static int Value;


    static void Main(string[] args)
    {



      Thread pThread1 = new Thread(ThreadMethod);
      Thread pThread2 = new Thread(ThreadMethod);
      Thread pThread3 = new Thread(ThreadMethod);
      int iMux = 1000;
      pThread1.Name = "Thread1";
      pThread2.Name = "Thread2";
      pThread3.Name = "Thread3";
      pThread1.Start(new CParameter() {
        Min = 0,
        Max = 5 * iMux
      });
      pThread2.Start(new CParameter() {
        Min = 5 * iMux,
        Max = 10 * iMux
      });
      pThread3.Start(new CParameter() {
        Min = 10 * iMux,
        Max = 15 * iMux
      });
      Console.WriteLine("It's over");
      Console.ReadKey();
    }

    private static void ThreadMethod(object obj)
    {
      // lock (SyncRoot) {
      CParameter iParam = (CParameter)obj;
      for (int ii = iParam.Min; ii < iParam.Max; ii++) {
        // lock (SyncRoot)
        {
          Interlocked.Increment(
            ref Value);
          // Value = Value + 1;
        }
        // Console.WriteLine(ii);
      }
      //}
      Console.WriteLine("! {0} !", Value);
    }
  }
}
