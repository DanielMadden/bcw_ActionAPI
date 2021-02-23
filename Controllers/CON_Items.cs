using System;
using System.Collections.Generic;
using auction.Models;
using auction.Services;
using Microsoft.AspNetCore.Mvc;

namespace auction.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ItemsController : ControllerBase
  {
    private readonly SER_Items _serviceItems;
    private readonly SER_Bids _serviceBids;
    public ItemsController(SER_Items serviceItems, SER_Bids serviceBids)
    {
      _serviceItems = serviceItems;
      _serviceBids = serviceBids;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Item>> GetAll()
    {
      try { return Ok(_serviceItems.GetAll()); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpGet("{id}")]
    public ActionResult<Item> GetById(int id)
    {
      try { return Ok(_serviceItems.GetById(id)); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpGet("{id}/bids")]
    public ActionResult<Bid> GetBids(int id)
    {
      try { return Ok(_serviceBids.GetPopulated(id, "Item")); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpPost]
    public ActionResult<Item> Create([FromBody] Item newItem)
    {
      try { return Ok(_serviceItems.Create(newItem)); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpPut("{id}")]
    public ActionResult<Item> Sell(int id)
    {
      try { return Ok(_serviceItems.Sell(id)); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try { return Ok(_serviceItems.Delete(id)); }
      catch (Exception err) { return BadRequest(err.Message); }
    }
  }
}