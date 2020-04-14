using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatternsCourse.ObjectPool
{
    public class BookPool
    {
        private static Lazy<BookPool> instance
            = new Lazy<BookPool>(() => new BookPool());
        public static BookPool Instance { get; } = instance.Value;

        private const int defaultSize = 5;
        private ConcurrentBag<Book> _bag = new ConcurrentBag<Book>();
        private volatile int _currentSize;
        private volatile int _counter;
        private object _lockObject = new object();

        private BookPool()
            : this(defaultSize)
        {
        }
        private BookPool(int size)
        {
            _currentSize = size;
        }

        public Book AcquireObject()
        {
            if (!_bag.TryTake(out Book item))
            {
                lock (_lockObject)
                {
                    if (item == null)
                    {
                        if (_counter >= _currentSize)
                            throw new Exception();

                        item = new RequestBook();
                        _counter++;

                    }
                }

            }

            return item;
        }

        public void ReleaseObject(Book item)
        {
            _bag.Add(item);
        }
    }


    public abstract class Book
    {
        public abstract string GatherBook();
    }
    internal class RequestBook : Book
    {
        public override string GatherBook()
        {
            Thread.Sleep(1000);
            return "Gathering book with RequestBook...";
        }
    }


    class ObjectPoolRun
    {
        public static void Main(string[] args)
        {
            int counter = 0;
            Parallel.For(0, 100, (i, loopState) =>
            {
                Book book;
                Exception e = null;
                do
                {
                    try
                    {
                        book = BookPool.Instance.AcquireObject();
                        Console.WriteLine("Thread " + Thread.CurrentThread.GetHashCode() + " : " + book.GatherBook() + " Instance id : " + book.GetHashCode());
                        BookPool.Instance.ReleaseObject(book);
                        e = null;
                        counter++;
                    }
                    catch (Exception ex)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("Waiting...");
                        e = ex;
                    }
                } while (e != null);
            });

            Console.WriteLine("Counter : " + counter);
        }
    }
}
