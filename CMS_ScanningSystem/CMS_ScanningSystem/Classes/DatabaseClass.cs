﻿using System;
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

        static SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Client-System\CMS_ScanningSystem\CMS_ScanningSystem\Room_Database.mdf;Integrated Security=True");
        static SqlConnection serverCon = new SqlConnection(@"Data Source=CHA_ROLD,1433;Initial Catalog=CROWD_MONITORING_SYSTEM;User ID=sa;Password=cha08");
        static SqlCommand cmd;
        static SqlDataAdapter sda, innersda;
        static DataTable dt,innerdt;
        static string query,remarks;
        static SqlDataReader reader;
        public static string roomName = "";
        static int id = 1;

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
                innersda = new SqlDataAdapter("SELECT ID FROM ATTENDANCE WHERE ID ='" + scan + "' AND BUILDING_NAME = '" + roomdetails[0].ToString() + "' AND FLOOR_NO = '" + roomdetails[1].ToString() + "' AND ROOM_NO = '" + roomdetails[2].ToString() + "'", serverCon);
                innerdt = new DataTable();
                innersda.Fill(innerdt);
                if (innerdt.Rows.Count > 0)
                {
                    if (innerdt.Rows.Count % 2 == 1)
                    {
                        remarks = "OUT";
                        lbTimeInOrOut.Text = "TIME OUT";
                        lbTimeInOrOut.ForeColor = Color.Red;
                    }
                    else
                    {
                        remarks = "IN";
                        lbTimeInOrOut.Text = "TIME IN";
                        lbTimeInOrOut.ForeColor = Color.Green;
                    }
                    query = "INSERT INTO ATTENDANCE(BUILDING_NAME,FLOOR_NO,ROOM_NO,ID,NAME,COURSE_AND_YEAR,TIME,REMARKS)" +
                     "VALUES('" + roomdetails[0].ToString().Trim() + "','" + roomdetails[1].ToString().Trim() + "','" + roomdetails[2].ToString().Trim() + "','" + scan + "','" + (dt.Rows[0][2].ToString() + ", " + dt.Rows[0][3].ToString() + " " + dt.Rows[0][4].ToString().Substring(0, 1) + ".") + "','" + dt.Rows[0][1].ToString() + "','" + lbtime.Text + "','" + remarks + "')";
                    lbname.Text = dt.Rows[0][2].ToString() + ", " + dt.Rows[0][3].ToString() + " " + dt.Rows[0][4].ToString().Substring(0, 1) + ".";
                    cmd = new SqlCommand(query, serverCon);
                    serverCon.Open();
                    cmd.ExecuteNonQuery();
                    serverCon.Close();
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

            }
            else
            {
                lbTimeInOrOut.Text = "The QR Code is not registered. Please proceed to the authorized person to registered it.";
                lbTimeInOrOut.ForeColor = Color.Red;
            }
        }
        // -------------------------------------------------------------------
    }
}
