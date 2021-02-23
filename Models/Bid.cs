using System.Collections.Generic;

namespace auction.Models
{
  public class Bid
  {
    public Bid()
    {
    }

    public int Id { get; set; }
    public int ItemId { get; set; }
    public int MemberId { get; set; }
    public double Amount { get; set; }

    public Bid(int itemId, int memberId, double amount)
    {
      ItemId = itemId;
      MemberId = memberId;
      Amount = amount;
    }
  }

  public class BidPopulated : Bid
  {
    public Item Item { get; set; }
    public Member Member { get; set; }
  }
}