using Business.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Business.Models
{
    public class ProizvodstvoDataAccessLayer
    {
        string connectionString = ConnectionString.CName;
        public IEnumerable<Proizvodstvo> GetAll()
        {
            List<Proizvodstvo> lstbudget = new List<Proizvodstvo>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAll_proizvodstvo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Proizvodstvo e = new Proizvodstvo();
                    e.Id = Convert.ToInt16(rdr["id"]);
                    e.Product = Convert.ToInt16(rdr["Product"]);
                    e.Amount = Convert.ToDouble(rdr["Amount"]);
                    e.Date = Convert.ToDateTime(rdr["Date"]);
                    e.Employee = Convert.ToByte(rdr["Employee"]);


                    lstbudget.Add(e);
                }
                con.Close();
            }
            return lstbudget;
        }
        public void Addproizvodstvo(Proizvodstvo proizvodstvo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert_proizvodstvo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Product", proizvodstvo.Product);
                cmd.Parameters.AddWithValue("@Amount", proizvodstvo.Amount);
                cmd.Parameters.AddWithValue("@Date", proizvodstvo.Date);
                cmd.Parameters.AddWithValue("@Employee", proizvodstvo.Employee);
         

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Updateproizvodstvo(Proizvodstvo proizvodstvo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Update_proizvodstvo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", proizvodstvo.Id);
                cmd.Parameters.AddWithValue("@Product", proizvodstvo.Product);
                cmd.Parameters.AddWithValue("@Amount", proizvodstvo.Amount);
                cmd.Parameters.AddWithValue("@Date", proizvodstvo.Date);
                cmd.Parameters.AddWithValue("@Employee", proizvodstvo.Employee);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Proizvodstvo Detailsproizvodstvo(short? id)
        {
            Proizvodstvo proizvodstvo = new Proizvodstvo();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Proizvodstvo WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    proizvodstvo.Id = Convert.ToInt16(rdr["id"]);
                    proizvodstvo.Product = Convert.ToInt16(rdr["Product"]);
                    proizvodstvo.Amount = Convert.ToDouble(rdr["Amount"]);
                    proizvodstvo.Date = Convert.ToDateTime(rdr["Date"]);
                    proizvodstvo.Employee = Convert.ToByte(rdr["Employee"]);


                }
            }
            return proizvodstvo;
        }
        public void Deleteproizvodstvo(short? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete_proizvodstvo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Proizvodstvo GetProizvodstvo(short? id)
        {
            Proizvodstvo proizvodstvo = new Proizvodstvo();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Check_proizvodstvo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {               
                    proizvodstvo.ProductName =(rdr["ProductName"]).ToString();
                    proizvodstvo.Amount = Convert.ToDouble(rdr["Amount"]);
                    proizvodstvo.Date = Convert.ToDateTime(rdr["Date"]);
                    proizvodstvo.EmployeeName =(rdr["EmployeeName"]).ToString();


                }
            }
            return proizvodstvo;
        }
    }
}
