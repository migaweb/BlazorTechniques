using Microsoft.AspNetCore.Components;
using System;

namespace BlazorTechniques.Client.Components.BusyOverlay
{
  public partial class BusyOverlay : ComponentBase, IDisposable
  {
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Inject]
    public BusyOverlayService BusyOverlayService { get; set; }

    protected bool IsBusy { get; set; }

    protected override void OnParametersSet()
    {
      base.OnParametersSet();
      BusyOverlayService.BusyStateChanged += HandleBusyStateChanged;
      IsBusy = BusyOverlayService.CurrentBusyState.State == BusyEnum.Busy;
    }

    private void HandleBusyStateChanged(object sender, BusyChangedEventArgs e)
    {
      IsBusy = e.BusyState == BusyEnum.Busy;
      StateHasChanged();
    }

    public void Dispose()
    {
      BusyOverlayService.BusyStateChanged -= HandleBusyStateChanged;
    }
  }
}
