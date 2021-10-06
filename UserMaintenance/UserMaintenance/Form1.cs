using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{

    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();
            lblLastName.Text = Resource.FullName;
            btnAdd.Text = Resource.Add;
            bttnsavefile.Text = Resource.Fájlba_írás;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";

            var u = new User()
            {
                FullName = txtLastName.Text,
            };
            users.Add(u);
        }

        private void bttnsavefile_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    myStream.Close();
                }
            }
        }
    }
}
