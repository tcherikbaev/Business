using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Utility;

namespace Business.Models
{
    public class ProdajaDataAccessLayer
    {
        string connectionString = ConnectionString.CName;
        public IEnumerable<ProdajaProduction> GetAll()
        {
            List<ProdajaProduction> lstbudget = new List<ProdajaProduction>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAll_Prodaja_production", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ProdajaProduction e = new ProdajaProduction();
                    e.Id = Convert.ToInt16(rdr["id"]);
                    e.Production = Convert.ToInt16(rdr["Production"]);
                    e.Amount = Convert.ToDouble(rdr["Amount"]);
                    e.Sum = Convert.ToDecimal(rdr["Sum"]);
                    e.Date = Convert.ToDateTime(rdr["Date"]);
                    e.Employee = Convert.ToByte(rdr["Employee"]);


                    lstbudget.Add(e);
                }
                con.Close();
            }
            return lstbudget;
        }
        public void Addprodaja(ProdajaProduction prodajaProduction)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert_Prodaja_production", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Production", prodajaProduction.Production);
                cmd.Parameters.AddWithValue("@Amount", prodajaProduction.Amount);
                cmd.Parameters.AddWithValue("@Sum", prodajaProduction.Sum);
                cmd.Parameters.AddWithValue("@Date", prodajaProduction.Date);
                cmd.Parameters.AddWithValue("@Employee", prodajaProduction.Employee);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Updateprodaja(ProdajaProduction prodajaProduction)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Update_Prodaja_production", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", prodajaProduction.Id);
                cmd.Parameters.AddWithValue("@Production", prodajaProduction.Production);
                cmd.Parameters.AddWithValue("@Amount", prodajaProduction.Amount);
                cmd.Parameters.AddWithValue("@Sum", prodajaProduction.Sum);
                cmd.Parameters.AddWithValue("@Date", prodajaProduction.Date);
                cmd.Parameters.AddWithValue("@Employee", prodajaProduction.Employee);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public ProdajaProduction Detailsprodaja(short? id)
        {
         ProdajaProduction prodajaProduction=new ProdajaProduction();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM prodaja_production WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    prodajaProduction.Id = Convert.ToInt16(rdr["id"]);
                    prodajaProduction.Production = Convert.ToInt16(rdr["Production"]);
                    prodajaProduction.Amount = Convert.ToDouble(rdr["Amount"]);
                    prodajaProduction.Sum = Convert.ToDecimal(rdr["Sum"]);
                    prodajaProduction.Date = Convert.ToDateTime(rdr["Date"]);
                    prodajaProduction.Employee = Convert.ToByte(rdr["Employee"]);


                }
            }
            return prodajaProduction;
        }
        public void Deletezakupka(short? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete_Prodaja_production", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public ProdajaProduction Getprodaja(short? id)
        {
            ProdajaProduction prodajaProduction = new ProdajaProduction();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Check_Prodaja_production", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    prodajaProduction.ProductName = (rdr["ProductName"]).ToString();
                    prodajaProduction.Amount = Convert.ToDouble(rdr["Amount"]);
                    prodajaProduction.Sum = Convert.ToDecimal(rdr["Sum"]);
                    prodajaProduction.Date = Convert.ToDateTime(rdr["Date"]);
                    prodajaProduction.EmployeeName=(rdr["EmployeeName"]).ToString();


                }
            }
            return prodajaProduction;
        }
    }
}
