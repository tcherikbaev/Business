using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Utility;

namespace Business.Models
{
    public class IngridientsDataAccessLayer
    {
        string connectionString = ConnectionString.CName;
        public IEnumerable<Ingridients> GetAll()
        {
            List<Ingridients> lstbudget = new List<Ingridients>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAll_Ingridients", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Ingridients e = new Ingridients();
                    e.Id = Convert.ToInt16(rdr["ID"]);
                    e.Product = Convert.ToInt16(rdr["Product"]);
                    e.RawProduct = Convert.ToInt16(rdr["Raw_Product"]);
                    e.Quntatity = Convert.ToDouble(rdr["Quntatity"]);

                    lstbudget.Add(e);
                }
                con.Close();
            }
            return lstbudget;
        }
        public void AddIngridients(Ingridients ingridients)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert_Ingridients", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Product ", ingridients.Product);
                cmd.Parameters.AddWithValue("@Raw_Product", ingridients.RawProduct);
                cmd.Parameters.AddWithValue("@Quntatity", ingridients.Quntatity);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateIngridients(Ingridients ingridients)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Update_Ingridients", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", ingridients.Id);
                cmd.Parameters.AddWithValue("@Product", ingridients.Product);
                cmd.Parameters.AddWithValue("@Raw_Product", ingridients.RawProduct);
                cmd.Parameters.AddWithValue("@Quntatity", ingridients.Quntatity);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Ingridients DetailsIngridients(short? id)
        {
            Ingridients ingridients= new Ingridients();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                string sqlQuery = "SELECT * FROM Ingridients WHERE ID= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    ingridients.Id = Convert.ToInt16(rdr["ID"]);
                    ingridients.Product = Convert.ToInt16(rdr["Product"]);
                    ingridients.RawProduct = Convert.ToInt16(rdr["Raw_Product"]);
                    ingridients.Quntatity = Convert.ToDouble(rdr["Quntatity"]);


                }
            }
            return ingridients;
        }
        public void DeleteIngridients(short? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete_Ingridients", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Ingridients GetIngridients(short? id)
        {
            Ingridients ingridients = new Ingridients();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Check_Ingridients", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                   
                 
                    ingridients.ProductName = (rdr["ProductName"]).ToString();
                    ingridients.RawName = (rdr["RawName"]).ToString();
                    ingridients.Quntatity = Convert.ToDouble(rdr["Quntatity"]);

                    


                }
            }
            return ingridients;
        }
    }
}
