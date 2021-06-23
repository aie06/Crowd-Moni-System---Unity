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
    string connectionString = @"Data Source=CHA_ROLD,1433;Initial Catalog = CROWD_MONITORING_SYSTEM; User ID = sa; Password=cha08";
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rd;

    #region Data Viewer
    public void ViewTableData()
    {
        ResetViewData();
        con = new SqlConnection(connectionString);
        //entryTemplate.gameObject.SetActive(false);

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

                //entryTransform = Instantiate(entryTemplate, entryContainer);
                //RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
                //entryRectTransform.anchoredPosition = new Vector2(0, -templateView * update);
                //entryTransform.gameObject.SetActive(true);
                //update++;
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
        //entryTemplate.gameObject.SetActive(false);

        con.Open();
        if (con.State == ConnectionState.Open)
        {

            //query = "SELECT * FROM INFORMATION "+((Building!=BuildingName.None)?"WHERE "+((Building==BuildingName.None)? "" : "ID=15151515"):"");
            query = "SELECT NAME,COURSE_AND_YEAR,TIME,REMARKS FROM ATTENDANCE";
            //Debug.Log(query);
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
    //public void SetBuilding(TMP_Dropdown building)
    //{ Building = EnumHelper.GetEnum<BuildingName>(building.value); }
    //public void SetFloor(TMP_Dropdown floor)
    //{ Floor = EnumHelper.GetEnum<FloorLevel>(floor.value); }
    //public void SetRoom(TMP_Dropdown room)
    //{ Room = EnumHelper.GetEnum<RoomNumber>(room.value); }
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
        buildingEmpty.text = "None";
        con = new SqlConnection(connectionString);
        filterBuilding.options.Clear();
        con.Open();
        if (con.State == ConnectionState.Open)
        {
            query = "SELECT BUILDING_NAME FROM BUILDING_INFO";
            cmd = new SqlCommand(query, con);
            rd = cmd.ExecuteReader();
            filterBuilding.options.Add(new TMP_Dropdown.OptionData() { text = "None" });
            while (rd.Read())
            {
                filterBuilding.options.Add(new TMP_Dropdown.OptionData() { text = rd["BUILDING_NAME"].ToString() });
            }
        }
        //TMP_DropdownItemSelected(filterBuilding, buildingEmpty);
        //filterRoom.onValueChanged.AddListener(delegate { TMP_DropdownItemSelected(filterBuilding, buildingEmpty); });
    }
    public void FilteringFloor()
    {
        floorEmpty.text = filterFloor.options[filterFloor.value].text;
        con = new SqlConnection(connectionString);
        filterFloor.options.Clear();
        con.Open();
        if (con.State == ConnectionState.Open)
        {
            query = "SELECT FLOOR_NO FROM FLOOR_INFO WHERE BUILDING_NAME = '"+filterBuilding.options[filterBuilding.value].text+"'";
            cmd = new SqlCommand(query, con);
            rd = cmd.ExecuteReader();
            filterFloor.options.Add(new TMP_Dropdown.OptionData() { text = "None" });
            while (rd.Read())
            {
                filterFloor.options.Add(new TMP_Dropdown.OptionData() { text = rd["FLOOR_NO"].ToString() });
            }
        }
        
        //TMP_DropdownItemSelected(filterFloor, floorEmpty);
        //filterRoom.onValueChanged.AddListener(delegate { TMP_DropdownItemSelected(filterFloor, floorEmpty); });
    }
    public void FilteringRoom()
    {
        roomEmpty.text = filterRoom.options[filterRoom.value].text;
        con = new SqlConnection(connectionString);
        filterRoom.options.Clear();
        con.Open();
        if (con.State == ConnectionState.Open)
        {
            query = "SELECT ROOM_NO FROM ROOM_INFO WHERE BUILDING_NAME ='"+ filterBuilding.options[filterBuilding.value].text + "'AND FLOOR_NO = '"+ filterFloor.options[filterFloor.value].text + "'";
            cmd = new SqlCommand(query, con);
            rd = cmd.ExecuteReader();
            filterRoom.options.Add(new TMP_Dropdown.OptionData() { text = "None"});
            while (rd.Read())
            {
                filterRoom.options.Add(new TMP_Dropdown.OptionData() { text = rd["ROOM_NO"].ToString() });
            }
        }
        //TMP_DropdownItemSelected(filterRoom, roomEmpty);
        //filterRoom.onValueChanged.AddListener(delegate { TMP_DropdownItemSelected(filterRoom, roomEmpty); });
    }
    //public void TMP_DropdownItemSelected(TMP_Dropdown dropdown, TMP_Text name)
    //{
    //    if (name.text.Equals("None"))
    //    {
    //        int index = 0;
    //        name.text = dropdown.options[index].text;
    //    }           
            
        
    //}
}
