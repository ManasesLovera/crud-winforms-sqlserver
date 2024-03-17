using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;

namespace uapaTarea5
{
    public partial class Update : Form
    {
        public DataAccess.DataAccess dataAccess = new DataAccess.DataAccess();
        public string Name = String.Empty;
        public string Email = String.Empty;
        public double Salary = 0;
        public Update(string name, string email, double salary)
        {
            InitializeComponent();
            this.Name = name;
            this.Email = email;
            this.Salary = salary;
        }

        private void Update_Load(object sender, EventArgs e)
        {
            try
            {
                dataAccess.Update_CRUD(Name, Email, Salary, txtNewName.Text, txtNewEmail.Text, double.Parse(txtNewSalary.Text));
                MessageBox.Show(this, "Employee was updated correctly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
