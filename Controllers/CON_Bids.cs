using System;
using System.Collections.Generic;
using auction.Models;
using auction.Services;
using Microsoft.AspNetCore.Mvc;

namespace auction.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BidsController : ControllerBase
  {
    private readonly SER_Bids _serviceBids;
    public BidsController(SER_Bids serviceBids)
    {
      _serviceBids = serviceBids;
    }

    [HttpPost]
    public ActionResult<Bid> Create([FromBody] Bid newBid)
    {
      try { return Ok(_serviceBids.Create(newBid)); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try { return Ok(_serviceBids.Delete(id)); }
      catch (Exception err) { return BadRequest(err.Message); }
    }
  }
}