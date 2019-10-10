using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public Game()
    {
      Setup();
    }

    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      //NOTE Rooms
      Room sr = new Room("Hello World Room", "This is where you start your quest for the Golden Banana. You spot two Elixers in the Corner. Choose wisely...");
      Room r1 = new Room("FreeCodeCamp Hall", "This room seems like a nice place to start, but you must continue your search... ");
      Room r2 = new Room("Chose your bootcamp room", "This room seems like a big decision and you should choose wisely");
      Room r3 = new Room("BCW Hall", "Only the greats get to grace this hall, and you seem like you are on the correct path. You read a quote on the wall that says 'Don't Get Cocky Kid' - Han Solo. It seems like danger still lurks ahead.");
      Room r4 = new Room("A Dojo of Code", "This room seems like a dead end. Bummer.");
      Room lr = new Room("Pizza Under the Door room.", "You fell into CodeMonkey's trap...");
      Room wr = new Room("Developer's Paradise.", "As you enter this room you see the great code monkey typing away at his c# code...error free. He gifts you the same power as he hands you the Golden Banana.");
      Room fr = new Room("Coding Glory", "You have achieved your quest and have obtain the ultimate coding glory.");

      //NOTE Create relationships between rooms
      sr.AddExit(r1, "east");
      r1.AddExit(sr, "west");

      r1.AddExit(r2, "east");
      r2.AddExit(r1, "west");

      r2.AddExit(r4, "south");
      r4.AddExit(r2, "north");

      r2.AddExit(r3, "north");
      r3.AddExit(r2, "south");

      r3.AddExit(wr, "east");
      wr.AddExit(r3, "west");

      r3.AddExit(lr, "north");
      lr.AddExit(r3, "south");

      //NOTE Create items
      Item mountainDew = new Item("Mountain Dew", "A Crisp, Refreshing Exlir. Cans are commonly collected to display superiority.", r3);
      Item mountainLightning = new Item("Mountain Lightning", "Not quite dewing the dew, but saves you the pennies.", r4);
      Item goldenBanana = new Item("Golden Banana", "This has the power to debug your code", fr);

      //NOTE  Add items to rooms
      sr.Items.Add(mountainDew);
      sr.Items.Add(mountainLightning);
      wr.Items.Add(goldenBanana);

      CurrentRoom = sr;
    }

  }
}