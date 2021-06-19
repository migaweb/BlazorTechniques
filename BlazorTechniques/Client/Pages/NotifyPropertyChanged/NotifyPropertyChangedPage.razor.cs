using BlazorTechniques.Shared.NotifyPropertyChanged;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorTechniques.Client.Pages.NotifyPropertyChanged
{
  public partial class NotifyPropertyChangedPage : ComponentBase, IDisposable
  {
    public UserProfile UserProfile { get; set; }

    protected override void OnAfterRender(bool firstRender)
    {
      base.OnAfterRender(firstRender);
      if (firstRender)
      {
        UserProfile.PropertyChanged += HandleUserProfilePropertyChanged;
      }
    }

    private void HandleUserProfilePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      StateHasChanged();
    }

    protected override void OnInitialized()
    {
      base.OnInitialized();
      UserProfile = new UserProfile { 
        Id = 1,
        Name = "Micke",
        Email = "miga02@gmail.com"
      };
    }

    public void Dispose()
    {
      UserProfile.PropertyChanged -= HandleUserProfilePropertyChanged;
    }
  }
}
