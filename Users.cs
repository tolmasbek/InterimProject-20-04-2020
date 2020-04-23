using System;
using System.Data.SqlClient;
using System.Data;

namespace InterimProject
{
    public class Users
    {

        public void Order(SqlConnection conn, int user_id){
            System.Console.WriteLine("Заполните поля:");
            System.Console.WriteLine("Пол:1 - Муж\n2 - Жен ");
            string Gender = Console.ReadLine();
            System.Console.WriteLine("Семейное положение: \n1 - холост\n2 - семянин\n3 - в разводе\n4 - вдовец/вдова");
            string FamilyStatus = Console.ReadLine();
            System.Console.WriteLine("Гражданство: \n1 - Таджикистан\n2 - Зарубеж");
            string Nationality = Console.ReadLine();
            System.Console.WriteLine("Сумма кредита от общего дохода:  \n1 до 80%\n2 до 80 - 150%\n3 150 - 250%\n4 свыше 250%");
            string AmountTotalIncome = Console.ReadLine();
            System.Console.WriteLine("Кредитная история:  \n1 - более 3-ёх закр кредитов\n2 - 1-2 закр кредита\n3 - нет кредитной истории");
            string CreditHistory = Console.ReadLine();
            System.Console.WriteLine("Просрока в кредитной истории:\n1 - свыше 7 раз\n2 -   5 - 7 раз\n3 -  4 раза\n4 -  до 3 раза");
            string DelayInCreditHistory = Console.ReadLine();
            System.Console.WriteLine("Цель кредита:\n1 - Бытовая техника\n2 - ремонт\n3 - телефон\n4 - прочее");
            string CreditPurpose = Console.ReadLine();
            System.Console.WriteLine("Срок кредита \n1 - более 12 мес\n2 - до 12 мес");
            string CreditTerm = Console.ReadLine();
            
            string cmdLogPass = $"INSERT INTO Anketa([Gender],[FamilyStatus],[Nationality],[AmountTotalIncome],[CreditHistory],[DelayInCreditHistory],[CreditPurpose],[CreditTerm])" + 
            "VALUES('{Gender}','{FamilyStatus}','{Nationality}','{AmountTotalIncome}','{CreditHistory}','{DelayInCreditHistory}','{CreditPurpose}','{CreditTerm}')";
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            SqlCommand com = new SqlCommand(cmdLogPass, conn);
            var result = com.ExecuteNonQuery();
            conn.Close();

            Console.WriteLine("Запись добавлен!");
        }
    }
}