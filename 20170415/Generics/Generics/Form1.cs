using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Generics
{
  public class CAnimal
  {
    public int Age;
    public string GetName()
    {
      return this.GetType().FullName;
    }
  }

  [Description("Human, is a kind of animal")]
  public class CHuman: CAnimal
  {
  }

  [Description("Woman, is a kind of human")]
  public class CWoman: CHuman
  {

  }

  [Description("Man, is a kind of human")]
  public class CMan: CHuman
  {

  }


  public enum ERank
  {
    _6,
    _7,
    _8,
    _9,
    [Description("Ba")]
    B,
    D,
    K,
    T
  }

  public class CGeneric<
    TOperationType>
    // ,TType2
    // ,TType3>// : List<TOperationType>
    where TOperationType: CAnimal
    //where TType2: class
    //where TType3: new()
  {
    public List<TOperationType> MyList;
    // public List<TType2> MyList2;

    public CGeneric()
    {
      MyList = new List<TOperationType>();
    }

    public void Add(TOperationType pHuman)
    {
      Type p1 = typeof(CMan);
      Type p3 = typeof(TOperationType);
      Type p2 = pHuman.GetType();

      // p1.Attributes


      if (typeof(TOperationType) == typeof(CMan)) {
        //
      }
      if (pHuman.Age > 10)
        return;
      // string sName = pHuman.GetName();
      MyList.Add(pHuman);

      // this.GetType().GetMethod("Count").Attributes

    }

    [Description("Ba")]
    public int Count()
    {
      int iM = 1;
      h_refOperation(ref iM);
      h_outOperation(out iM);
      return MyList.Count();
    }

    private void h_refOperation(ref int iM)
    {
      iM++;
    }

    private int h_outOperation(out int iM)
    {
      iM = 1;
      return 1;
    }

    private
      Tuple<int, string, int>
      h_outOperation2(out int iM)
    {
      iM = 1;
      Tuple<int, string, int> hOutOperation2 = new Tuple<int, string, int>(1, "dsfsdf", 2);
      // hOutOperation2.Item1;
      return hOutOperation2;
    }




  }


  public delegate void fnLog(string sLog);

  public partial class Form1: Form
  {
    // CGeneric_CMan$_001
    private CGeneric<CMan> m_pMList;
    // CGeneric_CWoman$_002
    private CGeneric<CWoman> m_pFList;


    private string MyProperty 
    {
      get
      {
        return "1";
      }
    }

    private event fnLog OnLog;
    //{
    //  add
    //  {
    //    // ..
    //  }
    //  remove
    //  {
    //    // ..
    //  }
    //}


    public Form1()
    {
      InitializeComponent();
      OnLog = OnLog + OnOnLog;
    }

    private void OnOnLog(string sLog)
    {
      Debug.WriteLine(sLog);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      CMan pMan = new CMan();
      CMan pMan2 = GetName<CMan>(pMan);
      OnLog("ok");

    }

    private TInputType GetName<TInputType>(TInputType pT)
      where TInputType: CAnimal, new()
    {
      string s = pT.GetName();
      TInputType pNewMan = new TInputType();
      return pNewMan;
    }
  }
}
