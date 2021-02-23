using System.Collections.Generic;
using auction.Models;
using auction.Repositories;

namespace auction.Services
{
  public class SER_Items
  {
    private readonly REP_Items _repoItems;

    public SER_Items(REP_Items repoItems) { _repoItems = repoItems; }

    public IEnumerable<Item> GetAll() { return _repoItems.GetAll(); }

    public Item GetById(int id) { return _repoItems.GetById(id); }

    public Item Create(Item newItem) { return _repoItems.Create(newItem); }

    public Item Sell(int id) { return _repoItems.Sell(id); }

    public int Delete(int id) { return _repoItems.Delete(id); }
  }
}