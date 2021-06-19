using BlazorTechniques.Client.Stores.ArticleStore;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorTechniques.Client.Pages.FluxStateManagement
{
  public partial class Articles : ComponentBase, IDisposable
  {
    [Inject] public ArticleStore Store { get; set; }
    public bool ShowEdit { get; set; }
    [Parameter] public int? Id { get; set; }

    protected override void OnParametersSet()
    {
      ShowEdit = Id.HasValue;
    }

    protected override void OnInitialized()
    {
      Store.AddStateChangeListener(StateHasChanged);
    }

    public void Dispose()
    {
      Store.RemoveStateChangeListener(StateHasChanged);
    }
  }
}
