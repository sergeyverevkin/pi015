using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.Classes
{
  public class CComment
  {
    /*
     * text
     * date
     * rating
     */
    public string Text;
    public DateTime Date;
    public List<int> Rating;

    /// <summary>
    /// Конструктор
    /// </summary>
    public CComment()
    {
      Rating = new List<int>();
    }

  }
}
