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
    public partial class FormRegistration : Form
    {
        public FormRegistration()
        {
            InitializeComponent();
            ShowWorkers();
            ShowClients();
            ShowServices();
            ShowRegistration();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void FormRegistration_Load(object sender, EventArgs e)
        {

        }
        void ShowWorkers()
        {
            comboBoxWorker.Items.Clear();
            foreach (WorkersSet workerSet in Program.BSTDB.WorkersSet)
            {
                string[] item = { workerSet.Id.ToString() + ".", workerSet.FirstName, workerSet.MiddleName, workerSet.LastName };
                comboBoxWorker.Items.Add(string.Join(" ", item));
            }
        }
        void ShowClients()
        {
            comboBoxClient.Items.Clear();
            foreach (ClientsSet clientsSet in Program.BSTDB.ClientsSet)
            {
                string[] item = { clientsSet.Id.ToString() + ".", clientsSet.FirstName, clientsSet.MiddleName, clientsSet.LastName };
                comboBoxClient.Items.Add(string.Join(" ", item));
            }
        }
        void ShowServices()
        {
            comboBoxService.Items.Clear();
                foreach (ServicesSet serviceSet in Program.BSTDB.ServicesSet)
            {    
                string[] item = { serviceSet.Id.ToString() + ".", serviceSet.Name };
                comboBoxService.Items.Add(string.Join(" ", item));
            }    
        }
        void ShowRegistration()
        {
            listViewRegistration.Items.Clear();
            foreach (RegistrationsSet registrationSet in Program.BSTDB.RegistrationsSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    registrationSet.IdWorker.ToString(),
                    registrationSet.WorkersSet.LastName+" "+ registrationSet.WorkersSet.FirstName+" "+registrationSet.WorkersSet.MiddleName,
                    registrationSet.IdClent.ToString(),
                    registrationSet.ClientsSet.LastName+" "+registrationSet.ClientsSet.FirstName+" "+registrationSet.ClientsSet.MiddleName,
                    registrationSet.IdService.ToString(),
                    registrationSet.ServicesSet.Name,
                    registrationSet.Price.ToString()
                });
                item.Tag = registrationSet;
                listViewRegistration.Items.Add(item);
            }
        }

        private void listViewRegistration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRegistration.SelectedItems.Count == 1)
            {
                RegistrationsSet registrationSet = listViewRegistration.SelectedItems[0].Tag as RegistrationsSet;
                comboBoxWorker.SelectedIndex = comboBoxWorker.FindString(registrationSet.IdWorker.ToString());
                comboBoxClient.SelectedIndex = comboBoxClient.FindString(registrationSet.IdClent.ToString());
                comboBoxService.SelectedIndex = comboBoxService.FindString(registrationSet.IdService.ToString());
                textBoxPrice.Text = registrationSet.Price.ToString();
            }
            else
            {
                comboBoxWorker.SelectedItem = null;
                comboBoxClient.SelectedItem = null;
                comboBoxService.SelectedItem = null;
                textBoxPrice.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxWorker.SelectedItem != null && comboBoxClient.SelectedItem != null && comboBoxService.SelectedItem != null && textBoxPrice.Text != "")
            {
                RegistrationsSet registrationSet = new RegistrationsSet();
                registrationSet.IdWorker = Convert.ToInt32(comboBoxWorker.SelectedItem.ToString().Split('.')[0]);
                registrationSet.IdClent = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                registrationSet.IdService = Convert.ToInt32(comboBoxService.SelectedItem.ToString().Split('.')[0]);
                registrationSet.Price = Convert.ToInt64(textBoxPrice.Text);
                Program.BSTDB.RegistrationsSet.Add(registrationSet);
                Program.BSTDB.SaveChanges();
                ShowRegistration();
            }
            else MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewRegistration.SelectedItems.Count == 1)
            {
                RegistrationsSet registrationsSet = listViewRegistration.SelectedItems[0].Tag as RegistrationsSet;
                registrationsSet.IdWorker = Convert.ToInt32(comboBoxWorker.SelectedItem.ToString().Split('.')[0]);
                registrationsSet.IdClent = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                registrationsSet.IdService = Convert.ToInt32(comboBoxService.SelectedItem.ToString().Split('.')[0]);
                registrationsSet.Price = Convert.ToInt64(textBoxPrice.Text);
                Program.BSTDB.SaveChanges();
                ShowRegistration();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewRegistration.SelectedItems.Count == 1)
                {
                    RegistrationsSet registrationSet = listViewRegistration.SelectedItems[0].Tag as RegistrationsSet;
                    Program.BSTDB.RegistrationsSet.Remove(registrationSet);
                    Program.BSTDB.SaveChanges();
                    ShowRegistration();
                }
                comboBoxWorker.SelectedItem = null;
                comboBoxClient.SelectedItem = null;
                comboBoxService.SelectedItem = null;
                textBoxPrice.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
