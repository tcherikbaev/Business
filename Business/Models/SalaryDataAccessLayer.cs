using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Utility;
namespace Business.Models
{
    public class SalaryDataAccessLayer
    {
        string connectionString = ConnectionString.CName;
        public IEnumerable<Salary> GetAll()
        {
            List<Salary> lstbudget = new List<Salary>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAll_salary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Salary e = new Salary();
                    e.Id = Convert.ToInt16(rdr["id"]);
                    e.Name= Convert.ToByte(rdr["Name"]);
                    e.Year = Convert.ToInt16(rdr["Year"]);
                    e.Month = Convert.ToInt16(rdr["Month"]);
                    e.Date = Convert.ToDateTime(rdr["Date"]);
                    e.Oklad = Convert.ToInt32(rdr["Oklad"]);
                    e.CountStake = Convert.ToInt32(rdr["CountStake"]);
                    e.Bonus = Convert.ToInt32(rdr["Bonus"]);
                    e.Premia = Convert.ToInt32(rdr["Premia"]);
                    e.Total = Convert.ToInt32(rdr["Total"]);


                    lstbudget.Add(e);
                }
                con.Close();
            }
            return lstbudget;
        }
        public void Addsalary(Salary salary)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert_salary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", salary.Name);
                cmd.Parameters.AddWithValue("@Year", salary.Year);
                cmd.Parameters.AddWithValue("@Month", salary.Month);
                cmd.Parameters.AddWithValue("@Date", salary.Date);
                cmd.Parameters.AddWithValue("@Oklad", salary.Oklad);
                cmd.Parameters.AddWithValue("@CountStake", salary.CountStake);
                cmd.Parameters.AddWithValue("@Bonus", salary.Bonus);
                cmd.Parameters.AddWithValue("@Premia", salary.Premia);
                cmd.Parameters.AddWithValue("@Total", salary.Total);



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Updatesalary(Salary salary)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Update_salary", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", salary.Id);
                cmd.Parameters.AddWithValue("@Name", salary.Name);
                cmd.Parameters.AddWithValue("@Year", salary.Year);
                cmd.Parameters.AddWithValue("@Month", salary.Month);
                cmd.Parameters.AddWithValue("@Date", salary.Date);
                cmd.Parameters.AddWithValue("@Oklad", salary.Oklad);
                cmd.Parameters.AddWithValue("@CountStake", salary.CountStake);
                cmd.Parameters.AddWithValue("@Bonus", salary.Bonus);
                cmd.Parameters.AddWithValue("@Premia", salary.Premia);
                cmd.Parameters.AddWithValue("@Total", salary.Total);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Salary Detailssalary(short? id)
        {
            Salary salary = new Salary();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Salary WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    salary.Id = Convert.ToInt16(rdr["id"]);
                    salary.Name = Convert.ToByte(rdr["Name"]);
                    salary.Year = Convert.ToInt16(rdr["Year"]);
                    salary.Month = Convert.ToInt16(rdr["Month"]);
                    salary.Date = Convert.ToDateTime(rdr["Date"]);
                    salary.Oklad = Convert.ToInt32(rdr["Oklad"]);
                    salary.CountStake = Convert.ToInt32(rdr["CountStake"]);
                    salary.Bonus = Convert.ToInt32(rdr["Bonus"]);
                    salary.Premia = Convert.ToInt32(rdr["Premia"]);
                    salary.Total = Convert.ToInt32(rdr["Total"]);
                }
            }
            return salary;
        }
        public void Deletesalary(short? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete_salary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Salary GetSalary(short? id)
        {
            Salary salary = new Salary();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Check_salary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    salary.EmployeeName = (rdr["EmployeeName"]).ToString();
                    salary.Year = Convert.ToInt16(rdr["Year"]);
                    salary.MonthName = (rdr["MonthName"]).ToString();
                    salary.Date = Convert.ToDateTime(rdr["Date"]);
                    salary.Oklad = Convert.ToInt32(rdr["Oklad"]);
                    salary.CountStake = Convert.ToInt32(rdr["CountStake"]);
                    salary.Bonus = Convert.ToInt32(rdr["Bonus"]);
                    salary.Premia = Convert.ToInt32(rdr["Premia"]);
                    salary.Total = Convert.ToInt32(rdr["Total"]);


                }
            }
            return salary;
        }
    }
}
