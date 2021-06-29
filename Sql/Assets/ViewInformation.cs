using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;
using System.Data;
using System;

using TMPro;

public class ViewInformation : MonoBehaviour
{
    public enum BuildingName {None,B1,B2,B3}
    public enum FloorLevel {None,Ground,Second,Third}
    public enum RoomNumber {None,Room1,Room2,Room3,Room4}

    [Header("Table Viewer Settings")]
    public Transform viewerContainer;
    public GameObject dataEntry;
    public TMP_Dropdown filteringInfo;

    [Header("Attendance Viewer Settings")]
    public Transform attendanceContainer;
    public GameObject dataEntryAttendance;
    public TMP_Dropdown filterBuilding;
    public TMP_Text buildingEmpty;
    public TMP_Dropdown filterFloor;
    public TMP_Text floorEmpty;
    public TMP_Dropdown filterRoom;
    public TMP_Text roomEmpty;
    public BuildingName Building = BuildingName.None;
    public FloorLevel Floor = FloorLevel.None;
    public RoomNumber Room = RoomNumber.None;

    string query;
    string connectionString = @"Data Source=CHA_ROLD,1433;Initial Catalog=CROWD_MONITORING_SYSTEM;User ID=sa;Password=cha08";
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rd;

    #region Data Viewer
    public void ViewTableData()
    {
        ResetViewData();
        con = new SqlConnection(connectionString);
       
        con.Open();
        if (con.State == ConnectionState.Open)
        {
            if(filteringInfo.options[filteringInfo.value].text.Equals("All"))
                query = "SELECT * FROM INFORMATION";
            else if(filteringInfo.options[filteringInfo.value].text.Equals("Faculty"))
                query = "SELECT * FROM INFORMATION WHERE COURSE_AND_YEAR = 'FACULTY'";
            else if(filteringInfo.options[filteringInfo.value].text.Equals("Staff"))
                query = "SELECT * FROM INFORMATION WHERE COURSE_AND_YEAR = 'STAFF'";
            else
                query = "SELECT * FROM INFORMATION WHERE COURSE_AND_YEAR != 'FACULTY' AND COURSE_AND_YEAR != 'STAFF'";

            cmd = new SqlCommand(query, con);
            rd = cmd.ExecuteReader();

            while (rd.Read()) {
                GameObject obj = Instantiate(dataEntry, viewerContainer);
                obj.GetComponent<DataEntry>().Initialize(
                    rd["ID"].ToString(),
                    rd["COURSE_AND_YEAR"].ToString(),
                    rd["LAST_NAME"].ToString(),
                    rd["FIRST_NAME"].ToString(),
                    rd["MIDDLE_NAME"].ToString());
                obj.transform.localScale = Vector3.one;
            }
        }
  
    }
    public void ResetViewData()
    {
        if(viewerContainer.childCount > 0)
        {
            GameObject[] entries = new GameObject[viewerContainer.childCount];
            for (int i = 0; i < entries.Length; i++)
                entries[i] = viewerContainer.GetChild(i).gameObject;
            
            for (int i = 0; i < entries.Length; i++)
            {
                Destroy(entries[i]);
            }
        }
    }
    #endregion

