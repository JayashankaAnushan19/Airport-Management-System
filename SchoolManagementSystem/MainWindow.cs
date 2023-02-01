using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPassenger_Click(object sender, EventArgs e)
        {
            Passenger Passenger = new Passenger();
            Passenger.Show();
            this.Hide();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminLog AdminLog = new AdminLog();
            AdminLog.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             AdminWindow m = new AdminWindow();
                    m.Show();
                    this.Hide();
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            FlightDetails f = new FlightDetails();
            f.Show();
            this.Close();
        }
    }
}
