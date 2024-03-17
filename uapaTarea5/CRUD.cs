using System.Data;
using System.Data.SqlClient;
using DataAccess;

namespace uapaTarea5
{
    public partial class CRUD : Form
    {
        public CRUD()
        {
            InitializeComponent();
        }
        public DataAccess.DataAccess dataAccess = new DataAccess.DataAccess();

        private void CRUD_Load(object sender, EventArgs e)
        {
            try
            {
                dataAccess.Read_CRUD(dataGridViewEmployees);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string salary = txtSalary.Text.Trim();

                if (!String.IsNullOrEmpty(name) || !String.IsNullOrEmpty(email) || !String.IsNullOrEmpty(salary))
                {
                    dataAccess.InsertInto_CRUD(name, email, double.Parse(salary));
                    dataAccess.Read_CRUD(dataGridViewEmployees);
                }
                else
                {
                    MessageBox.Show(this, "Text boxes must contain someting, please fill all of them.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtSalary.Text = "";
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string salary = txtSalary.Text.Trim();

                if (!String.IsNullOrEmpty(name) || !String.IsNullOrEmpty(email) || !String.IsNullOrEmpty(salary))
                {
                    dataAccess.Delete_CRUD(name, email, double.Parse(salary));
                    dataAccess.Read_CRUD(dataGridViewEmployees);
                }
                else
                {
                    MessageBox.Show(this, "Text boxes must contain someting, please fill all of them.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            Update update = new Update(txtName.Text.Trim(),txtEmail.Text.Trim(), double.Parse(txtSalary.Text.Trim()));
            update.ShowDialog();
        }
    }
}