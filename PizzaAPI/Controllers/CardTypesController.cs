using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using PizzaAPI.Models;
using PizzaAPI.Models.EntityRepository;
using Microsoft.AspNetCore.Cors;

namespace PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsOrigin")]
    public class CardTypesController : ControllerBase
    {
        private readonly APIDbContext _context;
        private readonly ICardTypeRepository _cr;
        public CardTypesController(APIDbContext context, ICardTypeRepository cr)
        {
            _context = context;
            _cr = cr;
            _cr.APIDbContext = context;
        }
        // GET api/CardTypes
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var cardTypes = await _context.CardType.ToListAsync<CardType>();
            if (cardTypes == null) { return NotFound("records not found."); }
            return Ok(cardTypes);
        }

        // GET api/CardTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cardType = await _cr.Get(id);
            // error check for status 
            if (cardType == null) { return NotFound("record not found."); }
            return Ok(await _cr.Get(id));
        }

        // POST api/CardTypes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CardType dto)
        {
            var result = await _cr.Add(dto);
            // error check for status 
            if (result == null) { return BadRequest("CardType was not created."); }
            return CreatedAtAction(
                nameof(Get),
                result);
        }

        // PUT api/CardTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] CardType dto)
        {
            CardType cardType = await _cr.Update(dto);
            // error check for status 
            if (cardType == null) { return NotFound("record not found."); }
            return Ok(cardType);
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            CardType cardType = await _cr.Delete(id);
            // error check for status 
            if (cardType == null) { return NotFound("record not found."); }
            return Ok(new KeyValuePair<string, CardType>("CardType deleted", cardType));

        }
    }
}