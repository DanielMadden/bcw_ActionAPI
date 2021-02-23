using System.Collections.Generic;
using auction.Models;
using auction.Repositories;

namespace auction.Services
{
  public class SER_Members
  {
    private readonly REP_Members _repoMembers;

    public SER_Members(REP_Members repoMembers) { _repoMembers = repoMembers; }

    public IEnumerable<Member> GetAll() { return _repoMembers.GetAll(); }

    public Member GetById(int id) { return _repoMembers.GetById(id); }

    public Member Create(Member newMember) { return _repoMembers.Create(newMember); }

    public int Delete(int id) { return _repoMembers.Delete(id); }
  }
}