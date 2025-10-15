using System;
using System.Windows.Forms;

namespace WindowsFormApp1
{
    public partial class ServiceStatusForm : Form
    {
        public ServiceStatusForm()
        {
            InitializeComponent();
        }

        private void ServiceStatusForm_Load(object sender, EventArgs e)
        {
            this.Text = "Service Request Status";
        }

        private void btnCheckStatus_Click(object sender, EventArgs e)
        {
            // Dummy example
            MessageBox.Show("Request #123 is currently: In Progress");
        }
    }
}
