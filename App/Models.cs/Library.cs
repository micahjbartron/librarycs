using System;
using System.Collections.Generic;

namespace micahslibrarys.Models
{
  public class Library
  {
    string _Name;

    public Library(string location, string name)
    {
      Location = location;
      Name = name;
      Books.Add(new Book("the cat in the hat", "Dr. Suse", 3));
      Books.Add(new Book("the lorax", "Dr. suse", 1));
      Books.Add(new Book("red fish blue fish", "Dr. suse", 33));
      Books.Add(new Book("some other book", "smart author", 1));
    }
    public Library()
    {
      Location = "default";
      Name = "default";
    }

    public string Name { get { return _Name; } set { _Name = value; } }
    public string Location { get; set; }
    public List<Book> Books { get; set; } = new List<Book>();


    internal Book checkBookAvailability(string selection)
    {
      int bookIndex;
      bool valid = Int32.TryParse(selection, out bookIndex);
      if (!valid || bookIndex < 1 || bookIndex > Books.Count)
      {
        return null;
      }
      return Books[bookIndex - 1];
    }
    public void ViewBooks()
    {
      Console.WriteLine("Books currently in stock : \n");
      for (int i = 0; i < Books.Count; i++)
      {
        Book book = Books[i];
        if (book.Available)
        {
          System.Console.WriteLine($"{i + 1}. {book}");
        }
      }
    }

    internal void ViewBooks(bool available)
    {
      System.Console.WriteLine("Book stock");
      ConsoleColor forecolor = Console.ForegroundColor;
      for (int i = 0; i < Books.Count; i++)
      {
        Book book = Books[i];
        if (book.Available == available)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          System.Console.WriteLine($" {i + 1}. {book.Title} x {book.InStock} ");
        }
        else
        {
          Console.ForegroundColor = forecolor;
          System.Console.WriteLine($"{i + 1}. {book.Title} x {book.InStock} ");
        }
      }
      Console.ForegroundColor = forecolor;
    }



  }
}