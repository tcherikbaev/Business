using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Utility;

namespace Business.Models
{
    public class VyplataDataAccessLayer
    {
        string connectionString = ConnectionString.CName;
        public IEnumerable<Vyplata> GetAllVyplaty()
        {
            List<Vyplata> lstbudget = new List<Vyplata>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAll_vyplaty", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Vyplata vyplata = new Vyplata();
                    vyplata.Id = Convert.ToInt32(rdr["ID"]);
                    vyplata.Srok = Convert.ToDateTime(rdr["Srok"]);
                    vyplata.Oplachivaetsya = Convert.ToDateTime(rdr["Oplachivaetsya"]);
                    vyplata.Sum = Convert.ToDouble(rdr["Sum"]);
                    vyplata.Procent = Convert.ToDouble(rdr["Procent"]);
                    vyplata.Procts = Convert.ToDouble(rdr["Procts"]);
                    vyplata.Penya = Convert.ToDouble(rdr["Penya"]);
                    vyplata.Total= Convert.ToDouble(rdr["Total"]);
                    vyplata.Ostatok = Convert.ToDouble(rdr["Ostatok"]);

                    lstbudget.Add(vyplata);
                }
                con.Close();
            }
            return lstbudget;
        }
        public void Addvyplaty(Vyplata vyplata)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert_vyplaty", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Srok", vyplata.Srok);
                cmd.Parameters.AddWithValue("@Oplachivaetsya", vyplata.Oplachivaetsya);
                cmd.Parameters.AddWithValue("@Sum", vyplata.Sum);
                cmd.Parameters.AddWithValue("@Procent", vyplata.Procent);
                cmd.Parameters.AddWithValue("@Procts", vyplata.Procts);
                cmd.Parameters.AddWithValue("@Penya", vyplata.Penya);
                cmd.Parameters.AddWithValue("@Total", vyplata.Total);
                cmd.Parameters.AddWithValue("@Ostatok", vyplata.Ostatok);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Updatevyplaty(Vyplata vyplata)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Update_vyplaty", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID",vyplata.Id);
                cmd.Parameters.AddWithValue("@Srok", vyplata.Srok);
                cmd.Parameters.AddWithValue("@Oplachivaetsya", vyplata.Oplachivaetsya);
                cmd.Parameters.AddWithValue("@Sum", vyplata.Sum);
                cmd.Parameters.AddWithValue("@Procent", vyplata.Procent);
                cmd.Parameters.AddWithValue("@Procts", vyplata.Procts);
                cmd.Parameters.AddWithValue("@Penya", vyplata.Penya);
                cmd.Parameters.AddWithValue("@Total", vyplata.Total);
                cmd.Parameters.AddWithValue("@Ostatok", vyplata.Ostatok);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Vyplata DetailsVyplaty(int? id)
        {
            Vyplata vyplata = new Vyplata();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Vyplata WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                 
                    vyplata.Id = Convert.ToInt32(rdr["ID"]);
                    vyplata.Srok = Convert.ToDateTime(rdr["Srok"]);
                    vyplata.Oplachivaetsya = Convert.ToDateTime(rdr["Oplachivaetsya"]);
                    vyplata.Sum = Convert.ToDouble(rdr["Sum"]);
                    vyplata.Procent = Convert.ToDouble(rdr["Procent"]);
                    vyplata.Procts = Convert.ToDouble(rdr["Procts"]);
                    vyplata.Penya = Convert.ToDouble(rdr["Penya"]);
                    vyplata.Total = Convert.ToDouble(rdr["Total"]);
                    vyplata.Ostatok = Convert.ToDouble(rdr["Ostatok"]);

                }
            }
            return vyplata;
        }
        public void DeleteVyplaty(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete_vyplaty", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


    }
}
