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

    [Header("Attendance Viewer Settings")]
    public Transform attendanceContainer;
    public BuildingName Building = BuildingName.None;
    public FloorLevel Floor = FloorLevel.None;
    public RoomNumber Room = RoomNumber.None;

    string query;
    string connectionString = @"Data Source=DESKTOP-SSEOURC\SQLEXPRESS,1433;Initial Catalog = CROWD_MONITORING_SYSTEM; User ID = sa; Password=adminaie";
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

            query = "SELECT * FROM INFORMATION";
            cmd = new SqlCommand(query, con);
            rd = cmd.ExecuteReader();

            float templateView = 20f;
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

            query = "SELECT * FROM INFORMATION "+((Building!=BuildingName.None)?"WHERE "+((Building==BuildingName.None)? "" : "ID=15151515"):"");
            Debug.Log(query);
            cmd = new SqlCommand(query, con);
            rd = cmd.ExecuteReader();

            float templateView = 20f;
            while (rd.Read())
            {
                GameObject obj = Instantiate(dataEntry, attendanceContainer);
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
    public void SetBuilding(TMP_Dropdown building)
    { Building = EnumHelper.GetEnum<BuildingName>(building.value); }
    public void SetFloor(TMP_Dropdown floor)
    { Floor = EnumHelper.GetEnum<FloorLevel>(floor.value); }
    public void SetRoom(TMP_Dropdown room)
    { Room = EnumHelper.GetEnum<RoomNumber>(room.value); }
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
}
