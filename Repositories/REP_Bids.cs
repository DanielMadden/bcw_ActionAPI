using System;
using System.Collections.Generic;
using System.Data;
using auction.Models;
using Dapper;

namespace auction.Repositories
{
  public class REP_Bids
  {
    private readonly IDbConnection _db;

    public REP_Bids(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Bid> GetPopulated(Member member)
    {
      int memberId = member.Id;
      string sql = @"
          SELECT
              bid.*,
              item.*,
              member.*
                  FROM bids bid
                        JOIN items item 
                            ON item.id = bid.itemId
                        JOIN members member
                            ON member.id = bid.memberId
                  WHERE memberId = @memberId
          ";
      return _db.Query<BidPopulated, Item, Member, BidPopulated>(sql, (b, i, m) =>
      {
        b.Item = i;
        b.Member = m;
        return b;
      }, new { memberId }, splitOn: "id");
    }

    public IEnumerable<Bid> GetPopulated(Item item)
    {
      int itemId = item.Id;
      string sql = @"
          SELECT
              bid.*,
              item.*,
              member.*
                  FROM bids bid
                        JOIN items item 
                            ON item.id = bid.itemId
                        JOIN members member
                            ON member.id = bid.memberId
                  WHERE itemId = @itemId
          ";
      return _db.Query<BidPopulated, Item, Member, BidPopulated>(sql, (b, i, m) =>
      {
        b.Item = i;
        b.Member = m;
        return b;
      }, new { itemId }, splitOn: "id");
    }

    public Bid Create(Bid newBid)
    {
      string sql = @"
          INSERT INTO bids
              (itemId, memberId, amount)
          VALUES
              (@ItemId, @MemberId, @Amount);
          SELECT LAST_INSERT_ID()";
      newBid.Id = _db.ExecuteScalar<int>(sql, newBid);
      return newBid;
    }

    public int Delete(int id)
    {
      string sql = "DELETE FROM bids WHERE id = @id";
      return _db.Execute(sql);
    }
  }
}