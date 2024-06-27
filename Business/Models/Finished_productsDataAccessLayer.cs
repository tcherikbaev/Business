using Business.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Finished_productsDataAccessLayer
    {
        string connectionString = ConnectionString.CName;
        public IEnumerable<FinishedProducts> GetAll()
        {
            List<FinishedProducts> lstbudget = new List<FinishedProducts>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAll_Finished_products", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    FinishedProducts e = new FinishedProducts();
                    e.Id = Convert.ToInt16(rdr["ID"]);
                    e.Name = (rdr["Name"]).ToString();
                    e.Unit = Convert.ToByte(rdr["Unit"]);
                    e.Sum = Convert.ToDecimal(rdr["Sum"]);
                    e.Quantity = Convert.ToDouble(rdr["Quantity"]);
                    
                    lstbudget.Add(e);
                }
                con.Close();
            }
            return lstbudget;
        }
        public void AddFinished_products(FinishedProducts finishedProducts)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert_Finished_products", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name ", finishedProducts.Name);
                cmd.Parameters.AddWithValue("@Unit", finishedProducts.Unit);
                cmd.Parameters.AddWithValue("@Sum", finishedProducts.Sum);
                cmd.Parameters.AddWithValue("@Quantity", finishedProducts.Quantity);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateFinished_products(FinishedProducts finishedProducts)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Update_Finished_products", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", finishedProducts.Id);
                cmd.Parameters.AddWithValue("@Name ", finishedProducts.Name);
                cmd.Parameters.AddWithValue("@Unit", finishedProducts.Unit);
                cmd.Parameters.AddWithValue("@Sum", finishedProducts.Sum);
                cmd.Parameters.AddWithValue("@Quantity", finishedProducts.Quantity);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public FinishedProducts DetailsFinishedProducts(short? id)
        {
            FinishedProducts finishedProducts = new FinishedProducts();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
            
                string sqlQuery = "SELECT * FROM [Finished_products:] WHERE ID= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    finishedProducts.Id = Convert.ToInt16(rdr["ID"]);
                    finishedProducts.Name = (rdr["Name"]).ToString();
                    finishedProducts.Unit = Convert.ToByte(rdr["Unit"]);
                    finishedProducts.Sum = Convert.ToDecimal(rdr["Sum"]);
                    finishedProducts.Quantity = Convert.ToDouble(rdr["Quantity"]);


                }
            }
            return finishedProducts;
        }
        public void DeleteFinishedProduct(short? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete_Finished_products", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public FinishedProducts GetFinishedProduct(short? id)
        {
            FinishedProducts finishedProducts = new FinishedProducts();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Check_Finished_Products", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                 
                  
  
                    finishedProducts.Name = (rdr["Name"]).ToString();
                    finishedProducts.UnitName = (rdr["UnitName"]).ToString();
               
                    finishedProducts.Sum = Convert.ToDecimal(rdr["Sum"]);
                    finishedProducts.Quantity = Convert.ToDouble(rdr["Quantity"]);


                }
            }
            return finishedProducts;
        }

    }
}
