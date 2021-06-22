using BlazorTechniques.Client.Stores.ArticleStore;
using BlazorTechniques.Shared.FluxStateManagement;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;

namespace BlazorTechniques.Client.Components.FluxStateManagement
{
  public partial class EditArticle : ComponentBase, IDisposable
  {
    [Inject] public ArticleStore Store { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    public Article Article { get; set; }
    [Parameter] public int? Id { get; set; }

    protected override void OnParametersSet()
    {
      if (Id.HasValue)
      {
        Article = Store.EditArticle(Id.Value);
      }
    }

    protected override void OnInitialized()
    {
      Store.AddStateChangeListener(StateHasChanged);
    }

    private void NextArticle()
    {
      var nextArticle = Store.NextArticle(Article.Id);

      if (nextArticle != null)
      {
        Article = nextArticle;
      }
    }

    private void PrevArticle()
    {
      var prevArticle = Store.PrevArticle(Article.Id);

      if (prevArticle != null)
      {
        Article = prevArticle;
      }
    }

    private void OnValidSubmit(EditContext editContext)
    {
      Store.UpdateArticle(Article);

      NavigationManager.NavigateTo("articles");
    }

    public void Dispose()
    {
      Store.RemoveStateChangeListener(StateHasChanged);
    }
  }
}
