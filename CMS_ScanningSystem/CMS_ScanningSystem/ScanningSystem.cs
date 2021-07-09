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
    public partial class ScanningSystem : Form
    {
        string id;
        Timer time,timerClear;
        int counter,counterClear;
        public ScanningSystem()
        {
            InitializeComponent();
            id = "";
            lbName.Text = "";
        }
        private void ScanningSystem_Load(object sender, EventArgs e)
        {
            lbTime.Visible = false;
            lbTimeInOrOut.Visible = false;
            txtScan.Select();
            lbRoomName.Text = DatabaseClass.AssignRoom(lbRoomName);
            if (lbRoomName.Text == "")
            {
                this.Hide();
                new RoomChange().ShowDialog();
            }
            if (DatabaseClass.DatabaseSetupCheck() == 0)
            {
                this.Hide();
                new DatabaseSetup().ShowDialog();
            }
            //else if (DatabaseClass.CheckDatabase_Setup() == 0)
            //{
            //    this.Hide();
            //    new DatabaseSetup().ShowDialog();
            //}
            else
            {
                try
                {
                    DatabaseClass.SetDatabaseConnection();
                }
                catch (Exception)
                {
                    this.Hide();
                    new DatabaseSetup().ShowDialog();
                }
            }
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            var condition = MessageBox.Show("Are you sure you want to change the Setup?", "Warning Message",MessageBoxButtons.YesNo);
            if (condition == DialogResult.Yes)
            {
                this.Hide();
                new Admin().ShowDialog();
            }
        }

        private void txtScan_TextChanged(object sender, EventArgs e)
        {
            id += txtScan.Text;
            txtScan.Text = "";
            if (id[id.Length - 1] == ']')
            {
                time = new Timer();
                counter = 4;
                time.Interval = 1000;
                time.Tick += new EventHandler(timer_Tick);
                time.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                counter--;
                if (counter == 0)
                {
                    timer.Stop();
                    DatabaseClass.ScanningMethod(id.Substring(1,id.Length-2), lbRoomName, lbName, lbTime, lbTimeInOrOut);
                   
                    timerClear = new Timer();
                    counterClear = 6;
                    timerClear.Interval = 1000;
                    timerClear.Tick += new EventHandler(timerSaveData_Tick);
                    timerClear.Start();
                    lbTimeInOrOut.Visible = true;
                    lbTime.Visible = true;
                }
            }
            catch (Exception) {  }
        }

        private void timerSaveData_Tick(object sender, EventArgs e)
        {
            try
            {
                counterClear--;
                if (counterClear == 0)
                {
                    timerClear.Stop();
                    lbTime.Visible = false;
                    lbTimeInOrOut.Visible = false;
                    lbName.Text = "";
                    lbTimeInOrOut.Text = "";
                    lbTime.Text = "";
                    id = "";
                }
            }
            catch (Exception) { }
        }
    }
}
