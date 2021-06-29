using BlazorTechniques.Client.Components.BusyOverlay;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorTechniques.Client.Pages
{
  public partial class BusyPage : ComponentBase
  {
    [Inject] public BusyOverlayService BusyOverlay { get; set; }
    [Inject] public HttpClient Http { get; set; }

    private string _message;

    protected override void OnInitialized()
    {
      
    }

    private void CancelBusy()
    {
      BusyOverlay.SetNotBusy();
    }

    private async void SetBusy()
    {
      _message = null;
      StateHasChanged();
      try
      {
        BusyOverlay.SetBusyDelay();
        var res = await Http.GetFromJsonAsync<int>($"api/busy/{2000}");
        _message = $"Busy controller was delayed for {res} ms.";
      }
      finally
      {
        BusyOverlay.SetBusyState(BusyEnum.NotBusy);
        StateHasChanged();
      }
    }

    private async void SetNotSoBusy()
    {
      _message = null;
      StateHasChanged();
      try
      {
        BusyOverlay.SetBusyDelay();
        var res = await Http.GetFromJsonAsync<int>($"api/busy/{500}");
        _message = $"Busy controller was delayed for {res} ms.";
      }
      finally
      {
        BusyOverlay.SetBusyState(BusyEnum.NotBusy);
        StateHasChanged();
      }
    }
  }
}
