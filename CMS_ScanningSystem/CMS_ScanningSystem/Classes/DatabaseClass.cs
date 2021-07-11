using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace CMS_ScanningSystem.Classes
{
    class DatabaseClass
    {

        static SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Crowd-Moni-System---Unity\CMS_ScanningSystem\CMS_ScanningSystem\Room_Database.mdf;Integrated Security=True");
        static SqlConnection serverCon;
        static SqlCommand cmd;
        static SqlDataAdapter sda, innersda,sdaTemp;
        static DataTable dt,innerdt,dtTemp;
        public static string query,remarks;
        static SqlDataReader reader;
        public static string roomName = "";
        static int id = 1;
        static bool check = true;
      

        // ROOM DETAILS---------------------------------------------
        public static void InsertRoomDetails(string buildingName, string floor, string room)
        {
    
            query = "INSERT INTO Room_Details(BuildingName,Floor,Room,Number)VALUES('" + buildingName + "','" + floor + "','" + room + "','"+id+"')";
            cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public static string AssignRoom(Label lbRoomname)
        {
            query = "SELECT BuildingName,Floor,Room FROM Room_Details WHERE Number = '" + id + "'";
            sda = new SqlDataAdapter(query, con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lbRoomname.Text = dt.Rows[0][0].ToString()+" - ";
                lbRoomname.Text += dt.Rows[0][1].ToString()+" - ";
                lbRoomname.Text += dt.Rows[0][2].ToString();
            }
            return lbRoomname.Text;
        }
        public static void ChangeRoom()
        {
            query = "DELETE FROM Room_Details";
            cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void BuildingList(ComboBox list,string query, string rowName)
        {
            try
            {
                list.Items.Clear();
                serverCon.Open();
                cmd = new SqlCommand(query, serverCon);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Items.Add(reader[rowName].ToString());
                }
                serverCon.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Connection!");
            }
      
           
        }
        //---------------------------------------------------------

        //SCANNING ATTENDANCE---------------------------------------
        public static void ScanningMethod(string scan, Label lbroomdetails, Label lbname, Label lbtime, Label lbTimeInOrOut)
        {
            sda = new SqlDataAdapter("SELECT * FROM INFORMATION WHERE ID ='"+ scan + "'", serverCon);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lbtime.Text = DateTime.Now.ToString("hh:mm tt");
                string[] roomdetails = lbroomdetails.Text.Split('-');
                innersda = new SqlDataAdapter("SELECT * FROM ATTENDANCE WHERE ID ='" + scan + "' AND BUILDING_NAME = '" + roomdetails[0].ToString().Trim() + "' AND FLOOR_NO = '" + roomdetails[1].ToString().Trim() + "' AND ROOM_NO = '" + roomdetails[2].ToString().Trim() + "'", serverCon);
                innerdt = new DataTable();
                innersda.Fill(innerdt);
                if (innerdt.Rows.Count > 0)
                {
                    check = false;
                    AttendaceAndHistoryAttendace(scan, roomdetails, lbname, lbtime, lbTimeInOrOut,dt);
                }
                else
                {
                    check = true;
                    AttendaceAndHistoryAttendace(scan, roomdetails, lbname, lbtime, lbTimeInOrOut,dt);
                }
            }
            else if(dt.Rows.Count == 0 && lbname.Text == "")
            {
                lbTimeInOrOut.Text = "The QR Code is not registered. Please proceed to the authorized person for registration.";
                lbTimeInOrOut.ForeColor = Color.Red;
            }
          
        }
        // -------------------------------------------------------------------

        public static void AttendaceAndHistoryAttendace(string scan, string [] roomdetails, Label lbname, Label lbtime, Label lbTimeInOrOut , DataTable dtMethod)
        {
            sdaTemp = new SqlDataAdapter("SELECT * FROM ATTENDANCE WHERE ID = '" + scan +"'",serverCon);
            dtTemp = new DataTable();
            sdaTemp.Fill(dtTemp);
            if(dtTemp.Rows.Count > 0 )
            {
                if (check)
                {
                    lbname.Text = dtMethod.Rows[0][2].ToString() + ", " + dtMethod.Rows[0][3].ToString() + " " + dtMethod.Rows[0][4].ToString().Substring(0, 1) + ".";
                    lbTimeInOrOut.Text = "Make sure you are out in\n" + dtTemp.Rows[0][1].ToString() + " - " + dtTemp.Rows[0][2].ToString() + " - " + dtTemp.Rows[0][3].ToString()+"\nto proceed in this room";
                    lbTimeInOrOut.ForeColor = Color.Red;
                }
                else
                {
                    remarks = "OUT";
                    lbTimeInOrOut.Text = "TIME OUT";
                    lbTimeInOrOut.ForeColor = Color.Red;
                   
                    query = "INSERT INTO ATTENDANCE(BUILDING_NAME,FLOOR_NO,ROOM_NO,ID,NAME,COURSE_AND_YEAR,TIME,REMARKS)" +
                    "VALUES('" + roomdetails[0].ToString().Trim() + "','" + roomdetails[1].ToString().Trim() + "','" + roomdetails[2].ToString().Trim() + "','" + scan + "','" + (dtMethod.Rows[0][2].ToString() + ", " + dtMethod.Rows[0][3].ToString() + " " + dtMethod.Rows[0][4].ToString().Substring(0, 1) + ".") + "','" + dtMethod.Rows[0][1].ToString() + "','" + lbtime.Text + "','" + remarks + "')";
                    lbname.Text = dtMethod.Rows[0][2].ToString() + ", " + dtMethod.Rows[0][3].ToString() + " " + dtMethod.Rows[0][4].ToString().Substring(0, 1) + ".";
                    cmd = new SqlCommand(query, serverCon);
                    serverCon.Open();
                    cmd.ExecuteNonQuery();
                    serverCon.Close();

                    query = "DELETE FROM ATTENDANCE WHERE BUILDING_NAME = '" + roomdetails[0].ToString().Trim() + "' AND FLOOR_NO = '" + roomdetails[1].ToString().Trim() + "' AND ROOM_NO = '" + roomdetails[2].ToString().Trim() + "' AND ID = '" + scan + "'";
                    cmd = new SqlCommand(query, serverCon);
                    serverCon.Open();
                    cmd.ExecuteNonQuery();
                    serverCon.Close();
                }

            }
            else
            {
                remarks = "IN";
                lbTimeInOrOut.Text = "TIME IN";
                lbTimeInOrOut.ForeColor = Color.Green;
                query = "INSERT INTO ATTENDANCE(BUILDING_NAME,FLOOR_NO,ROOM_NO,ID,NAME,COURSE_AND_YEAR,TIME,REMARKS)" +
                    "VALUES('" + roomdetails[0].ToString().Trim() + "','" + roomdetails[1].ToString().Trim() + "','" + roomdetails[2].ToString().Trim() + "','" + scan + "','" + (dt.Rows[0][2].ToString() + ", " + dt.Rows[0][3].ToString() + " " + dt.Rows[0][4].ToString().Substring(0, 1) + ".") + "','" + dt.Rows[0][1].ToString() + "','" + lbtime.Text + "','" + remarks + "')";
                lbname.Text = dt.Rows[0][2].ToString() + ", " + dt.Rows[0][3].ToString() + " " + dt.Rows[0][4].ToString().Substring(0, 1) + ".";
                cmd = new SqlCommand(query, serverCon);
                serverCon.Open();
                cmd.ExecuteNonQuery();
                serverCon.Close();  
            }
            query = "INSERT INTO ATTENDANCE_HISTORY(BUILDING_NAME,FLOOR_NO,ROOM_NO,ID,NAME,COURSE_AND_YEAR,TIME,REMARKS)" +
                     "VALUES('" + roomdetails[0].ToString().Trim() + "','" + roomdetails[1].ToString().Trim() + "','" + roomdetails[2].ToString().Trim() + "','" + scan + "','" + (dt.Rows[0][2].ToString() + ", " + dt.Rows[0][3].ToString() + " " + dt.Rows[0][4].ToString().Substring(0, 1) + ".") + "','" + dt.Rows[0][1].ToString() + "','" + lbtime.Text + "','" + remarks + "')";
            cmd = new SqlCommand(query, serverCon);
            serverCon.Open();
            cmd.ExecuteNonQuery();
            serverCon.Close(); 
        }
        public static void ClearDatabaseSetup()
        {
            cmd = new SqlCommand("DELETE FROM DATABASE_SETUP", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void DatabaseSetup(TextBox servername, TextBox portNo, TextBox userId,TextBox password)
        {
           
            ClearDatabaseSetup();
            query = "INSERT INTO DATABASE_SETUP(SERVERNAME,PORT_NO,USER_ID,PASSWORD)VALUES('" + servername.Text + "','" + portNo.Text + "','" + userId.Text + "','" + password.Text + "')";
            cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
           
        }
        public static int DatabaseSetupCheck()
        {
            cmd = new SqlCommand("SELECT COUNT(*) FROM DATABASE_SETUP", con);
            con.Open();
            int rowCount = (Int32)cmd.ExecuteScalar();
            con.Close();
            return rowCount;
        }
        public static void SetDatabaseConnection()
        {
            try
            {
                cmd = new SqlCommand("SELECT * FROM DATABASE_SETUP", con);
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string connection = @"Data Source=" + reader["SERVERNAME"].ToString() + "," + reader["PORT_NO"].ToString() + ";Initial Catalog=CROWD_MONITORING_SYSTEM;User ID=" + reader["USER_ID"].ToString() + ";Password=" + reader["PASSWORD"].ToString();
                    serverCon = new SqlConnection(connection);
                }
                con.Close();
              
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Connection!");
            }
        }
        public static int CheckDatabase_Setup()
        {
            try
            {
                cmd = new SqlCommand("SELECT COUNT(*) BUILDING_INFO", serverCon);
                serverCon.Open();
                int rowCount = (Int32)cmd.ExecuteScalar();
                serverCon.Close();
                return rowCount;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    } 
}
