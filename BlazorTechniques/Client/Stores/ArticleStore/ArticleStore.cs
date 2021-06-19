using BlazorTechniques.Shared.FluxStateManagement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorTechniques.Client.Stores.ArticleStore
{
  public class ArticleState
  {
    public List<Article> Articles { get; init; }

    public ArticleState(List<Article> articles = null)
    {
      if (articles != null)
      {
        Articles = articles;
        return;
      }

      Articles = new List<Article>();
    }
  }
  public class ArticleStore
  {
    private ArticleState _state;
    public bool IsEditing { get; set; }

    public int Count { get => _state?.Articles.Count ?? 0; }

    public List<Article> GetArticles()
    {
      if (_state == null)
      {
        _state = new ArticleState();
      }
      return _state.Articles;
    }

    public Article EditArticle(int id)
    {
      var article = _state.Articles.Where(e => e.Id == id).FirstOrDefault();
      IsEditing = article != null;
      BroadcastStateChange();
      // Clone to be able to cancel edit
      return new Article { 
        Id = article.Id,
        ShortDescrption = article.ShortDescrption,
        MainGroupId = article.MainGroupId,
        SubGroupId = article.SubGroupId
      };
    }

    public void CancelEdit()
    {
      IsEditing = false;
      BroadcastStateChange();
    }

    public void AddArticle(Article article)
    {
      var articles = _state.Articles;
      articles.Add(article);
      SetNewState(articles);
    }

    public void UpdateArticle(Article article)
    {
      var articles = _state.Articles;
      var updateArticle = articles.Single(e => e.Id == article.Id);
      updateArticle.MainGroupId = article.MainGroupId;
      updateArticle.SubGroupId = article.SubGroupId;
      updateArticle.ShortDescrption = article.ShortDescrption;
      IsEditing = false;
      SetNewState(articles);
    }

    public void DeleteArticle(Article article)
    {
      var articles = _state.Articles;
      articles.Remove(article);
      SetNewState(articles);
    }

    private void SetNewState(List<Article> articles)
    {
      this._state = new ArticleState(articles);
      BroadcastStateChange();
    }

    #region Observer pattern

    private Action _listeners;

    public void AddStateChangeListener(Action listener)
    {
      _listeners += listener;
    }

    public void RemoveStateChangeListener(Action listener)
    {
      _listeners -= listener;
    }

    private void BroadcastStateChange()
    {
      _listeners.Invoke();
    }

    #endregion
  }
}
