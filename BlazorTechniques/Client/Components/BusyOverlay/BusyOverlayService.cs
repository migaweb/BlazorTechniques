using System;
using System.Threading.Tasks;

namespace BlazorTechniques.Client.Components.BusyOverlay
{
  public class BusyOverlayService
  {
    public event EventHandler<BusyChangedEventArgs> BusyStateChanged;

    public BusyState CurrentBusyState { get; set; }

    private bool _waitingPeriod = false;

    public BusyOverlayService()
    {
      CurrentBusyState = new BusyState(BusyEnum.NotBusy);
    }

    public async Task SetBusyDelay()
    {
      _waitingPeriod = true;
      await Task.Delay(1000);

      if (_waitingPeriod)
      {
        SetBusyState(BusyEnum.Busy);
      }
    }

    public void SetNotBusy()
    {
      SetBusyState(BusyEnum.NotBusy);
    }

    public void SetBusyState(BusyEnum busyState)
    {
      _waitingPeriod = false;
      CurrentBusyState = new BusyState(busyState);

      var eventArgs = new BusyChangedEventArgs();
      eventArgs.BusyState = CurrentBusyState.State;
      OnBusyStateChanged(eventArgs);
    }

    protected virtual void OnBusyStateChanged(BusyChangedEventArgs e)
    {
      var handler = BusyStateChanged;

      if (handler != null)
      {
        handler(this, e);
      }
    }
  }
}
