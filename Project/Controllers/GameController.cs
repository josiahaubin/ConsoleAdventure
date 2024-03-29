using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{
  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {
      NewGame();
      while (true)
      {
        Print();
        GetUserInput();
      }
    }

    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"
      switch (command)
      {
        case "quit":
          Console.Clear();
          _gameService.Quit();
          break;
        case "help":
          Console.Clear();
          _gameService.Help();
          Print();
          break;
        case "look":
          Console.Clear();
          _gameService.Look();
          break;
        case "go":
          Console.Clear();
          _gameService.Go(option);
          CheckRoom();
          break;
        case "take":
          Console.Clear();
          _gameService.TakeItem(option);
          break;
        case "inventory":
          Console.Clear();
          _gameService.Inventory();
          break;
        case "use":
          Console.Clear();
          _gameService.UseItem(option);
          CheckRoom();
          break;
      }
    }

    //NOTE this should print your messages for the game.
    private void Print()
    {
      foreach (string message in _gameService.Messages)
      {
        Console.WriteLine(message);
      }
      _gameService.Messages.Clear();
    }

    private void NewGame()
    {
      Console.WriteLine("What is your name?");
      string name = Console.ReadLine();
      _gameService.Setup(name);
      Console.Clear();
    }
    private void CheckRoom()
    {
      bool validator = _gameService.CheckRoom();

      if (validator == true)
      {

        _gameService.Messages.Add("Would you like to play again? (Y/N)");
        Print();
        string ans = Console.ReadLine().ToLower();

        switch (ans)
        {
          case "y":
          case "yes":
            _gameService.Reset();
            Console.Clear();
            NewGame();
            break;
          case "n":
          case "no":
            Environment.Exit(0);
            break;
        }
      }
      return;
    }

  }
}