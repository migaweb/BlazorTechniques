using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorTechniques.Shared.NotifyPropertyChanged
{
  public class NotifyingObject : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    // this method is called by the Set accessor of each property
    // The CallerMemberName attribute that is applied to the optional propertyName
    // parameter causes the property name of the caller to be substituted as an argument.
    protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    // Use instead of changing every setters like this.
    //  get => _email;
    //    set
    //    {
    //      if (_email == value) return;
    //      _email = value;
    //      NotifyPropertyChanged();
    //}
    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
      if (EqualityComparer<T>.Default.Equals(field, value)) return false;
      field = value;
      NotifyPropertyChanged(propertyName);
      return true;
    }
  }
}
