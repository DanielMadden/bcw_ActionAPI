using System.Collections.Generic;
using System.Data;
using auction.Models;
using Dapper;

namespace auction.Repositories
{
  public class REP_Items
  {
    private readonly IDbConnection _db;

    public REP_Items(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Item> GetAll()
    {
      string sql = "SELECT * FROM items";
      return _db.Query<Item>(sql);
    }

    public Item GetById(int id)
    {
      string sql = "SELECT * FROM items WHERE id = @id";
      return _db.QueryFirstOrDefault<Item>(sql, new { id });
    }

    public Item Create(Item newItem)
    {
      string sql = @"
        INSERT INTO items
        (title, price)
        VALUES
        (@Title, @Price);
        SELECT LAST_INSERT_ID()";
      newItem.Id = _db.ExecuteScalar<int>(sql, newItem);
      return newItem;
    }

    // public Item Edit(Item newItem)
    // {
    //   string sql = @"
    //   UPDATE items
    //   SET
    //     title = @Title,
    //     price = @Price
    //   WHERE id = @Id";
    //   _db.Execute(sql, newItem);
    //   return newItem;
    // }

    public Item Sell(int id)
    {
      string sql = @"
      UPDATE items
      SET 
        sold = true
      WHERE id = @id;
      SELECT * FROM items WHERE id = @id";
      return _db.QueryFirstOrDefault<Item>(sql, new { id });
    }

    public int Delete(int id)
    {
      string sql = "DELETE FROM items WHERE id = @id";
      return _db.Execute(sql, new { id });
    }
  }
}