using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class UserRepository
    {
        public User ChooseById()
        {
            Console.WriteLine("Введите ID пользователя библиотеки");
            int id = Convert.ToInt32(Console.ReadLine());
            User result;
            using (var db = new AppContext())
            {
                result = db.Users.Where(u => u.Id == id).FirstOrDefault();
            }
            return result;
        }
        public List<User> ChooseAll()
        {
            List<User> result;
            using (var db = new AppContext())
            {
                result = db.Users.ToList();
            }
            return result;
        }
        public void AddUser()
        {
            using (var db = new AppContext())
            {
                Console.WriteLine("Введите имя пользователя");
                string name = Console.ReadLine();
                Console.WriteLine("Введите электронный адрес пользователя");
                string email = Console.ReadLine();
                db.Users.Add(new User { Name = name, Email = email });
                db.SaveChanges();
            }
        }
        public void RemoveUser()
        {
            using (var db = new AppContext())
            {
                Console.WriteLine("Введите ID пользователя библиотеки для удаления");
                int id = Convert.ToInt32(Console.ReadLine());
                var user = db.Users.Where(u => u.Id == id).FirstOrDefault();
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
        public void UpdateUsername()
        {
            using (var db = new AppContext())
            {
                Console.WriteLine("Введите ID пользователя библиотеки для обновления");
                int id = Convert.ToInt32(Console.ReadLine());
                var user = db.Users.Where(u => u.Id == id).FirstOrDefault();
                Console.WriteLine("Введите новое имя");
                string name = Console.ReadLine();
                user.Name = name;
                db.SaveChanges();
            }
        }
        public int GetCountOfUserBooks()
        {
            using (var db = new AppContext())
            {
                Console.WriteLine("Введите ID пользователя библиотеки для вывода информации об изданиях книг у него на 'руках'");
                int id = Convert.ToInt32(Console.ReadLine());
                var result = db.Books.Where(b => b.UserId == id).Count();
                return result;
            }
        }
        public bool CheckIfUserHasBook()
        {
            using (var db = new AppContext())
            {
                Console.WriteLine("Введите ID пользователя библиотеки");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название книги");
                var name = Console.ReadLine();
                var book = db.Books.Where(b => b.Name == name).FirstOrDefault();
                return book.UserId == id;
            }
        }
    }
}
