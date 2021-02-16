using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using petshop.db;
using petshop.Models;

namespace petshop.Controllers    //shortcut for opening this--type--api--click first link
{
  [ApiController]
  [Route("api/[controller]")]
  public class DogsController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Dog>> Get()
    {
     try{
      return Ok(FAKEDB.Dogs);
     } 
     catch(System.Exception err)
     {
       return BadRequest(err.Message);
     }
    }
    [HttpGet("{id}")]
    public ActionResult<Dog> GetDogById(string id)
    {
     try{
       Dog dogToReturn = FAKEDB.Dogs.Find(d=> d.Id == id);
       return Ok(dogToReturn);
     }
     catch(System.Exception err)
     {
       return BadRequest(err.Message);
     }
    } 
    [HttpPost]
    public ActionResult<Dog> Create([FromBody] Dog newDog)
    {
      try{
        FAKEDB.Dogs.Add(newDog);
        return Ok(newDog);
      }
      catch(System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Dog> Edit(string id,[FromBody] Dog editDog){
      try{
        Dog foundDog = FAKEDB.Dogs.Find(d=> d.Id == id);
        editDog.Lives = editDog.Lives!= null?editDog.Lives:foundDog.Lives;
        editDog.Name = editDog.Name!= null?editDog.Name:foundDog.Name;
        editDog.Description = editDog.Description!= null?editDog.Description:foundDog.Description;
        FAKEDB.Dogs.Remove(foundDog);
        FAKEDB.Dogs.Add(editDog);
        return Ok(editDog);

      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpDelete("{dogId}")]
    public ActionResult<Dog> BuyDog(string dogId){
      try{
        Dog dogToRemove = FAKEDB.Dogs.Find(d=> d.Id == dogId);
        if(FAKEDB.Dogs.Remove(dogToRemove)){
          return Ok("Congratulations, This dog has a new house now!!");
        };
        throw new System.Exception("Dog is not here.");
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
  }
}