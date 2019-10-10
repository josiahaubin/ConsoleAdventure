using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Player : IPlayer
  {

    public string Name { get; set; }
    public List<Item> Inventory { get; set; }

    public string GetTemplate()
    {
      string template = "Items:";
      foreach (var item in Inventory)
      {
        template += $" {item.Name}";
      }

      return template;
    }
    public Player(string name)
    {
      Name = name;
      Inventory = new List<Item>();
    }
  }
}