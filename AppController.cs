using System;
using micahslibrarys.Models;

namespace micahslibrarys
{

  public class App
  {
    public Library Library { get; set; }
    public bool Running { get; private set; }

    public void Run()
    {
      Console.Clear();

      Library = new Library("West end of never", "Bookworm");
      Console.WriteLine($"\nWelcome to {Library.Name} - {Library.Location}");
      Running = true;
      while (Running)
      {
        System.Console.WriteLine("We got the books! Reserve / Stock / Quit");
        string input = Console.ReadLine().ToLower();
        switch (input)
        {
          case "reserve":
          case "R":
          case "purchase":
            CheckOut();
            break;
          case "stock":
          case "s":
          case "got it":
            StockBook();
            break;
          case "quit":
          case "q":
          case "end":
            Running = false;
            System.Console.WriteLine("thank you come again");
            break;
          default:
            System.Console.WriteLine("invalid command");
            break;
        }
      }
    }

    private void StockBook()
    {
      Console.Clear();
      Library.ViewBooks(false);
      System.Console.WriteLine("Select a book to stock!");
      string selection = Console.ReadLine();
      Book selectedBook = Library.checkBookAvailability(selection);
      if (selectedBook == null)
      {
        System.Console.WriteLine("Invalid Selection");
        return;
      }
      System.Console.WriteLine("How many " + selectedBook.Title + " do you want to stock today");
      string input = Console.ReadLine();

    }

    public void CheckOut()
    {
      Console.Clear();
      Library.ViewBooks();
      System.Console.WriteLine("Select a Book to check out");
      string selection = Console.ReadLine();
      Book selectedBook = Library.checkBookAvailability(selection);
      if (selectedBook == null)
      {
        System.Console.WriteLine("Invalid Selection");
        return;
      }
      System.Console.WriteLine("check out " +
       selectedBook.Title + " book today");
      string input = Console.ReadLine();
      int quantity;
      bool valid = Int32.TryParse(input, out quantity);
      if (!valid)
      {
        System.Console.WriteLine("enter a number please");
        return;
      }
      if (selectedBook.InStock >= quantity)
      {
        selectedBook.InStock -= quantity;
        System.Console.WriteLine($"Thanks for checking out {quantity} {selectedBook.Title}");
        return;
      }
      else
      {
        System.Console.WriteLine($"We do not have enough {quantity} {selectedBook.Title} in stock");
        return;
      }
    }
  }
}