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
    public partial class FormWorker : Form
    {
        public FormWorker()
        {
            InitializeComponent();
            ShowWorker();
        }

        private void FormWorker_Load(object sender, EventArgs e)
        {

        }
        void ShowWorker()
        {
            listViewWorker.Items.Clear();
            foreach (WorkersSet worksersSet in Program.BSTDB.WorkersSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    worksersSet.Id.ToString(), worksersSet.FirstName, worksersSet.MiddleName, worksersSet.LastName, worksersSet.Phone, worksersSet.Email
                });
                item.Tag = worksersSet;
                listViewWorker.Items.Add(item);
            }
            listViewWorker.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            WorkersSet workerSet = new WorkersSet();
            workerSet.FirstName = textBoxFirstName.Text;
            workerSet.MiddleName = textBoxMiddleName.Text;
            workerSet.LastName = textBoxLastName.Text;
            workerSet.Phone = textBoxPhone.Text;
            workerSet.Email = textBoxEmail.Text;
            Program.BSTDB.WorkersSet.Add(workerSet);
            Program.BSTDB.SaveChanges();
            ShowWorker();
        }

        private void listViewWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewWorker.SelectedItems.Count == 1)
            {
                WorkersSet workerSet = listViewWorker.SelectedItems[0].Tag as WorkersSet;
                textBoxFirstName.Text = workerSet.FirstName;
                textBoxMiddleName.Text = workerSet.MiddleName;
                textBoxLastName.Text = workerSet.LastName;
                textBoxPhone.Text = workerSet.Phone;
                textBoxEmail.Text = workerSet.Email;
            }
            else
            {
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxPhone.Text = "";
                textBoxEmail.Text = "";
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewWorker.SelectedItems.Count == 1)
            {
                WorkersSet workerSet = listViewWorker.SelectedItems[0].Tag as WorkersSet;
                workerSet.FirstName = textBoxFirstName.Text;
                workerSet.MiddleName = textBoxMiddleName.Text;
                workerSet.LastName = textBoxLastName.Text;
                workerSet.Phone = textBoxPhone.Text;
                workerSet.Email = textBoxEmail.Text;
                Program.BSTDB.SaveChanges();
                ShowWorker();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewWorker.SelectedItems.Count == 1)
                {
                    WorkersSet workerSet = listViewWorker.SelectedItems[0].Tag as WorkersSet;
                    Program.BSTDB.WorkersSet.Remove(workerSet);
                    Program.BSTDB.SaveChanges();
                    ShowWorker();
                }
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxPhone.Text = "";
                textBoxEmail.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
