using System.ComponentModel.DataAnnotations;

namespace BlazorTechniques.Shared.FluxStateManagement
{
  public class Article
  {
    public int Id { get; set; }
    [Required]
    public string ShortDescrption { get; set; }
    [Required]
    public int MainGroupId { get; set; }
    [Required]
    public int SubGroupId { get; set; }
  }
}
