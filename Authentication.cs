using System;
using System.Data.SqlClient;
using System.Data;
using _DataAccessSpace;

namespace _AuthenticationSpace
{
    public class Authentication
    {
        public static void GetLoginAndPassword(out string login, out string pass)
        {
            Console.Write("Введите логин: ");
            login = Console.ReadLine();      
            Console.Write("Введите пароль: ");
            pass = Console.ReadLine();        

            string cmdLogPass = "SELECT * FROM Users";
            SqlConnection conn = new SqlConnection(DataAccess.ConnectionString);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            SqlCommand com = new SqlCommand(cmdLogPass, conn);
            SqlDataReader reader = com.ExecuteReader();     
            while ((reader.Read()) && (login != $"{reader.GetValue(1)}" || pass != $"{reader.GetValue(2)}"))
            {
                Console.WriteLine("Вы ввели неверный пароль. Попробуйте снова.");
                
                GetLoginAndPassword(out login, out pass);
            }
            reader.Close();
            conn.Close();

            // Вызывает метод добавляющий пользователей и Админа
            AddingUsersAndAdmin(out string loginua, out string passua, out string roleua);
                 
        }
        public static void AddingUsersAndAdmin(out string login, out string pass, out string role)
        {
            System.Console.WriteLine("Добавить Пользователя: ");
            Console.Write("Введите логин: ");
            login = Console.ReadLine();      
            Console.Write("Введите пароль: ");
            pass = Console.ReadLine();     
            Console.Write("Повторите пароль: ");
            string repeatpass = Console.ReadLine();
            Console.Write("Введите роль Пользователя: ");
            role = Console.ReadLine();         

            string cmdLogPass = $"INSERT INTO Users([Login],[Password],[Role]) VALUES('{login}','{pass}','{role}')";
            if(pass != repeatpass)
            {
                System.Console.WriteLine("Логин или пароль не верный. Попробуйте заново");
                AddingUsersAndAdmin(out string loginua, out string passua, out string roleua);                    
            }
            SqlConnection conn = new SqlConnection(DataAccess.ConnectionString);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            SqlCommand com = new SqlCommand(cmdLogPass, conn);
            var result = com.ExecuteNonQuery();
            conn.Close();

            Console.WriteLine("Пользователь добавлен!");
        }
    }
}