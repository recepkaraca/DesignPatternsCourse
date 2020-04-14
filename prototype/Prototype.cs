using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCourse.Prototype
{
    class Prototype
    {
        public static void Main(string[] args)
        {
            BookForShallow book1 = new BookForShallow(1, "I Robot", "Science Fiction");
            BookForShallow book2 = (BookForShallow)book1.Clone();
            book2.BookId = 2;

            Console.WriteLine("Book 1:");
            Console.WriteLine("ID: " + book1.BookId + " Name: " + book1.BookName + " Category: " + book1.Category);

            Console.WriteLine("Book 2:");
            Console.WriteLine("ID: " + book2.BookId + " Name: " + book2.BookName + " Category: " + book2.Category);


            BookForDeep book3 = new BookForDeep(1, "I Robot", "Science Fiction");
            BookForDeep book4 = (BookForDeep)book3.Clone();
            book4.BookId = 3;

            Console.WriteLine("Book 3:");
            Console.WriteLine("ID: " + book3.BookId + " Name: " + book3.BookName + " Category: " + book3.Category);

            Console.WriteLine("Book 4:");
            Console.WriteLine("ID: " + book4.BookId + " Name: " + book4.BookName + " Category: " + book4.Category);
        }
    }

    abstract class BookPrototype
    {
        public int BookId;
        public string BookName;
        public string Category;

        public BookPrototype(int bookId, string bookName, string category)
        {
            BookId = bookId;
            BookName = bookName;
            Category = category;
        }

        public abstract BookPrototype Clone();
    }


    class BookForDeep : BookPrototype
    {
        public BookForDeep(int bookId, string bookName, string category) : base(bookId, bookName, category)
        {
        }

        public override BookPrototype Clone()
        {
            return (BookPrototype)this;
        }
    }

    class BookForShallow : BookPrototype
    {
        public BookForShallow(int bookId, string bookName, string category) : base(bookId, bookName, category)
        {
        }

        // Deep Copy
        public override BookPrototype Clone()
        {
            return (BookPrototype)this.MemberwiseClone();
        }
    }
}
