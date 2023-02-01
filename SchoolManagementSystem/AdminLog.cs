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
    public partial class AdminLog : Form
    {
        public AdminLog()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\C# Projects\Airport Management Sysytem New Edition\SchoolManagementSystem\AMSnew.accdb");
            con.Open();
            OleDbCommand com = new OleDbCommand("select * from Login where Username='" + txtUserName.Text + "' and Password='" + txtPassword.Text + "'", con);
              
            try
            {
                 int i;
                i = Convert.ToInt32(com.ExecuteScalar());
                if (i == 1)
                {
                    MessageBox.Show("Successfull Logged !!!","Success...",MessageBoxButtons.OK,MessageBoxIcon.Information);


                    AdminWindow m = new AdminWindow();
                    m.Show();
                    this.Hide();




                }
                else
                {
                    MessageBox.Show("Invalid User Name or Password !!!","Invalid...",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }

                txtUserName.Clear();
                txtPassword.Clear();
                txtUserName.Focus();
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
