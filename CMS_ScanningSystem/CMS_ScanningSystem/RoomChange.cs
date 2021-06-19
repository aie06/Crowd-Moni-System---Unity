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
    public partial class RoomChange : Form
    {
        static string query, rowName;
        public RoomChange()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(cbBuilding.Text == "- Select Building -" || cbFloor.Text == "- Select Floor -" || cbRoom.Text == "- Select Room -"))
            {
                DatabaseClass.ChangeRoom();
                DatabaseClass.roomName = cbRoom.Text;
                DatabaseClass.InsertRoomDetails(cbBuilding.Text, cbFloor.Text, cbRoom.Text);
                this.Hide();
                new ScanningSystem().ShowDialog();
            }
            else
            {
                MessageBox.Show("Select Room Details");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var condition = MessageBox.Show("Are you sure you want to cancel this process?", "Message", MessageBoxButtons.YesNo);
            if (condition == DialogResult.Yes)
            {
                this.Hide();
                new ScanningSystem().ShowDialog();
            }
        }

        private void cbBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "SELECT FLOOR_NO FROM FLOOR_INFO WHERE BUILDING_NAME ='" + cbBuilding.Text + "'";
            rowName = "FLOOR_NO";
            DatabaseClass.BuildingList(cbFloor, query, rowName);
        }

        private void RoomChange_Load(object sender, EventArgs e)
        {
            query = "SELECT BUILDING_NAME FROM BUILDING_INFO";
            rowName = "BUILDING_NAME";
            DatabaseClass.BuildingList(cbBuilding, query, rowName);
        }



        private void cbFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "SELECT ROOM_NO FROM ROOM_INFO WHERE BUILDING_NAME ='" + cbBuilding.Text + "' AND FLOOR_NO ='" + cbFloor.Text + "'";
            rowName = "ROOM_NO";
            DatabaseClass.BuildingList(cbRoom, query, rowName);
        }
    }
}
