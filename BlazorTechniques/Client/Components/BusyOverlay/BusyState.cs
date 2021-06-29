using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTechniques.Client.Components.BusyOverlay
{
  public class BusyState
  {
    public BusyEnum State { get; init; }

    public BusyState(BusyEnum busyState)
    {
      State = busyState;
    }
  }
}
