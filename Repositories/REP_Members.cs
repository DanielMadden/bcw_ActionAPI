using System.Collections.Generic;
using System.Data;
using auction.Models;
using Dapper;

namespace auction.Repositories
{
  public class REP_Members
  {
    private readonly IDbConnection _db;

    public REP_Members(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Member> GetAll()
    {
      string sql = "SELECT * FROM members";
      return _db.Query<Member>(sql);
    }

    public Member GetById(int id)
    {
      string sql = "SELECT * FROM members WHERE id = @id";
      return _db.QueryFirstOrDefault<Member>(sql, new { id });
    }

    public Member Create(Member newMember)
    {
      string sql = @"
        INSERT INTO members
        (name)
        VALUES
        (@Name);
        SELECT LAST_INSERT_ID()";
      newMember.Id = _db.ExecuteScalar<int>(sql, newMember);
      return newMember;
    }

    public int Delete(int id)
    {
      string sql = "DELETE FROM members WHERE id = @id";
      return _db.Execute(sql, new { id });
    }
  }
}