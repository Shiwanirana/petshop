using System;
using System.ComponentModel.DataAnnotations;

namespace petshop.Models
{
  public class Dog
  {
    
    public Dog(string name, string description, int lives)
    {

      Name= name;
      Description = description;
      Lives = lives;
    }
    [Required]
    [MinLength(3)]
    public string Name {get; set;}
    [MaxLength(30)]
    public string Description {get;set;}
    [Range(0,9)]
    public int Lives {get;set;}
    public string Id {get;set;} = Guid.NewGuid().ToString();

  }
}