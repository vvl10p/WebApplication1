﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.JokeModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/jokes")]
    [ApiController]
    public class JokeController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();
            return Ok(context.Jokes.ToList());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();
            var keresettVicc = (from x in context.Jokes
                                where x.JokeSk == id
                                select x).FirstOrDefault();
            if (keresettVicc == null)
            {
                return NotFound($"Nincs #{id} azonosítóval vicc");
            }
            else
            {
                return Ok(keresettVicc);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Joke újVicc)
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();
            context.Jokes.Add(újVicc);
            context.SaveChanges();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();
            var törlendőVicc = (from x in context.Jokes
                                where x.JokeSk == id
                                select x).FirstOrDefault();
            context.Remove(törlendőVicc);
            context.SaveChanges();
        }
    }
}
