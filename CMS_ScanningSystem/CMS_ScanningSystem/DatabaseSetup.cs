using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMS_ScanningSystem.Classes;

namespace CMS_ScanningSystem
{
    public partial class DatabaseSetup : Form
    {
        public DatabaseSetup()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(txtServerName.Text.Equals("") || txtPortNo.Text.Equals("") || txtUserId.Text.Equals("") || txtPassword.Text.Equals("")))
                {
                    DatabaseClass.DatabaseSetup(txtServerName, txtPortNo, txtUserId, txtPassword);
                    DatabaseClass.SetDatabaseConnection();
                    if (DatabaseClass.CheckDatabase_Setup() > 0)
                    {
                        this.Hide();
                        new RoomChange().ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Connection, Please check your database connection!");
                        DatabaseClass.ClearDatabaseSetup();
                    }
                }
                else
                    MessageBox.Show("Fill up all the fields!");
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Connection, Please check your database connection!");
                DatabaseClass.ClearDatabaseSetup();
            }

        }
    }
}