    #region Attendance Viewer
    public void ViewAttendance()
    {
        ResetAttendanceData();
        con = new SqlConnection(connectionString);
        con.Open();
        if (con.State == ConnectionState.Open)
        {
            if(buildingEmpty.text.Equals("All"))
            query = "SELECT * FROM ATTENDANCE";
            cmd = new SqlCommand(query, con);
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                GameObject obj = Instantiate(dataEntryAttendance, attendanceContainer);
                obj.GetComponent<DataEntryAttendance>().Initialize(
                    rd["NAME"].ToString(),
                    rd["COURSE_AND_YEAR"].ToString(),
                    rd["TIME"].ToString(),
                    rd["REMARKS"].ToString());
                obj.transform.localScale = Vector3.one;
            }
        }
    }

    public void ResetAttendanceData()
    {
        if (attendanceContainer.childCount > 0)
        {
            GameObject[] entries = new GameObject[attendanceContainer.childCount];
            for (int i = 0; i < entries.Length; i++)
                entries[i] = attendanceContainer.GetChild(i).gameObject;

            for (int i = 0; i < entries.Length; i++)
            {
                Destroy(entries[i]);
            }
        }
    }

    #endregion

    public void FilteringBuilding()
    {
        con = new SqlConnection(connectionString);
        filterBuilding.ClearOptions();
        con.Open();
        if (con.State == ConnectionState.Open)
        {
            query = "SELECT BUILDING_NAME FROM BUILDING_INFO";
            cmd = new SqlCommand(query, con);
            rd = cmd.ExecuteReader();
            filterBuilding.options.Add(new TMP_Dropdown.OptionData() { text = "All" });
            while (rd.Read())
            {
                filterBuilding.options.Add(new TMP_Dropdown.OptionData() { text = rd["BUILDING_NAME"].ToString() });
            }
        }
        buildingEmpty.text = filterBuilding.options[0].text;
       
    }

    public void FilteringFloor()
    {
        if (buildingEmpty.text.Equals("All"))
            filterFloor.gameObject.SetActive(false);
        con = new SqlConnection(connectionString);
        filterFloor.ClearOptions();
        con.Open();
        if (con.State == ConnectionState.Open)
        {
            query = "SELECT FLOOR_NO FROM FLOOR_INFO WHERE BUILDING_NAME = '"+buildingEmpty.text+"'";
            cmd = new SqlCommand(query, con);
            rd = cmd.ExecuteReader();
            filterFloor.options.Add(new TMP_Dropdown.OptionData() { text = "All" });
            while (rd.Read())
            {
                filterFloor.options.Add(new TMP_Dropdown.OptionData() { text = rd["FLOOR_NO"].ToString() });
            }
        }
        floorEmpty.text = filterFloor.options[0].text;
       
    }

    public void FilteringRoom()
    {
        con = new SqlConnection(connectionString);
        filterRoom.ClearOptions();
        con.Open();
        if (con.State == ConnectionState.Open)
        {
            query = "SELECT ROOM_NO FROM ROOM_INFO WHERE BUILDING_NAME ='"+ buildingEmpty.text + "'AND FLOOR_NO = '"+ floorEmpty.text + "'";
            cmd = new SqlCommand(query, con);
            rd = cmd.ExecuteReader();
            filterRoom.options.Add(new TMP_Dropdown.OptionData() { text = "All"});
            while (rd.Read())
            {
                filterRoom.options.Add(new TMP_Dropdown.OptionData() { text = rd["ROOM_NO"].ToString() });
            }
        }
        roomEmpty.text = filterRoom.options[0].text;
       
    }
    public void ViewAttendacePerBuilding()
    {
        con = new SqlConnection(connectionString);
        ResetAttendanceData();
        con.Open();
        if (con.State == ConnectionState.Open)
        {

            if (filterBuilding.options[filterBuilding.value].text.Equals("All"))
                query = "SELECT * FROM ATTENDANCE";
            else
                query = "SELECT * FROM ATTENDANCE WHERE BUILDING_NAME = '" + filterBuilding.options[filterBuilding.value].text + "'";

            cmd = new SqlCommand(query, con);
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                GameObject obj = Instantiate(dataEntryAttendance, attendanceContainer);
                obj.GetComponent<DataEntryAttendance>().Initialize(
                    rd["NAME"].ToString(),
                    rd["COURSE_AND_YEAR"].ToString(),
                    rd["TIME"].ToString(),
                    rd["REMARKS"].ToString());
                obj.transform.localScale = Vector3.one;
            }
        }
    }
    public void ViewAttendancePerFloor()
    {

        con = new SqlConnection(connectionString);
        ResetAttendanceData();
        con.Open();
        if (con.State == ConnectionState.Open)
        {
            if (filterFloor.options[filterFloor.value].text.Equals("All"))
            {
                query = "SELECT * FROM ATTENDANCE WHERE BUILDING_NAME = '" + buildingEmpty.text + "'";
                filterRoom.gameObject.SetActive(false);
            }
            else
                query = "SELECT * FROM ATTENDANCE WHERE BUILDING_NAME = '" + buildingEmpty.text + "' AND FLOOR_NO = '" + filterFloor.options[filterFloor.value].text + "'";
           
            cmd = new SqlCommand(query, con);
            rd = cmd.ExecuteReader();
           
            while (rd.Read())
            {
                
                GameObject obj = Instantiate(dataEntryAttendance, attendanceContainer);
                obj.GetComponent<DataEntryAttendance>().Initialize(
                    rd["NAME"].ToString(),
                    rd["COURSE_AND_YEAR"].ToString(),
                    rd["TIME"].ToString(),
                    rd["REMARKS"].ToString());
                obj.transform.localScale = Vector3.one;
            }
        }
    }
    public void ViewAttendancePerRoom()
    {
        con = new SqlConnection(connectionString);
        ResetAttendanceData();
        con.Open();
        if (con.State == ConnectionState.Open)
        {
            if (filterRoom.options[filterRoom.value].text.Equals("All"))
                query = "SELECT * FROM ATTENDANCE WHERE BUILDING_NAME = '" + buildingEmpty.text + "' AND FLOOR_NO = '" + floorEmpty.text + "'";
            else
                query = "SELECT * FROM ATTENDANCE WHERE BUILDING_NAME = '" + buildingEmpty.text + "' AND FLOOR_NO = '" + floorEmpty.text + "' AND ROOM_NO = '" + filterRoom.options[filterRoom.value].text + "'";

            cmd = new SqlCommand(query, con);
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                GameObject obj = Instantiate(dataEntryAttendance, attendanceContainer);
                obj.GetComponent<DataEntryAttendance>().Initialize(
                    rd["NAME"].ToString(),
                    rd["COURSE_AND_YEAR"].ToString(),
                    rd["TIME"].ToString(),
                    rd["REMARKS"].ToString());
                obj.transform.localScale = Vector3.one;
            }
        }
    }
  
}
