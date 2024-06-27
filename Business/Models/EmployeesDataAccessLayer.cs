using Business.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Models
{
    public class EmployeesDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Employees> GetAll()
        {
            List<Employees> lstbudget = new List<Employees>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAll_employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employees e = new Employees();
                    e.Id= Convert.ToByte(rdr["id"]);
                    e.Name = (rdr["Name"]).ToString();
                    e.Doljnost = Convert.ToByte(rdr["Doljnost"]);
                    e.Salary = Convert.ToDecimal(rdr["Salary"]);
                    e.Address = (rdr["Address"]).ToString();
                    e.Telephone = Convert.ToInt32(rdr["Telephone"]);


                    lstbudget.Add(e);
                }
                con.Close();
            }
            return lstbudget;
        }
        public void Addemployee(Employees employees)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name ", employees.Name);
                cmd.Parameters.AddWithValue("@Doljnost", employees.Doljnost);
                cmd.Parameters.AddWithValue("@Salary", employees.Salary);
                cmd.Parameters.AddWithValue("@Address", employees.Address);
                cmd.Parameters.AddWithValue("@Telephone", employees.Telephone);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateEmployee(Employees employees)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Update_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", employees.Id);
                cmd.Parameters.AddWithValue("@Name ", employees.Name);
                cmd.Parameters.AddWithValue("@Doljnost", employees.Doljnost);
                cmd.Parameters.AddWithValue("@Salary", employees.Salary);
                cmd.Parameters.AddWithValue("@Address", employees.Address);
                cmd.Parameters.AddWithValue("@Telephone", employees.Telephone);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Employees DetailsEmployee(byte? id)
        {
            Employees employees = new Employees();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Employees WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employees.Id = Convert.ToByte(rdr["Id"]);
                    employees.Name = (rdr["Name"]).ToString();
                    employees.Doljnost = Convert.ToByte(rdr["Doljnost"]);
                    employees.Salary = Convert.ToDecimal(rdr["Salary"]);
                    employees.Address = (rdr["Address"]).ToString();
                    employees.Telephone = Convert.ToInt32(rdr["Telephone"]);


                }
            }
            return employees;
        }
        public void DeleteEmployee(byte? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Employees GetEmployee(byte? id)
        {
            Employees employees = new Employees();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Check_employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employees.Name = (rdr["Name"]).ToString();
                    employees.DoljnostName = (rdr["DoljnostName"]).ToString();
                    employees.Salary = Convert.ToDecimal(rdr["Salary"]);
                    employees.Address = (rdr["Address"]).ToString();
                    employees.Telephone = Convert.ToInt32(rdr["Telephone"]);


                }
            }
            return employees;
        }

    }
}
