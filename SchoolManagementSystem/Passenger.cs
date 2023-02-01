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
    public partial class Passenger : Form
    {
        private string queryString;
        public Passenger()
        {
            InitializeComponent();
        }

        private void Passenger_Load(object sender, EventArgs e)
        {
            panel1.Enabled = false; 
            panel2.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            panel2.Enabled = true;
            txtFirstName.Clear();
            txtLastName.Clear();
            txtFrom.Clear();
            txtTo.Clear();
            txtEmail.Clear();
            txtMobilePhone.Clear();
            txtHomePhone.Clear();
            txtBuisnessPhone.Clear();
            cmbGender.SelectedItem = null;
            cmbDocumentType.SelectedItem = null;
            txtDocumentNumber.Clear();
            txtExpirationDate.Clear();
            pictureBox1.Image = null;
            txtFirstName.Focus();
        }

        private void txtExpirationDate_Click(object sender, EventArgs e)
        {
            
        }

        private void txtExpirationDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            txtFirstName.Focus();

            //UPDATE Passenger 
            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\C# Projects\Airport Management Sysytem New Edition\SchoolManagementSystem\AMSnew.accdb");
                con.Open();
                OleDbCommand com = new OleDbCommand("UPDATE Passenger SET FirstName = '" + txtFirstName.Text + "', LastName = '" + txtLastName.Text + "', From = '" + txtFrom.Text + "', To = '" + txtTo.Text + "', Email = '" + txtEmail.Text + "', MobilePhone = '" + txtMobilePhone.Text + "', HomePhone = '" + txtHomePhone.Text + "', BuisnessPhone = '" + txtBuisnessPhone.Text + "', Gender = '" + cmbGender.SelectedItem + "', DocumentType = '" + cmbDocumentType.SelectedItem + "', DocumentNumber = '" + txtDocumentNumber.Text + "', ExpDate = '" + txtExpirationDate.Text + "',[Image] ='"+pictureBox1.ImageLocation+"' WHERE FirstName='" + txtFirstName.Text + "')", con);
                
                com.ExecuteNonQuery();
                MessageBox.Show("Successfuly updated");

                con.Close();

                txtFirstName.Clear();
                txtLastName.Clear();
                txtFrom.Clear();
                txtTo.Clear();
                txtEmail.Clear();
                txtMobilePhone.Clear();
                txtHomePhone.Clear();
                txtBuisnessPhone.Clear();
                cmbGender.SelectedItem = null;
                cmbDocumentType.SelectedItem = null;
                txtDocumentNumber.Clear();
                txtExpirationDate.Clear();
                pictureBox1.Image = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                panel1.Enabled = false;
            }

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Insert 'ID'", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtID.Focus();
            }

            else if (txtFirstName.Text == "")
            {
                MessageBox.Show("Insert 'First Name'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                txtFirstName.Focus();
            }
            else if (txtLastName.Text == "")
            {
                MessageBox.Show("Insert 'Last Name'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                txtLastName.Focus();
            }
            else if (txtFrom.Text == "")
            {
                MessageBox.Show("Insert 'From'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                txtFrom.Focus();
            }
            else if (txtTo.Text == "")
            {
                MessageBox.Show("Insert 'To'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                txtTo.Focus();
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
            else if (txtHomePhone.Text == "")
            {
                MessageBox.Show("Insert 'Home Phone'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                txtHomePhone.Focus();
            }
            else if (txtBuisnessPhone.Text == "")
            {
                MessageBox.Show("Insert 'Buisness Phone'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                txtBuisnessPhone.Focus();
            }
            else if (cmbGender.SelectedValue == "")
            {
                MessageBox.Show("Select 'Gender'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                cmbGender.Focus();
            }
            else if (cmbDocumentType.SelectedValue == "")
            {
                MessageBox.Show("Select 'Document Type'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                cmbDocumentType.Focus();
            }
                else if (txtDocumentNumber.Text == "")
            {
                MessageBox.Show("Insert 'Document Number'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                txtDocumentNumber.Focus();
            }
            else if (txtExpirationDate.Text == "")
            {
                MessageBox.Show("Insert 'Expiration Date'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                txtExpirationDate.Focus();

            }
            else if (pictureBox1.Image == null)
            {
                MessageBox.Show("Insert 'Image'..", "Insert...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel1.Enabled = true;
                pictureBox1.Focus();

            }
            else
            {
                try
                {
                    OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\C# Projects\Airport Management Sysytem New Edition\SchoolManagementSystem\AMSnew.accdb");
                    con.Open();

                    OleDbCommand com = new OleDbCommand("INSERT INTO Passenger (ID, FirstName, LastName, [From], [To], Email, MobilePhone, HomePhone, BuisnessPhone, Gender, DocumentType, DocumentNumber, ExpDate, [Image]) VALUES ('" + txtID.Text + "', '" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtFrom.Text + "','" + txtTo.Text + "','" + txtEmail.Text + "','" + txtMobilePhone.Text + "','" + txtHomePhone.Text + "','" + txtBuisnessPhone.Text + "','" + cmbGender.SelectedIndex + "','" + cmbDocumentType.SelectedIndex + "','" + txtDocumentNumber.Text + "','" + txtExpirationDate.Text + "','" + pictureBox1.Width + "')", con);

                    com.ExecuteNonQuery();
                    MessageBox.Show("Successfuly Booked!!", "Success...", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    txtFirstName.Clear();
                    txtLastName.Clear();
                    txtFrom.Clear();
                    txtTo.Clear();
                    txtEmail.Clear();
                    txtMobilePhone.Clear();
                    txtHomePhone.Clear();
                    txtBuisnessPhone.Clear();
                    cmbGender.SelectedItem = null;
                    cmbDocumentType.SelectedItem = null;
                    txtDocumentNumber.Clear();
                    txtExpirationDate.Clear();
                    pictureBox1.Image = null;
                    panel2.Enabled = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    panel1.Enabled = false;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainWindow MainWin = new MainWindow();
            MainWin.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            panel2.Enabled = true;
            OleDbDataReader dr;
            OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\C# Projects\Airport Management Sysytem New Edition\SchoolManagementSystem\AMSnew.accdb");
            try
            {
                OleDbCommand com = new OleDbCommand("SELECT * FROM Passenger WHERE ID='" + txtID.Text + "'", Con);
                Con.Open();
                dr = com.ExecuteReader();
                dr.Read();

                txtID.Text = dr[0].ToString();
                txtFirstName.Text = dr[1].ToString();
                txtLastName.Text = dr[2].ToString();
                txtFrom.Text = dr[3].ToString();
                txtTo.Text = dr[4].ToString();
                txtEmail.Text = dr[5].ToString();
                txtMobilePhone.Text = dr[6].ToString();
                txtHomePhone.Text = dr[7].ToString();
                txtBuisnessPhone.Text = dr[8].ToString();
                cmbGender.SelectedText = dr[10].ToString();
                cmbDocumentType.SelectedText = dr[11].ToString();
                txtDocumentNumber.Text = dr[12].ToString();
                txtExpirationDate.Text = dr[13].ToString();
                pictureBox1.Show();
                
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

      

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                        pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //DELETE FROM Passenger 
            if (MessageBox.Show("Are you Sure?", "Delete...", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\C# Projects\Airport Management Sysytem New Edition\SchoolManagementSystem\AMSnew.accdb");
                con.Open();
                OleDbCommand com = new OleDbCommand("DELETE FROM Passenger WHERE FirstName = '" + txtFirstName.Text + "'", con);
                com.ExecuteNonQuery();
                MessageBox.Show("Deleted record.", "Deleted...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                con.Close();

                txtFirstName.Clear();
                txtLastName.Clear();
                txtFrom.Clear();
                txtTo.Clear();
                txtEmail.Clear();
                txtMobilePhone.Clear();
                txtHomePhone.Clear();
                txtBuisnessPhone.Clear();
                cmbGender.SelectedItem = null;
                cmbDocumentType.SelectedItem = null;
                txtDocumentNumber.Clear();
                txtExpirationDate.Clear();
                pictureBox1.Image = null;
                panel1.Enabled = false;
                panel2.Enabled = false;
                
            }
        }

        
    }
}
