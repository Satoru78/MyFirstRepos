using ConsoleApp8;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp45
{
    class Program
    {
        internal static List<User> Users { get; set; }

        internal static int Action { get; set; }
        static void Main(string[] args)
        {
            static extern void Message(ConsoleColor green);
            {
                Console.WriteLine("Успешно");
            }


            static User ActionUser(User user)
            {
                if (user.ID == 0)
                {
                    user = new User();
                    Console.Write("Введите ваше ID: ");
                    user.ID = int.Parse(Console.ReadLine());
                }
                Console.Write("Введите имя: ");
                user.Name = Console.ReadLine();
                Console.Write("Введите логин: ");
                user.Username = Console.ReadLine();
                Console.Write("Введите пароль: ");
                user.Password = Console.ReadLine();
                return user;
            }


            Users = new List<User>();
            while (Action != 6)
            {

                ListCommands();

                static void ListCommands()
                {
                    Console.WriteLine("1. Добавить");
                    Console.WriteLine("2. Редактировать");
                    Console.WriteLine("3. Удалить");
                    Console.WriteLine("4. Просмотреть");
                    Console.WriteLine("5. Поиск");
                    Console.WriteLine("6. Закрыть");
                }


                try
                {
                    Console.WriteLine("Введите команду: ");


                    Action = int.Parse(Console.ReadLine());
                    switch (Action)
                    {

                        case 1:
                            Users.Add(ActionUser(new User()));

                            Console.WriteLine("Успешно!");
                            break;
                        case 2:

                            Console.Write("Введите ID: ");
                            int IdEdit = int.Parse(Console.ReadLine());
                            var EditUser = Users.FirstOrDefault(item => item.ID == IdEdit);
                            if (EditUser != null)
                            {


                                Console.WriteLine("Успешно!");
                            }
                            else
                            {
                                Console.WriteLine("Не найдено!");

                            }
                            break;
                        case 3:

                            Console.Write("Введите ID: ");
                            int IdRemove = int.Parse(Console.ReadLine());
                            var RemoveUser = Users.FirstOrDefault(item => item.ID == IdRemove);
                            if (RemoveUser != null)
                            {
                                Users.Remove(RemoveUser);

                                
                            }
                            else
                            {

                                Console.WriteLine("Не найдено!");
                            }
                            break;
                        case 4:

                            if (Users.Any())
                            {
                                foreach (var user in Users)
                                {
                                    Console.WriteLine(user.GetInfo());
                                }
                            }
                            else
                            {

                                Console.WriteLine("Не найдено!");
                            }
                            break;
                        case 5:

                            Console.Write("Введите данные: ");
                            string Search = Console.ReadLine();
                            var SearchUser = Users.Where(item => item.ID.ToString().Contains(Search) || item.Name.Contains(Search) ||
                            item.Username.Contains(Search) || item.Password.Contains(Search)).ToList();
                            if (SearchUser.Any())
                            {
                                foreach (var item in SearchUser)
                                {
                                    Console.WriteLine(item.GetInfo());
                                }
                            }
                            else
                            {

                                Console.WriteLine("Не найдено!");

                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }

        }






    }
}
  