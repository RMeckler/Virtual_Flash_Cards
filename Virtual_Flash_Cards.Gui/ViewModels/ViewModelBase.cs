using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Flash_Cards.GUI.ViewModels
{
    internal class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    internal virtual void Dispose()
    {
      
    }

    void IDisposable.Dispose()
    {
      throw new NotImplementedException();
    }
  }
}
