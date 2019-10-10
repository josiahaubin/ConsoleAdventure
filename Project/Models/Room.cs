using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {

    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    public void AddExit(IRoom room)
    {
      Exits.Add(room.Name, room);
    }
    public string GetTemplate()
    {
      string template = $"You are currently in {Name} and {Description}\nThe room contains:";

      foreach (Item item in Items)
      {
        template += $" \n{item.Name}: {item.Description}";
      }

      template += "\n\nExits:";
      foreach (var exit in Exits)
      {
        template += exit.Key;
      }
      return template;
    }
    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
    }
  }
}