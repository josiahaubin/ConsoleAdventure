using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
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

      //NOTE Create relationships between rooms
      sr.AddExit(r1);
      r1.AddExit(sr);

      r1.AddExit(r2);
      r2.AddExit(r1);

      r2.AddExit(r4);
      r4.AddExit(r2);

      r2.AddExit(r3);
      r3.AddExit(r2);

      r3.AddExit(wr);
      wr.AddExit(r3);

      r3.AddExit(lr);
      lr.AddExit(r3);

      //NOTE Create items
      Item mountainDew = new Item("Mountain Dew", "An Crisp, Refreshing Exlir. Can are commonly collected to display superiority");
      Item mountainLightning = new Item("Mountain Lightning", "Not quite dewing the dew, but saves you the pennies");

      //NOTE  Add items to rooms
      sr.Items.Add(mountainDew);
      sr.Items.Add(mountainLightning);
    }
  }
}