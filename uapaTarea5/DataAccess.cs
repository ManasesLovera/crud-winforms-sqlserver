using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using uapaTarea5;

namespace DataAccess
{
    public class DataAccess
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public void Read_CRUD(DataGridView dataGridViewEmployees)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string sqlSelect = "SELECT * FROM dbo.employees";
                SqlCommand cmdSelect = new SqlCommand(sqlSelect, connection);

                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmdSelect);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewEmployees.DataSource = dataTable;
                dataGridViewEmployees.Columns["id"].HeaderText = "ID";
                dataGridViewEmployees.Columns["name"].HeaderText = "Name";
                dataGridViewEmployees.Columns["email"].HeaderText = "Email";
                dataGridViewEmployees.Columns["salary"].HeaderText = "Salary";

                connection.Close();
            }
        }
        public void InsertInto_CRUD(string name, string email, double salary)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    string sqlInsert = "INSERT INTO dbo.Employees (name, email, salary) VALUES (@Name, @Email, @Salary)";
                    SqlCommand cmdInsert = new SqlCommand(sqlInsert, connection);
                    cmdInsert.Parameters.AddWithValue("@Name", name);
                    cmdInsert.Parameters.AddWithValue("@Email", email);
                    cmdInsert.Parameters.AddWithValue("@Salary", salary);
                    connection.Open();
                    cmdInsert.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void Delete_CRUD(string name, string email, double salary)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    string sqlDelete = "DELETE FROM dbo.Employees WHERE email='@Email' AND salary='@Salary'";
                    SqlCommand cmdDelete = new SqlCommand(sqlDelete, connection);
                    cmdDelete.Parameters.AddWithValue("@Name", name);
                    cmdDelete.Parameters.AddWithValue("@Email", email);
                    cmdDelete.Parameters.AddWithValue("@Salary", salary);
                    connection.Open();
                    cmdDelete.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Update_CRUD(string name, string email, double salary, string newName, string newEmail, double newSalary)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    string sqlUpdate = $"UPDATE dbo.Employees SET name='@newName', email='@newEmail', salary='@newSalary' WHERE name='@Name' AND email='@Email'";
                    SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, connection);
                    cmdUpdate.Parameters.AddWithValue("@Name", name);
                    cmdUpdate.Parameters.AddWithValue("@Email", email);
                    cmdUpdate.Parameters.AddWithValue("@Salary", salary);
                    cmdUpdate.Parameters.AddWithValue("@newName", newName);
                    cmdUpdate.Parameters.AddWithValue("@newEmail", newEmail);
                    cmdUpdate.Parameters.AddWithValue("@newSalary", newSalary);
                    
                    connection.Open();
                    cmdUpdate.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
