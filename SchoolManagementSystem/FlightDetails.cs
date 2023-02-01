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
    public partial class FlightDetails : Form
    {
        public FlightDetails()
        {
            InitializeComponent();
        }
           

        private void FlightDetails_Load(object sender, EventArgs e)
        {
            panel.Enabled = false;
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            panel.Enabled = true;
            txtFlightUL.Focus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminWindow AdminWindow = new AdminWindow();
            AdminWindow.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFlightUL.Text == "")
            {
                MessageBox.Show("Insert 'FlightUL'", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFlightUL.Focus();
            }

           else if (txtFrom.Text == "")
            {
                MessageBox.Show("Insert 'From'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel.Enabled = true;
                txtFrom.Focus();
            }
            else if (txtTo.Text == "")
            {
                MessageBox.Show("Insert 'To'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel.Enabled = true;
                txtTo.Focus();
            }
            else if (txtDate.Text == "")
            {
                MessageBox.Show("Insert 'Date'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel.Enabled = true;
                txtDate.Focus();
            }
            else if (txtTime.Text == "")
            {
                MessageBox.Show("Insert 'Time'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel.Enabled = true;
                txtTime.Focus();
            }
            else
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\C# Projects\Airport Management Sysytem New Edition\SchoolManagementSystem\AMSnew.accdb");
                con.Open();

                OleDbCommand com = new OleDbCommand("INSERT INTO Flight (FlightUL, [From], [To], [Date], [Time]) VALUES ('" + txtFlightUL.Text + "', '" + txtFrom.Text + "', '" + txtTo.Text + "', '" + txtDate.Text + "', '" + txtTime.Text + "')", con);

                com.ExecuteNonQuery();
                MessageBox.Show("Successfuly inserted", "Success...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();

                txtFlightUL.Clear();
                txtFrom.Clear();
                txtTo.Clear();
                txtDate.Clear();
                txtTime.Clear();
                panel.Enabled = false;
            }
        }

        private void txtFrom_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
        
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            panel.Enabled = true;
            OleDbDataReader dr;
            OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\C# Projects\Airport Management Sysytem New Edition\SchoolManagementSystem\AMSnew.accdb");
            try
            {
                OleDbCommand com = new OleDbCommand("SELECT * FROM Flight WHERE FlightUL='" + txtFlightUL.Text + "'", Con);
                Con.Open();
                dr = com.ExecuteReader();
                dr.Read();
                txtFlightUL.Text = dr[0].ToString();
                txtFrom.Text = dr[1].ToString();
                txtTo.Text = dr[2].ToString();
                txtDate.Text = dr[3].ToString();
                txtTime.Text = dr[4].ToString();

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

        private void txtFlightUL_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\C# Projects\Airport Management Sysytem New Edition\SchoolManagementSystem\AMSnew.accdb");
            con.Open();
            OleDbCommand com = new OleDbCommand("UPDATE Flight SET FlightUL ='" + txtFlightUL.Text + "', [From] ='" + txtFrom.Text + "', [To] ='" + txtTo.Text + "', [Date] ='" + txtDate.Text + "', [Time] ='" + txtTime.Text + "' WHERE FlightUL ='" + txtFlightUL.Text + "'", con);
            com.ExecuteNonQuery();
            MessageBox.Show("Update Successful!!!", "Update",MessageBoxButtons.OK,MessageBoxIcon.Information);
            con.Close();

            txtFlightUL.Focus();
            txtFlightUL.Clear();
            txtFrom.Clear();
            txtTo.Clear();
            txtDate.Clear();
            txtTime.Clear();
            panel.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // DELETE FROM Flight FlightUL ='" + txtFlightUL.Text + "'
            if (MessageBox.Show("Are you Sure?", "Delete...", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\C# Projects\Airport Management Sysytem New Edition\SchoolManagementSystem\AMSnew.accdb");
                con.Open();
                OleDbCommand com = new OleDbCommand("DELETE FROM Flight WHERE FlightUL ='" + txtFlightUL.Text + "'", con);
                com.ExecuteNonQuery();
                MessageBox.Show("Deleted record.", "Deleted...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                con.Close();
                txtFlightUL.Focus();
                txtFlightUL.Clear();
                txtFrom.Clear();
                txtTo.Clear();
                txtDate.Clear();
                txtTime.Clear();
                panel.Enabled = false;
            }
        }
    }
}
        
    
