using BlazorTechniques.Shared.NotifyPropertyChanged;
using Microsoft.AspNetCore.Components;

namespace BlazorTechniques.Client.Components
{
  public partial class NotifyingUserProfileEdit : ComponentBase
  {
    [Parameter] public UserProfile UserProfile { get; set; }
  }
}
