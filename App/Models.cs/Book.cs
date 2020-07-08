using System;

namespace micahslibrarys.Models
{
  public class Book
  {
    public Book(string title, string author, int inStock)
    {
      Title = title;
      Author = author;
      InStock = inStock;
    }
    public string Title { get; set; }
    public string Author { get; set; }
    public int InStock { get; set; }
    public bool Available { get { return InStock > 0; } }
    public override string ToString()
    {
      return $" {Title} {Author} {InStock}";
    }

  }
}

