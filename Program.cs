using System;
using _CheckSpace;

namespace InterimProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string login, pass;                             // Получаем от пользователя логин и пароль
            Check.GetLoginAndPassword(out login, out pass);

            Console.ReadKey();
        }   
    }
}
