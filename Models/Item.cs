using System.ComponentModel.DataAnnotations;

namespace auction.Models
{
  public class Item
  {
    public Item()
    {
    }

    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    public int Price { get; set; }

    public bool Sold { get; set; }

    public Item(string title)
    {
      Title = title;
    }
  }
}