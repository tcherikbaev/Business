using Business.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlTypes;
namespace Business.Models
{
    public class BudgetDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Budget> GetAllbudget()
        {
            List<Budget> lstbudget = new List<Budget>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAll_budget", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Budget budget = new Budget();
                    budget.Id = Convert.ToInt16(rdr["ID"]);   
                    budget.SumOfBudget = Convert.ToDecimal(rdr["Sum_Of_Budget"]);
                    budget.PremiaProcent = Convert.ToDouble(rdr["Premia_Procent"]);
                    budget.Nadbavka = Convert.ToDouble(rdr["Nadbavka"]);


                    lstbudget.Add(budget);
                }
                con.Close();
            }
            return lstbudget;
        }
        public void Addbudget(Budget budget)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert_Budget", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Sum_Of_Budget ", budget.SumOfBudget);
                cmd.Parameters.AddWithValue("@Premia_Procent",budget.PremiaProcent);
                cmd.Parameters.AddWithValue("@Nadbavka", budget.Nadbavka);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Updatebudget(Budget budget)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Update_budget", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", budget.Id);
                cmd.Parameters.AddWithValue("@Sum_Of_Budget",budget.SumOfBudget);
                cmd.Parameters.AddWithValue("@Premia_Procent", budget.PremiaProcent);
                cmd.Parameters.AddWithValue("@Nadbavka", budget.Nadbavka);
               
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Budget DetailsBudget(short? id)
        {
            Budget budget = new Budget();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM budget WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    budget.Id = Convert.ToInt16(rdr["Id"]);
                    budget.SumOfBudget = Convert.ToDecimal(rdr["Sum_Of_Budget"]);
                    budget.PremiaProcent = Convert.ToDouble(rdr["Premia_Procent"]);
                    budget.Nadbavka = Convert.ToDouble(rdr["Nadbavka"]);
                    
                }
            }
            return budget;
        }

        public void Deletebudget(short? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete_budget", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
