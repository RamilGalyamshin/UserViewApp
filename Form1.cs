using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarberShop
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void buttonOpenClients_Click(object sender, EventArgs e)
        {
            Form formClient = new FormClient();
            formClient.Show();
        }

        private void buttonOpenWorkers_Click(object sender, EventArgs e)
        {
            Form formWorker = new FormWorker();
            formWorker.Show();
        }

        private void buttonOpenService_Click(object sender, EventArgs e)
        {
            Form formService = new FormService();
            formService.Show();
        }

        private void buttonOpenRegistration_Click(object sender, EventArgs e)
        {
            Form formRegistration = new FormRegistration();
            formRegistration.Show();
        }
    }
}
