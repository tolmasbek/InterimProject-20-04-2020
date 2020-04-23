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
            System.Console.WriteLine("1 Вход\n2 Выход\nВаш выбор: ");
            int ch = int.Parse(Console.ReadLine());
            switch(ch)
            {
                case 1:
                
                    System.Console.WriteLine("Войти как: \n1 Админ\n2 Пользователь\nВаш выбор: ");
                break;
                case 2:

                break;
                default:
                System.Console.WriteLine("Неверная команда: ");
                break;
            }
            


            Console.ReadKey();
        }   
    }
}
