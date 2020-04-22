using System;
using _AuthenticationSpace;

namespace InterimProject
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("1 Вход\n2 Выход");
            int ch = int.Parse(Console.ReadLine());
            switch(ch)
            {
                case 1:
                {
                    string login, pass;                             // Получаем от пользователя логин и пароль
                    Authentication.GetLoginAndPassword(out login, out pass);
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
