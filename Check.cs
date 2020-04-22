using System;
using System.Data.SqlClient;
using System.Data;
using _DataAccessSpace;

namespace _CheckSpace
{
    public class Check
    {
        public static void GetLoginAndPassword(out string login, out string pass)
        {
            Console.Write("Введите логин: ");           // Выводим пользователю приглашение ввести логин
            login = Console.ReadLine();                 // Получаем от пользователя логин
            Console.Write("Введите пароль: ");          // Выводим пользователю приглашение ввести пароль
            pass = Console.ReadLine();                  // Получаем от пользователя пароль

            string cmdLogPass = "SELECT * FROM Users";
            SqlConnection conn = new SqlConnection(DataAccess.ConnectionString);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            
            SqlCommand com = new SqlCommand(cmdLogPass, conn);
            SqlDataReader reader = com.ExecuteReader();     // Проверяем правильность логина и пароля
            while ((reader.Read()) && (login != $"{reader.GetValue(1)}" || pass != $"{reader.GetValue(2)}"))
            {
                Console.WriteLine("Вы ввели неверный пароль. Попробуйте снова.");
                GetLoginAndPassword(out login, out pass);
            }
            reader.Close();
            conn.Close();

            Console.WriteLine("Вы вошли в систему!");   // Выводим сообщение, что пользователь вошёл в систему
        }
    }
}