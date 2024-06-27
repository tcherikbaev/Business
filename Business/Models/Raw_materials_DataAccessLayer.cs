using Business.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Raw_materials_DataAccessLayer
    {
        string connectionString = ConnectionString.CName;
        public IEnumerable<RawMaterials> GetAll()
        {
            List<RawMaterials> lstbudget = new List<RawMaterials>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAll_Raw_materials", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    RawMaterials e = new RawMaterials();
                    e.Id = Convert.ToInt16(rdr["ID"]);
                    e.Name = (rdr["Name"]).ToString();
                    e.Unit = Convert.ToByte(rdr["Unit"]);
                    e.Sum = Convert.ToDouble(rdr["Sum"]);
                    e.Quantity = Convert.ToDouble(rdr["Quantity"]);

                    lstbudget.Add(e);
                }
                con.Close();
            }
            return lstbudget;
        }
        public void AddRaw_materials(RawMaterials rawMaterials)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert_Raw_materials", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name ", rawMaterials.Name);
                cmd.Parameters.AddWithValue("@Unit", rawMaterials.Unit);
                cmd.Parameters.AddWithValue("@Sum", rawMaterials.Sum);
                cmd.Parameters.AddWithValue("@Quantity", rawMaterials.Quantity);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateRaw_materials(RawMaterials rawMaterials)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Update_Raw_materials", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", rawMaterials.Id);
                cmd.Parameters.AddWithValue("@Name ", rawMaterials.Name);
                cmd.Parameters.AddWithValue("@Unit", rawMaterials.Unit);
                cmd.Parameters.AddWithValue("@Sum", rawMaterials.Sum);
                cmd.Parameters.AddWithValue("@Quantity", rawMaterials.Quantity);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public RawMaterials DetailsRaw_materials(short? id)
        {
            RawMaterials rawMaterials = new RawMaterials();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                string sqlQuery = "SELECT * FROM Raw_materials WHERE ID= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                
                    rawMaterials.Id = Convert.ToInt16(rdr["ID"]);
                    rawMaterials.Name = (rdr["Name"]).ToString();
                    rawMaterials.Unit = Convert.ToByte(rdr["Unit"]);
                    rawMaterials.Sum = Convert.ToDouble(rdr["Sum"]);
                    rawMaterials.Quantity = Convert.ToDouble(rdr["Quantity"]);


                }
            }
            return rawMaterials;
        }
        public void DeleteRaw_materials(short? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete_Raw_materials", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public RawMaterials GetRawMaterials(short? id)
        {
            RawMaterials rawMaterials = new RawMaterials();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Check_Raw_materials", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {


                    rawMaterials.Name = (rdr["Name"]).ToString();
                    rawMaterials.UnitName = (rdr["UnitName"]).ToString();

                    rawMaterials.Sum = Convert.ToDouble(rdr["Sum"]);
                    rawMaterials.Quantity = Convert.ToDouble(rdr["Quantity"]);


                }
            }
            return rawMaterials;
        }
    }
}
