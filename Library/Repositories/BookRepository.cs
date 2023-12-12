using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class BookRepository
    {
        public Book ChooseById()
        {
            Console.WriteLine("Введите ID книги");
            int id = Convert.ToInt32(Console.ReadLine());
            using (var db = new AppContext())
            {
                var result = db.Books.Where(b => b.Id == id).FirstOrDefault();
                return result;
            }
        }
        public List<Book> ChooseAll()
        {
            using (var db = new AppContext())
            {
                var result = db.Books.ToList();
                return result;
            }
        }
        public void AddBook()
        {
            using (var db = new AppContext())
            {
                Console.WriteLine("Введите название издания");
                string name = Console.ReadLine();
                Console.WriteLine("Введите год издания книги");
                string year = Console.ReadLine();
                Console.WriteLine("Введите автора");
                string author = Console.ReadLine();
                Console.WriteLine("Введите Id пользователя, у которого книга на 'руках'");
                int id = Convert.ToInt32(Console.ReadLine());
                db.Books.Add(new Book { Name = name, PublishingYear = year, Author = author, UserId = id });
                db.SaveChanges();
            }
        }
        public void RemoveBook()
        {
            using (var db = new AppContext())
            {
                Console.WriteLine("Введите ID книги для удаления");
                int id = Convert.ToInt32(Console.ReadLine());
                var book = db.Books.Where(b => b.Id == id).FirstOrDefault();
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }
        public void UpdateYear()
        {
            using (var db = new AppContext())
            {
                Console.WriteLine("Введите ID книги для обновления");
                int id = Convert.ToInt32(Console.ReadLine());
                var book = db.Books.Where(b => b.Id == id).FirstOrDefault();
                Console.WriteLine("Введите новый год издания");
                string year = Console.ReadLine();
                book.PublishingYear = year;
                db.SaveChanges();
            }
        }
        public List<Book> GetDateRange()
        {
            using (var db = new AppContext())
            {
                Console.WriteLine("Введите первую дату");
                var date1 = Console.ReadLine();
                Console.WriteLine("Введите вторую дату");
                var date2 = Console.ReadLine();
                var result = db.Books.Where(b => Convert.ToInt32(b.PublishingYear) > Convert.ToInt32(date1) && Convert.ToInt32(b.PublishingYear) < Convert.ToInt32(date2)).ToList();
                return result;
            }
        }
        public int GetCountOfAuthorBooks()
        {
            using (var db = new AppContext())
            {
                Console.WriteLine("Введите фамилию автора");
                var name = Console.ReadLine();
                var result = db.Books.Where(b => b.Author == name).Count();
                return result;
            }
        }
        public bool CheckBookNameOrAuthor()
        {
            using (var db = new AppContext())
            {
                Console.WriteLine("Введите название книги или фамилию автора");
                var str = Console.ReadLine();
                var result = db.Books.Any(b => b.Author == str || b.Name == str);
                return result;
            }
        }
        public Book GetLastBook()
        {
            using (var db = new AppContext())
            {
                var lastYear = db.Books.Max(b => b.PublishingYear);
                var result = db.Books.Where(b => b.PublishingYear == lastYear).FirstOrDefault();
                return result;
            }
        }
        public List<Book> GetSortedBooksByName()
        {
            using (var db = new AppContext())
            {
                var result = db.Books.OrderBy(b => b.Name).ToList();
                return result;
            }
        }
        public List<Book> GetSortedBooksByYear()
        {
            using (var db = new AppContext())
            {
                var result = db.Books.OrderByDescending(b => b.PublishingYear).ToList();
                return result;
            }
        }
    }
}

