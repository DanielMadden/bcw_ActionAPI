using System;
using System.Collections.Generic;
using auction.Models;
using auction.Services;
using Microsoft.AspNetCore.Mvc;

namespace auction.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MembersController : ControllerBase
  {
    private readonly SER_Members _serviceMembers;
    private readonly SER_Bids _serviceBids;
    public MembersController(SER_Members serviceMembers, SER_Bids serviceBids)
    {
      _serviceMembers = serviceMembers;
      _serviceBids = serviceBids;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Member>> GetAll()
    {
      try { return Ok(_serviceMembers.GetAll()); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpGet("{id}")]
    public ActionResult<Member> GetById(int id)
    {
      try { return Ok(_serviceMembers.GetById(id)); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpGet("{id}/bids")]
    public ActionResult<Bid> GetBids(int id)
    {
      try { return Ok(_serviceBids.GetPopulated(id, "Member")); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpPost]
    public ActionResult<Member> Create([FromBody] Member newMember)
    {
      try { return Ok(_serviceMembers.Create(newMember)); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try { return Ok(_serviceMembers.Delete(id)); }
      catch (Exception err) { return BadRequest(err.Message); }
    }
  }
}