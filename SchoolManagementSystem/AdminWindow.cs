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
    public partial class AdminWindow : Form
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            Employee Employee = new Employee();
            Employee.Show();
            this.Hide();
        }

        private void btnFlight_Click(object sender, EventArgs e)
        {
            FlightDetails Flight = new FlightDetails();
            Flight.Show();
            this.Hide();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainWindow MainWin = new MainWindow();
            MainWin.Show();
            this.Close();
        }
    }
}
