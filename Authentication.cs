using System;
using System.Data.SqlClient;
using System.Data;
using _DataAccessSpace;
namespace _AuthenticationSpace
{
    public class Authentication
    {
        public struct User
        {
          public int id;
          public String login;
          public String role;
        }
        public User GetLoginAndPassword(SqlConnection conn, string login, string pass)
        {
            Console.Write("Введите логин: ");
            login = Console.ReadLine();      
            Console.Write("Введите пароль: ");
            pass = Console.ReadLine();        

            string cmdLogPass = $"SELECT Id, Login, Role FROM Users where login = '{login}'";
           
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            SqlCommand com = new SqlCommand(cmdLogPass, conn);
            SqlDataReader reader = com.ExecuteReader();     
            User user;
            
            user.id = (int) reader.GetValue(0);
            user.login = (String) reader.GetValue(1);
            user.role = (string) reader.GetValue(3);

            reader.Close();
            conn.Close();

            return user;

        }
        public static void AddingUser(out string login, out string pass, out string role)
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
                AddingUser(out string loginua, out string passua, out string roleua);                    
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