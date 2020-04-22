using System;
using _AuthenticationSpace;

namespace InterimProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("CREDIT SYSTEM");
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("1 Вход\n2 Регистрация\n3 Выход");
            int ch = int.Parse(Console.ReadLine());
            switch(ch)
            {
                case 1:
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    Authentication.GetLoginAndPassword(out string login, out string pass);
                             
                }break;
                case 2:
                {
                    
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
