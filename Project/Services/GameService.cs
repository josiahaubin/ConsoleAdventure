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
      throw new System.NotImplementedException();
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
      throw new System.NotImplementedException();
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
      throw new System.NotImplementedException();
    }

    public void Setup(string playerName)
    {
      Player player = new Player(playerName);
      _game.CurrentPlayer = player;
      Messages.Add("Welcome " + player.Name);
      Messages.Add("You are a Junior Dev Student and the great and wise D$ and Marky Mark inform you about the legend of the Great CodeMonkey. The Great CodeMonkey posses the Golden Banana, which has the power to instantly debug your code. In need of this you set off on your quest to find the CodeMonkey and obtain the Golden Banana. \n You enter into the developer temple and start your journey. (For assistance type help for commands.)");
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }

  }
}