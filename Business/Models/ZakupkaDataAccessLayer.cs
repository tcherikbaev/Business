using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Utility;

namespace Business.Models
{
    public class ZakupkaDataAccessLayer
    {
        string connectionString = ConnectionString.CName;
        public IEnumerable<ZakupkaRawMaterial> GetAll()
        {
            List<ZakupkaRawMaterial> lstbudget = new List<ZakupkaRawMaterial>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAll_zakupka", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ZakupkaRawMaterial e = new ZakupkaRawMaterial();
                    e.Id = Convert.ToInt16(rdr["id"]);
                    e.RawMaterial = Convert.ToInt16(rdr["Raw_Material"]);
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
        public void Addzakupka(ZakupkaRawMaterial zakupkaRawMaterial)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert_zakupka", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Raw_material", zakupkaRawMaterial.RawMaterial);
                cmd.Parameters.AddWithValue("@Amount", zakupkaRawMaterial.Amount);
                cmd.Parameters.AddWithValue("@Sum", zakupkaRawMaterial.Sum);
                cmd.Parameters.AddWithValue("@Date", zakupkaRawMaterial.Date);
                cmd.Parameters.AddWithValue("@Employee", zakupkaRawMaterial.Employee);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Updateproizvodstvo(ZakupkaRawMaterial zakupkaRawMaterial)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Update_zakupka", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", zakupkaRawMaterial.Id);
                cmd.Parameters.AddWithValue("@Raw_material", zakupkaRawMaterial.RawMaterial);
                cmd.Parameters.AddWithValue("@Amount", zakupkaRawMaterial.Amount);
                cmd.Parameters.AddWithValue("@Sum", zakupkaRawMaterial.Sum);
                cmd.Parameters.AddWithValue("@Date", zakupkaRawMaterial.Date);
                cmd.Parameters.AddWithValue("@Employee", zakupkaRawMaterial.Employee);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public ZakupkaRawMaterial Detailszakupka(short? id)
        {
            ZakupkaRawMaterial zakupkaRawMaterial = new ZakupkaRawMaterial();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM zakupka_raw_material WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    zakupkaRawMaterial.Id = Convert.ToInt16(rdr["id"]);
                    zakupkaRawMaterial.RawMaterial = Convert.ToInt16(rdr["Raw_Material"]);
                    zakupkaRawMaterial.Amount = Convert.ToDouble(rdr["Amount"]);
                    zakupkaRawMaterial.Sum = Convert.ToDecimal(rdr["Sum"]);
                    zakupkaRawMaterial.Date = Convert.ToDateTime(rdr["Date"]);
                    zakupkaRawMaterial.Employee = Convert.ToByte(rdr["Employee"]);


                }
            }
            return zakupkaRawMaterial;
        }
        public void Deletezakupka(short? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete_zakupka", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public ZakupkaRawMaterial GetZakupka(short? id)
        {
            ZakupkaRawMaterial zakupkaRawMaterial = new ZakupkaRawMaterial();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Check_zakupka", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    zakupkaRawMaterial.RawName = (rdr["RawName"]).ToString();
                    zakupkaRawMaterial.Amount = Convert.ToDouble(rdr["Amount"]);
                    zakupkaRawMaterial.Sum = Convert.ToDecimal(rdr["Sum"]);
                    zakupkaRawMaterial.Date = Convert.ToDateTime(rdr["Date"]);
                    zakupkaRawMaterial.EmployeeName = (rdr["EmployeeName"]).ToString();


                }
            }
            return zakupkaRawMaterial;
        }

    }
}
