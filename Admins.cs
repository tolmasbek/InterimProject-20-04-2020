using System;
using System.Data.SqlClient;
using System.Data;
using _AuthenticationSpace;
namespace InterimProject
{
    public class Admins : Users
    {
        public override void Show(SqlConnection conn, int id)
        {
            while(true)
            {
               System.Console.WriteLine("Команды \nnew - добавить нового пользователя\nadd - новая заявка\nlist - мои заявки\nexit - разлогиниться");
            string cmd = Console.ReadLine();
            switch(cmd){
                case "new":
                    Authentication auth = new Authentication();
                    auth.AddingUser(conn);
                 break;
                case "add":
                    Order(conn,id);
                 break;
                case "list":
                    OrderList(conn, id);
                 break;
                case "exit": return;
                default: System.Console.WriteLine("wrong command"); break;
            } 
            }
            
        }
    }
}