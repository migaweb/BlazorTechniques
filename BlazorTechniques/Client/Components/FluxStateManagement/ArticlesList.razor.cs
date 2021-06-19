using BlazorTechniques.Client.Stores.ArticleStore;
using BlazorTechniques.Shared.FluxStateManagement;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorTechniques.Client.Components.FluxStateManagement
{
  public partial class ArticlesList : ComponentBase, IDisposable
  {
    [Inject] public ArticleStore ArticleStore { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    private void DeleteArticle(Article article)
    {
      ArticleStore.DeleteArticle(article);
    }

    protected override void OnInitialized()
    {
      base.OnInitialized();
      ArticleStore.AddStateChangeListener(StateHasChanged);
    }

    public void Dispose()
    {
      ArticleStore.RemoveStateChangeListener(StateHasChanged);
    }
  }
}
