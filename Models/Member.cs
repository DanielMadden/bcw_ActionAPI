using System.ComponentModel.DataAnnotations;

namespace auction.Models
{
  public class Member
  {
    public Member()
    {
    }

    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public Member(string name)
    {
      Name = name;
    }
  }
}