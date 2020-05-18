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
    public partial class FormService : Form
    {
        public FormService()
        {
            InitializeComponent();
            ShowService();
        }

        private void FormService_Load(object sender, EventArgs e)
        {

        }
        void ShowService()
        {
            listViewService.Items.Clear();
            foreach (ServicesSet servicesSet in Program.BSTDB.ServicesSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    servicesSet.Id.ToString(), servicesSet.Name, servicesSet.Price.ToString()
                });
                item.Tag = servicesSet;
                listViewService.Items.Add(item);
            }
            listViewService.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ServicesSet serviceSet = new ServicesSet();
            serviceSet.Name = textBoxName.Text;
            serviceSet.Price = Convert.ToInt64(textBoxPrice.Text);
            Program.BSTDB.ServicesSet.Add(serviceSet);
            Program.BSTDB.SaveChanges();
            ShowService();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewService.SelectedItems.Count == 1)
            {
                ServicesSet serviceSet = listViewService.SelectedItems[0].Tag as ServicesSet;
                serviceSet.Name = textBoxName.Text;
                serviceSet.Price= Convert.ToInt64(textBoxPrice.Text);
                Program.BSTDB.SaveChanges();
                ShowService();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewService.SelectedItems.Count == 1)
                {
                    ServicesSet serviceSet = listViewService.SelectedItems[0].Tag as ServicesSet;
                    Program.BSTDB.ServicesSet.Remove(serviceSet);
                    Program.BSTDB.SaveChanges();
                    ShowService();
                }
                textBoxName.Text = "";
                textBoxPrice.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}    
