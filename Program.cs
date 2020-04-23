using System;
using _AuthenticationSpace;
using _AnketaSpace;

namespace InterimProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("CREDIT SYSTEM");
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("1 Вход\n2 Регистрация\n3 Выход\nВаш выбор: ");
            int ch = int.Parse(Console.ReadLine());
            switch(ch)
            {
                case 1:
                {
                    System.Console.WriteLine("Войти как: \n1 Админ\n2 Пользователь\nВаш выбор: ");
                    int chi = int.Parse(Console.ReadLine());
                    switch(chi)
                    {
                        case 1:
                        {
                            
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Clear();
                            Authentication.GetLoginAndPassword(out string login, out string pass);
                        }break;
                        case 2:
                        {
                            Authentication.GetLoginAndPassword(out string login, out string pass);
                        }break;
                        default:
                        {

                        }break;
                    }
                             
                }break;
                case 2:
                {
                    Authentication.AddingUser(out string loginua, out string passua, out string roleua);
                }break;
                default:
                {
                    System.Console.WriteLine("Неверно");
                }break;
            }
            


            Console.ReadKey();
        }   
    }
}
