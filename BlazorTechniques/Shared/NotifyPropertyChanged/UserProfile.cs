using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTechniques.Shared.NotifyPropertyChanged
{
  public class UserProfile : NotifyingObject
  {
    private int _id;
    private string _name;
    private string _email;

    public int Id
    {
      get => _id;
      set => SetProperty(ref _id, value);
    }
    public string Name
    {
      get => _name;
      set => SetProperty(ref _name, value);
    }
    public string Email
    {
      get => _email;
      set => SetProperty(ref _email, value);
    }
  }
}
