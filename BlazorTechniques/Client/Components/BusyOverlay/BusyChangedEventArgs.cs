using System;

namespace BlazorTechniques.Client.Components.BusyOverlay
{
  public class BusyChangedEventArgs : EventArgs
  {
    public BusyEnum BusyState { get; set; }
  }
}
