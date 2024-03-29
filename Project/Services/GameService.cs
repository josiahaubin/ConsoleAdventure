using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }
    public void Go(string direction)
    {
      string current = _game.CurrentRoom.Name;
      _game.CurrentRoom = _game.CurrentRoom.Move(direction);
      string destination = _game.CurrentRoom.Name;

      if (current == destination)
      {
        Messages.Add("Invalid Movement");
        return;
      }
      Messages.Add($"Traveled from {current} to {destination}");
      Messages.Add("\n" + _game.CurrentRoom.GetTemplate());
    }
    public void Help()
    {
      string info = @"
Go: Moves the player from room to room
Use: Uses an item in a room or from your inventory
Take: Places an item into the player inventory and removes it from the room
Look: Prints the description of the room again
Inventory: Prints the players inventory
Help: Shows a list of commands and actions
Quit: Quits the Game
      ";
      Messages.Add(info);
    }

    public void Inventory()
    {
      Messages.Add(_game.CurrentPlayer.GetTemplate());
    }

    public void Look()
    {
      Messages.Add(_game.CurrentRoom.GetTemplate());
    }

    public void Quit()
    {
      Environment.Exit(0);
    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      _game.CurrentPlayer.Inventory.Clear();
      _game.Setup();
    }

    public void Setup(string playerName)
    {
      Player player = new Player(playerName);
      _game.CurrentPlayer = player;
      Messages.Add("Welcome " + player.Name + ",");
      Messages.Add("You are a Junior Dev Student and the great and wise D$ and Mark inform you about the legend of The Great CodeMonkey.\nThe Great CodeMonkey posses the Golden Banana, which has the power to instantly debug your code.\nIn need of this you set off on your quest to find the CodeMonkey and obtain the Golden Banana.\nYou enter into the developer temple and start your journey. (For assistance type help for commands.)");
      Messages.Add("\n\n" + _game.CurrentRoom.GetTemplate());

    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      // IItem found = _game.CurrentRoom.Items.Find(i=> i.Name.ToLower() == itemName);
      // if(found == null){
      //   //fail message
      //   return;
      // }

      for (int i = 0; i < _game.CurrentRoom.Items.Count; i++)
      {
        var item = _game.CurrentRoom.Items[i];

        if (item.Name.ToLower() == itemName)
        {
          _game.CurrentPlayer.Inventory.Add(item);
          Messages.Add("Item successfully obtained");
          _game.CurrentRoom.Items.Remove(item);
          return;
        }
      }
      Messages.Add("Invalid Action");
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      for (int i = 0; i < _game.CurrentPlayer.Inventory.Count; i++)
      {
        var item = _game.CurrentPlayer.Inventory[i];

        if (item.Name.ToLower() == itemName && itemName != "mountain lightning")
        {
          _game.CurrentRoom = item.To;
          _game.CurrentPlayer.Inventory.Remove(item);
          Messages.Add($"Teleported to the {_game.CurrentRoom.Name}");
          Messages.Add("\n\n" + _game.CurrentRoom.GetTemplate());
          return;
        }
        else if (item.Name.ToLower() == itemName && itemName == "mountain lightning")
        {
          if (_game.CurrentRoom != item.To)
          {
            Messages.Add("You can't use mountain lightning here.");
            return;
          }
          _game.CurrentPlayer.Inventory.Remove(item);
          _game.CurrentRoom.Description = "This is where you started your quest for the Golden Banana. That Mountain Lightning didn't do much, we did say to choose wisely...";
          Messages.Add(_game.CurrentRoom.GetTemplate());
          return;
        }
      }
      Messages.Add("Invalid Action");
    }

    public bool CheckRoom()
    {
      if (_game.CurrentRoom.Name == "Coding Glory" || _game.CurrentRoom.Name == "Pizza Under the Door Room")
      {
        if (_game.CurrentRoom.Name == "Coding Glory")
        {
          Console.Beep(400, 1000);
          Console.Beep(600, 1000);
          Console.Beep(1200, 1100);

          Messages.Add("YOU WIN");
        }
        else
        {
          Console.Beep(400, 1000);
          Console.Beep(300, 1000);
          Console.Beep(200, 1100);

          Messages.Add("YOU LOSE");
        }
        return true;
      }
      return false;
    }


  }
}