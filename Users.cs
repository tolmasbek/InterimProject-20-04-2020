using System;
using System.Data.SqlClient;
using System.Data;

namespace InterimProject
{
    public class Users
    {
        public void OrderList(SqlConnection conn, int id_card)
        {
            string cmdLogPass = $"SELECT Id, CreditHistory, DelayInCreditHistory, CreditPurpose, CreditTerm, Status FROM Anketa WHERE {id_card}";
            if (conn.State == ConnectionState.Open)
            {   conn.Close();   }
            conn.Open();

            SqlCommand com = new SqlCommand(cmdLogPass, conn);
            SqlDataReader reader = com.ExecuteReader();
            while(reader.Read())
            {
                System.Console.WriteLine($"Id_Anketa: {reader.GetValue(12)},\nСумма кредита от общего дохода: {reader.GetValue(5)},\nКредитная история: {reader.GetValue(6)},\nПросрока в кред ист: {reader.GetValue(7)},\nЦель кредита: {reader.GetValue(8)},\nСрок кредита: {reader.GetValue(9)},\nСтатус: {reader.GetValue(11)}");
            }
            reader.Close();
            conn.Close();
        }
        
        public void Order(SqlConnection conn, int user_id){
            int ball = 0;
            System.Console.WriteLine("Заполните поля:");
            System.Console.WriteLine("Пол:1 - Муж\n2 - Жен ");
            string Gender = Console.ReadLine();
            if(Gender == "1") {Gender = "муж"; ball++; } else { Gender = "жен"; ball += 2; }

            System.Console.WriteLine("Семейное положение: \n1 - холост\n2 - семянин\n3 - в разводе\n4 - вдовец/вдова");
            string FamilyStatus = Console.ReadLine();
            if(FamilyStatus == "1"){ FamilyStatus = "холост";   ball ++; }
            if(FamilyStatus == "2"){ FamilyStatus = "семянин";  ball += 2; }
            if(FamilyStatus == "3"){ FamilyStatus = "вразводе";  ball ++; }
            if(FamilyStatus == "4")
            { if(Gender == "male"){ FamilyStatus = "вдовец";  ball += 2; } else
                                  { FamilyStatus = "вдова";  ball += 2; } 
            }
            System.Console.WriteLine("Гражданство: \n1 - Таджикистан\n2 - Зарубеж");
            string Nationality = Console.ReadLine();
            if(Nationality == "1") {Nationality = "Таджикистан"; ball++; } else { Nationality = "зарубеж";}

            System.Console.WriteLine("Сумма кредита от общего дохода:  \n1 до 80%\n2 до 80 - 150%\n3 150 - 250%\n4 свыше 250%");
            string AmountTotalIncome = Console.ReadLine();
            if(AmountTotalIncome == "1"){ AmountTotalIncome = "до 80%";   ball += 4; }
            if(AmountTotalIncome == "2"){ AmountTotalIncome = "80 - 150% ";  ball += 3; }
            if(AmountTotalIncome == "3"){ AmountTotalIncome = "150 - 250%";  ball += 2; }
            if(AmountTotalIncome == "4"){ AmountTotalIncome = "свыше 250%";  ball ++; }
            
            System.Console.WriteLine("Кредитная история:  \n1 - более 3-ёх закр кредитов\n2 - 1-2 закр кредита\n3 - нет кредитной истории");
            string CreditHistory = Console.ReadLine();
            if(CreditHistory == "1"){ CreditHistory = ">3 раза закр кредитов";  ball += 2; }
            if(CreditHistory == "2"){ CreditHistory = "1-2 закр кредита";  ball++; }
            if(CreditHistory == "3"){ CreditHistory = "нет кред ист";  ball -= 1; }

            System.Console.WriteLine("Просрока в кредитной истории:\n1 - свыше 7 раз\n2 -   5 - 7 раз\n3 -  4 раза\n4 -  до 3 раза");
            string DelayInCreditHistory = Console.ReadLine();
            if(DelayInCreditHistory == "1"){ DelayInCreditHistory = "свыше 7 раз";   ball -= 3; }
            if(DelayInCreditHistory == "2"){ DelayInCreditHistory = "5 - 7 раз";  ball -= 2; }
            if(DelayInCreditHistory == "3"){ DelayInCreditHistory = "4 раза";  ball -= 1; }
            if(DelayInCreditHistory == "4"){ DelayInCreditHistory = "до 3 раз"; }

            System.Console.WriteLine("Цель кредита:\n1 - Бытовая техника\n2 - ремонт\n3 - телефон\n4 - прочее");
            string CreditPurpose = Console.ReadLine();
            if(CreditPurpose == "1"){ CreditPurpose = "быт техника";   ball += 2; }
            if(CreditPurpose == "2"){ CreditPurpose = "ремонт";  ball++; }
            if(CreditPurpose == "3"){ CreditPurpose = "телефон"; }
            if(CreditPurpose == "4"){ CreditPurpose = "прочее"; ball -= 1;}
            
            System.Console.WriteLine("Срок кредита \n1 - более 12 мес\n2 - до 12 мес");
            string CreditTerm = Console.ReadLine();
            if(CreditTerm == "1") {CreditTerm = "до 12 мес"; ball++; } else { CreditTerm = "более 12 мес"; ball++; }
            
            string Status = "";
            if(ball > 11)
            {
                Console.WriteLine($"Ваш балл = {ball}, Ваша заявка Прията!");
                Status = "одобрено";
            }
            else
            {
                Console.WriteLine($"Ваш балл <11 = {ball}, Ваша заявка Не прията!");
                Status = "отказано";
            }
            

            string cmdLogPass = $"INSERT INTO Anketa([Gender],[FamilyStatus],[Nationality],[AmountTotalIncome],[CreditHistory],[DelayInCreditHistory],[CreditPurpose],[CreditTerm],[Status])" + 
            "VALUES('{Gender}','{FamilyStatus}','{Nationality}','{AmountTotalIncome}','{CreditHistory}','{DelayInCreditHistory}','{CreditPurpose}','{CreditTerm}','{Status}')";
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            SqlCommand com = new SqlCommand(cmdLogPass, conn);
            var result = com.ExecuteNonQuery();
            conn.Close();           
        }
    }
}