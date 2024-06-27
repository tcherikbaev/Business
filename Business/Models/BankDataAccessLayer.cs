using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Utility;

namespace Business.Models
{
    public class BankDataAccessLayer
    {
        string connectionString = ConnectionString.CName;
        public IEnumerable<Bank> GetAllbank()
        {
            List<Bank> lstbudget = new List<Bank>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAll_Bank", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Bank bank=new Bank();
                    bank.Id = Convert.ToInt16(rdr["ID"]);
                    bank.Sum = Convert.ToDouble(rdr["Sum"]);
                    bank.SrokInMonths = Convert.ToInt16(rdr["Srok_In_Months"]);
                    bank.ProcentPenya = Convert.ToInt16(rdr["Procent_Penya"]);
                    bank.Ostatok = Convert.ToDouble(rdr["Ostatok"]);


                    lstbudget.Add(bank);
                }
                con.Close();
            }
            return lstbudget;
        }
        public void AddBank(Bank bank)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert_Bank", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Sum ", bank.Sum);
                cmd.Parameters.AddWithValue("@Srok_In_Months", bank.SrokInMonths);
                cmd.Parameters.AddWithValue("@Procent_Penya", bank.ProcentPenya);
                cmd.Parameters.AddWithValue("@Ostatok", bank.Ostatok);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Updatebank(Bank bank)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Update_Bank", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", bank.Id);
                cmd.Parameters.AddWithValue("@Sum", bank.Sum);
                cmd.Parameters.AddWithValue("@Srok_In_Months", bank.SrokInMonths);
                cmd.Parameters.AddWithValue("@Procent_Penya", bank.ProcentPenya);
                cmd.Parameters.AddWithValue("@Ostatok", bank.Ostatok);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Bank DetailsBank(short? id)
        {
            Bank bank = new Bank();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM bank WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bank.Id = Convert.ToInt16(rdr["ID"]);
                    bank.Sum = Convert.ToDouble(rdr["Sum"]);
                    bank.SrokInMonths = Convert.ToInt16(rdr["Srok_In_Months"]);
                    bank.ProcentPenya = Convert.ToInt16(rdr["Procent_Penya"]);
                    bank.Ostatok = Convert.ToDouble(rdr["Ostatok"]);

                }
            }
            return bank;
        }
        public void Deletebank(short? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete_Bank", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
