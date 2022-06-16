using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Virtual_Flash_Cards.GUI.Commands
{
  public static class ApplicationCommands
  {
    public static RoutedCommand Quit { get; }

    static ApplicationCommands()
    {
      var inputGestures = new InputGestureCollection();
      inputGestures.Add(new KeyGesture(Key.Q, ModifierKeys.Control));
      Quit = new RoutedUICommand("Quit", "Quit", typeof(ApplicationCommands),
        inputGestures);
    }
  }
}
