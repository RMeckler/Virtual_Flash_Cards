using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Virtual_Flash_Cards.GUI.View.Exam
{
  /// <summary>
  /// Interaction logic for Exam.xaml
  /// </summary>
  public partial class Exam : Window
  {
    private List<Page> _pages = new();

    public Exam()
    {
      InitializeComponent();

      _pages.Add(new ExamSettingsPage());
      _pages.Add(new ExamPage());
      _pages.Add(new ExamResultPage());


    }
    private void UpdatePage(int newPageNumber)
    {
      Frame.Navigate(_pages[0]);
      
    }

    private void Button_Next(object sender, RoutedEventArgs e)
    {
      UpdatePage(1);
    }
  }
}
