using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Item : IItem
  {

    public string Name { get; set; }
    public string Description { get; set; }
    public IRoom To { get; set; }
    public Item(string name, string description, IRoom to)
    {
      Name = name;
      Description = description;
      To = to;
    }
  }
}