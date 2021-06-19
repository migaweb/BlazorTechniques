using BlazorTechniques.Client.Stores.ArticleStore;
using BlazorTechniques.Shared.FluxStateManagement;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorTechniques.Client.Components.FluxStateManagement
{
  public partial class EditArticle : ComponentBase
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

    private void OnValidSubmit(EditContext editContext)
    {
      Store.UpdateArticle(Article);

      NavigationManager.NavigateTo("articles");
    }
  }
}
