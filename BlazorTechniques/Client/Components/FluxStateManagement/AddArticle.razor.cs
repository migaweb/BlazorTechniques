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
        ShortDescrption = GetRandomName(),
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

    private string GetRandomName()
    {
      var length = 7;
      var chars = "abcdefghijklmnopqrstuvwxyzåäö";
      var rand = new Random();
      var randomString =
        new String(Enumerable.Repeat(chars, length).Select(s => s[rand.Next(s.Length)]).ToArray());

      return randomString.First().ToString().ToUpper() + randomString.Substring(1);
    }
  }
}
