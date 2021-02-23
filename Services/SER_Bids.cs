using System;
using System.Collections.Generic;
using auction.Models;
using auction.Repositories;

namespace auction.Services
{
  public class SER_Bids
  {
    private readonly REP_Bids _repoBids;
    private readonly REP_Items _repoItems;
    private readonly REP_Members _repoMembers;

    public SER_Bids(REP_Bids repoBids, REP_Items repoItems, REP_Members repoMembers)
    {
      _repoBids = repoBids;
      _repoItems = repoItems;
      _repoMembers = repoMembers;
    }

    public IEnumerable<Bid> GetPopulated(int id, string type)
    {
      if (type == "Item")
      {
        Item item = _repoItems.GetById(id);
        if (item == null) { throw new Exception("No item by id"); }
        return _repoBids.GetPopulated(item);
      }
      else if (type == "Member")
      {
        Member member = _repoMembers.GetById(id);
        if (member == null) { throw new Exception("No member by id"); }
        return _repoBids.GetPopulated(member);
      }
      else
      {
        throw new Exception("False type provided");
      }
    }

    public Bid Create(Bid newBid) { return _repoBids.Create(newBid); }

    public int Delete(int id) { return _repoBids.Delete(id); }
  }
}