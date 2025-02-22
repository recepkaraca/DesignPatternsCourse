﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCourse
{
    abstract class Book
    {
        public abstract string BookCategory { get; }
        public abstract int Page { get; set; }
        public abstract string Author { get; set; }
    }

    class FantasticBook : Book
    {
        private readonly string _bookCategory;
        private int _page;
        private string _author;

        public FantasticBook(int page, string author)
        {
            _bookCategory = "Fantastic";
            _page = page;
            _author = author;
        }

        public override string BookCategory
        {
            get { return _bookCategory; }
        }

        public override int Page
        {
            get { return _page; }
            set { _page = value; }
        }

        public override string Author
        {
            get { return _author; }
            set { _author = value; }
        }
    }

    class ScienceFictionBook : Book
    {
        private readonly string _bookCategory;
        private int _page;
        private string _author;

        public ScienceFictionBook(int page, string author)
        {
            _bookCategory = "Science Fiction";
            _page = page;
            _author = author;
        }

        public override string BookCategory
        {
            get { return _bookCategory; }
        }

        public override int Page
        {
            get { return _page; }
            set { _page = value; }
        }

        public override string Author
        {
            get { return _author; }
            set { _author = value; }
        }
    }

    abstract class BookFactory
    {
        public abstract Book GetBook();
    }

    class FantasticFactory : BookFactory
    {
        private int _page;
        private string _author;

        public FantasticFactory(int page, string author)
        {
            _page = page;
            _author = author;
        }

        public override Book GetBook()
        {
            return new FantasticBook(_page, _author);
        }
    }

    class ScienceFictionFactory : BookFactory
    {
        private int _page;
        private string _author;

        public ScienceFictionFactory(int page, string author)
        {
            _page = page;
            _author = author;
        }

        public override Book GetBook()
        {
            return new ScienceFictionBook(_page, _author);
        }
    }

    public class Factory
    {
        static void Main(string[] args)
        {
            BookFactory bookFactory = null;
            Console.WriteLine("Uretmek istediginiz kitap turunu girin. (1-Fantastik / 2-Bilim Kurgu)");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    bookFactory = new FantasticFactory(500, "Tolkien");
                    break;
                case "2":
                    bookFactory = new ScienceFictionFactory(1000, "Asimov");
                    break;
                default:
                    break;
            }

            Book book = bookFactory.GetBook();
            Console.WriteLine("Your produced book details: ");
            Console.WriteLine("Book category: {0}\nPage: {1}\nAuthor: {2}", 
                book.BookCategory, book.Page, book.Author);
        }
    }
}
