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
          public string err;
          
        }
        public User NewUser(){
              User user;
                user.id=0;
                user.login="";
                user.role="";
                user.err="";
              return user;
          }
        public User GetLoginAndPassword(SqlConnection conn)
        {
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();      
            Console.Write("Введите пароль: ");
           string pass = Console.ReadLine();        

            string cmdLogPass = $"SELECT Id, Login, Role, Password FROM Users where login = '{login}'";
           
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            SqlCommand com = new SqlCommand(cmdLogPass, conn);
            
            SqlDataReader reader = com.ExecuteReader();     
            User user = NewUser();
            if(reader.Read())
            {
                user.id=(int) reader.GetValue(0);
                user.login=(string) reader.GetValue(1);
                user.role=(string) reader.GetValue(2);
                if(pass!=(string) reader.GetValue(3))
                    user.err="pasword mismatch";
            }         
            else
            {
                user.err="no such user";
            }   
            return user;
        }
        public void AddingUser(SqlConnection conn)
        {
            System.Console.WriteLine("Добавить Пользователя: ");
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();      
            Console.Write("Введите пароль: ");
            string pass = Console.ReadLine();     
            Console.Write("Повторите пароль: ");
            string repeatpass = Console.ReadLine();
            if(pass!= repeatpass)
            {
                return;
            }
           
              Console.Write("Введите роль Пользователя: \n1- администратор\n2- пользователь\n");
            string role = Console.ReadLine();
            switch(role){  
                case "1": role="ADMIN";  break;
                case "2": role="USER";  break;
                default: Console.Write("err"); return;
            }
                 
            string cmdLogPass = $"INSERT INTO Users([Login],[Password],[Role]) VALUES('{login}','{pass}','{role}')";
    
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