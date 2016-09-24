using System.Windows;
using Pi015.Intro.PDll;

namespace Pi015.Intro.PWpf
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow: Window
  {
    /// <summary>
    /// .ctor
    /// </summary>
    public MainWindow()
    {
      InitializeComponent();
    }


    private void button1_Click(object sender, RoutedEventArgs e)
    {
      // MessageBox.Show("!");
      button1.Content = Tool.GetFormTitle();
    }
  }
}
