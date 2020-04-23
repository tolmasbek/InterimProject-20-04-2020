using System;
using _AuthenticationSpace;
using System.Data.SqlClient;
using System.Data;
using _DataAccessSpace;

namespace InterimProject
{
    class Program
    {
        static void UserLogin(SqlConnection conn, Authentication.User user){
                Users cmd = new Users();
        
                cmd.Show(conn,user.id);

        }
        static void AdminLogin(SqlConnection conn, Authentication.User user){
                Admins cmd = new Admins();
                cmd.Show(conn, user.id);

        }
        static void Main(string[] args)
        {
            Users cmd = new Users();
            
            Authentication auth = new Authentication();
            SqlConnection conn = new SqlConnection(DataAccess.ConnectionString);
          //  auth.AddingUser(conn);          cmd.Order(conn, 1);
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("CREDIT SYSTEM");
            Console.ForegroundColor = ConsoleColor.White;
            while(true){
                System.Console.WriteLine("enter Вход\nexit Выход\nВаш выбор: ");
            string ch = Console.ReadLine();
            switch(ch)
            {
                case "enter":
                    
                    Authentication.User user;
                    user = auth.GetLoginAndPassword(conn);
                    if(user.err!="")
                    {
                        System.Console.WriteLine(user.err);
                        break;
                    }
                    if(user.role == "ADMIN")
                     {
                         System.Console.WriteLine("Вы вошли как админ ");
                         AdminLogin(conn, user);
                     }
                     else{
                         System.Console.WriteLine("Вы аошли как пользователь");
                         UserLogin(conn, user);
                     }
                break;
                case "exit":
                        return;
                default:
                System.Console.WriteLine("Неверная команда! ");
                break;
            }
            }
            
        }   
    }
}
