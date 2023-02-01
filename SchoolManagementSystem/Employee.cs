using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SchoolManagementSystem
{
    public partial class Employee : Form
    {
        public Employee()
        {
           
            InitializeComponent();
            
        }
        private void Employee_Load(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            txtFirstName.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;

            txtFirstName.Clear();
            txtLastName.Clear();
            txtDateOfBirth.Clear();
            cmbGender.SelectedItem = null;
            txtEmail.Clear();
            txtMobilePhone.Clear();
            txtNICNumber.Clear();
            txtPosition.Clear();
            txtAddress.Clear();

            txtFirstName.Focus();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtFirstName.Text == "")
            {
                MessageBox.Show("Insert 'First Name'", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFirstName.Focus();
            }

            else if (txtLastName.Text == "")
            {
                MessageBox.Show("Insert 'Last Name'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                txtLastName.Focus();
            }
            else if (txtDateOfBirth.Text == "")
            {
                MessageBox.Show("Insert 'Date Of Birth'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                txtDateOfBirth.Focus();
            }
            else if (cmbGender.SelectedValue == "")
            {
                MessageBox.Show("Select 'Gender'..", "Select...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                cmbGender.Focus();
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Insert 'Email'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                txtEmail.Focus();
            }
            else if (txtMobilePhone.Text == "")
            {
                MessageBox.Show("Insert 'Mobile Phone'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                txtMobilePhone.Focus();
            }
            else if (txtNICNumber.Text == "")
            {
                MessageBox.Show("Insert 'NIC Number'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                txtNICNumber.Focus();
            }
            else if (txtPosition.Text == "")
            {
                MessageBox.Show("Insert 'Position'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                txtPosition.Focus();
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Insert 'Address'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                txtAddress.Focus();
            }
            else
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\C# Projects\Airport Management Sysytem New Edition\SchoolManagementSystem\AMSnew.accdb");
                con.Open();
                OleDbCommand com = new OleDbCommand("INSERT INTO Employees (FirstName, LastName, DOB, Gender, Address, [Position], Email, MobilePhone, NICNumber) VALUES ('"+txtFirstName.Text+"', '"+txtLastName.Text+"', '"+txtDateOfBirth.Text+"', '"+cmbGender.SelectedItem+"', '"+txtAddress.Text+"', '"+txtPosition.Text+"', '"+txtEmail.Text+"', '"+txtMobilePhone.Text+"', '"+txtNICNumber.Text+"')", con);

                com.ExecuteNonQuery();
                MessageBox.Show("Successfuly inserted", "Success...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();

                txtFirstName.Clear();
                txtLastName.Clear();
                txtDateOfBirth.Clear();
                cmbGender.SelectedItem = null;
                txtEmail.Clear();
                txtMobilePhone.Clear();
                txtNICNumber.Clear();
                txtPosition.Clear();
                txtAddress.Clear();
                panel1.Enabled = false;

                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            OleDbDataReader dr;
            OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\C# Projects\Airport Management Sysytem New Edition\SchoolManagementSystem\AMSnew.accdb");
            try
            {
                OleDbCommand com = new OleDbCommand("SELECT * FROM Employees WHERE FirstName='" + txtFirstName.Text + "'", Con);
                Con.Open();
                dr = com.ExecuteReader();
                dr.Read();
                txtFirstName.Text = dr[0].ToString();
                txtLastName.Text = dr[1].ToString();
                txtDateOfBirth.Text = dr[2].ToString();
                cmbGender.SelectedValue = dr[3].ToString();
                txtEmail.Text = dr[4].ToString();
                txtMobilePhone.Text = dr[5].ToString();
                txtNICNumber.Text = dr[6].ToString();
                txtPosition.Text = dr[7].ToString();
                txtAddress.Text = dr[8].ToString();
                
                dr.Close();
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            AdminWindow AdminWindow = new AdminWindow();
            AdminWindow.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //DELETE FROM Employees
            if (MessageBox.Show("Are you Sure?", "Delete...", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                OleDbConnection conDelete = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\C# Projects\Airport Management Sysytem New Edition\SchoolManagementSystem\AMSnew.accdb");
                conDelete.Open();
                OleDbCommand comDelete = new OleDbCommand("DELETE FROM Employees WHERE FirstName ='" + txtFirstName.Text + "' ", conDelete);
                panel1.Enabled = false;
                comDelete.ExecuteNonQuery();
                MessageBox.Show("Deleted record.", "Deleted...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conDelete.Close();

                txtFirstName.Clear();
                txtLastName.Clear();
                txtDateOfBirth.Clear();
                cmbGender.SelectedItem = null;
                txtEmail.Clear();
                txtMobilePhone.Clear();
                txtNICNumber.Clear();
                txtPosition.Clear();
                txtAddress.Clear();
                panel1.Enabled = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            //UPDATE Employees
            OleDbConnection conUpdate = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\C# Projects\Airport Management Sysytem New Edition\SchoolManagementSystem\AMSnew.accdb");
            conUpdate.Open(); //FirstName ='"+txtFirstName.Text+"',
            OleDbCommand comUpdate = new OleDbCommand("UPDATE Employees SET  LastName ='"+txtLastName.Text+"', DOB ='"+txtDateOfBirth.Text+"', Gender ='"+cmbGender.SelectedValue+"', Address ='"+txtAddress.Text+"', [Position] ='"+txtPosition.Text+"', Email ='"+txtEmail.Text+"', MobilePhone ='"+txtMobilePhone.Text+"', NICNumber ='"+txtNICNumber.Text+"'", conUpdate);
            comUpdate.ExecuteNonQuery();
            MessageBox.Show("Update Successful!!!", "Update...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conUpdate.Close();

            txtFirstName.Clear();
            txtLastName.Clear();
            txtDateOfBirth.Clear();
            cmbGender.SelectedItem = null;
            txtEmail.Clear();
            txtMobilePhone.Clear();
            txtNICNumber.Clear();
            txtPosition.Clear();
            txtAddress.Clear();
            panel1.Enabled = false;
        }

       
    }
}
