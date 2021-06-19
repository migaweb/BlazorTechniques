using BlazorTechniques.Client.Stores.ArticleStore;
using BlazorTechniques.Shared.FluxStateManagement;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;

namespace BlazorTechniques.Client.Components.FluxStateManagement
{
  public partial class AddArticle : ComponentBase
  {
    [Inject] public ArticleStore ArticleStore { get; set; }

    private void AddNewArticle()
    {
      ArticleStore.AddArticle(new Article
      {
        Id = ArticleStore.Count > 0 ? ArticleStore.GetArticles().Max(e => e.Id) + 1 : 1,
        ShortDescrption = $"Random Article {DateTime.Now.Ticks}",
        MainGroupId = DateTime.Now.Millisecond,
        SubGroupId = DateTime.Now.Second
      });
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
