using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;
using System.Data;
using System;
using TMPro;

public class DensityPercentage : MonoBehaviour
{
    public PieGraph densityPercent;
    
    public TMP_Text density;

    //string filter;
    //SqlConnection con;
    //bool c;
    //SqlCommand cmd, cmd1, cmd2, cmd3, cmd4, cmdf, cmdID;
    //SqlDataReader rd, rd1, rd2, rdf, rdID;
    //string query, query1, query2, query3, query4, queryf, queryID;
    //string connectionString = @"Data Source=DESKTOP-SSEOURC\SQLEXPRESS,1433;Initial Catalog = CROWD_MONITORING_SYSTEM; MultipleActiveResultSets=true; User ID = sa; Password=adminaie";
    //string building, floor, room, id, cap, bldg;
    //int count, capa, bldgcap, white, green, yellow, orange, red, capacityOfEachRoom, capacityOfEachBldg, countsOfStudents, temp;
    //float fifty = .5f, seventyfour = .74f;



    void Start()
    {
        //rm = GetComponent<Rooms>();
      
        
    }
    public void OnMouseDown()
    {
        //build.gameObject.SetActive(true);
        //eachbldg.gameObject.SetActive(true);
        //bldg = eachbldg.ToString();
        //counts = new ArrayList();
        //buildings = new ArrayList();
        //capacity = new ArrayList();
        //green = 0; yellow = 0; orange = 0; red = 0; white = 0;

        //if (graph.transform.childCount > 0)
        //{
        //    Transform[] con = new Transform[graph.transform.childCount];
        //    for (int i = 0; i < con.Length; i++)
        //    {
        //        con[i] = graph.transform.GetChild(i);
        //    }

        //    for (int i = 0; i < con.Length; i++)
        //    {
        //        Debug.Log(con[i].name);
        //        Destroy(con[i].gameObject);

        //    }
        //}
        //for (int i = 0; i < graph.values.Length; i++)
        //{
        //    graph.values[i] = 0;

        //}


    }
    public void Graphs()
    {
        for (int i = 0; i < densityPercent.counts.Count; i++)
        {
            densityPercent.bldgs[i].color = densityPercent.wedgeColors[4];
        }
        //Debug.Log(densityPercent.counts[0]);
        //Debug.Log(densityPercent.counts[1]);
        //Debug.Log(densityPercent.counts.Count);


        //Debug.Log("TAMA KA");
        //con = new SqlConnection(connectionString);
        //con.Open();
        //if (con.State == ConnectionState.Open)
        //{

        //    building = eachbldg.name;

        //    query3 = "SELECT FLOOR_NO FROM FLOOR_INFO WHERE BUILDING_NAME = '" + building + "'";
        //    cmd3 = new SqlCommand(query3, con);
        //    rd2 = cmd3.ExecuteReader();

        //    while (rd2.Read())
        //    {

        //        floor = rd2["FLOOR_NO"].ToString();
        //        queryf = "SELECT ROOM_NO FROM ROOM_INFO WHERE BUILDING_NAME = '" + building + "'";
        //        cmdf = new SqlCommand(queryf, con);
        //        rdf = cmdf.ExecuteReader();


        //        while (rdf.Read())
        //        {

        //            room = rdf["ROOM_NO"].ToString();

        //            queryID = "SELECT ID FROM INFORMATION";
        //            cmdID = new SqlCommand(queryID, con);
        //            rdID = cmdID.ExecuteReader();

        //            while (rdID.Read())
        //            {
        //                id = rdID["ID"].ToString();
        //                query4 = "SELECT COUNT(*) FROM ATTENDANCE WHERE BUILDING_NAME = '" + building + "' AND FLOOR_NO = '" + floor + "' AND REMARKS = 'IN' AND ROOM_NO = '" + room + "' AND ID = '" + id + "'";
        //                cmd3 = new SqlCommand(query4, con);
        //                count += (Int32)cmd3.ExecuteScalar();

        //            }
        //            if (count > 0)
        //            {
        //                rms.Add(room);
        //                counts.Add(count);
        //                count = 0;
        //            }
        //        }

        //        buildings.Add(building);
        //    }

        //    //}
        //    for (int i = 0; i < counts.Count; i++)
        //    {
        //        temp += (int)counts[i];
        //    }
        //    //Capacity of each Building
        //    query1 = "SELECT CAPACITY FROM ROOM_INFO WHERE BUILDING_NAME = '" + building + "'";
        //    cmd1 = new SqlCommand(query1, con);
        //    rd1 = cmd1.ExecuteReader();


        //    while (rd1.Read())
        //    {
        //        cap = rd1["CAPACITY"].ToString();
        //        capa = Convert.ToInt32(cap);
        //        capacity.Add(capa);
        //    }

        //GRAPH
        if (density.text.Equals("All"))
        {
            for (int i = 0; i < densityPercent.counts.Count; i++)
            {
                densityPercent.capacityOfEachBldg = (Int32)densityPercent.capacity[i];
                densityPercent.countsOfStudents = (Int32)densityPercent.counts[i];
                if (densityPercent.countsOfStudents <= (densityPercent.capacityOfEachBldg * densityPercent.fifty) && densityPercent.countsOfStudents > 0)
                {
                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[0];
                    
                }
                else if (densityPercent.countsOfStudents > (densityPercent.capacityOfEachBldg * densityPercent.fifty) && densityPercent.countsOfStudents <= (densityPercent.seventyfour * densityPercent.capacityOfEachBldg))
                {

                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[1];
                }
                else if (densityPercent.countsOfStudents > (densityPercent.seventyfour * densityPercent.capacityOfEachBldg) && densityPercent.countsOfStudents <= densityPercent.capacityOfEachBldg)
                {

                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[2];
                }
                else if (densityPercent.countsOfStudents > densityPercent.capacityOfEachBldg)
                {

                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[3];
                }
                else
                {
                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[4];
                }
            }
        }

        else if (density.text.Equals("50% and Below"))
        {
            for (int i = 0; i < densityPercent.counts.Count; i++)
            {
                densityPercent.capacityOfEachBldg = (Int32)densityPercent.capacity[i];
                densityPercent.countsOfStudents = (int)densityPercent.counts[i];
                if (densityPercent.countsOfStudents <= (densityPercent.capacityOfEachBldg * densityPercent.fifty) && densityPercent.countsOfStudents > 0)
                {
                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[0];
                }
            }
            Debug.Log("Green");
        }
        else if (density.text.Equals("50% and above"))
        {
            for (int i = 0; i < densityPercent.counts.Count; i++)
            {
                densityPercent.capacityOfEachBldg = (Int32)densityPercent.capacity[i];
                densityPercent.countsOfStudents = (int)densityPercent.counts[i];
                if (densityPercent.countsOfStudents > (densityPercent.capacityOfEachBldg * densityPercent.fifty) && densityPercent.countsOfStudents <= (densityPercent.seventyfour * densityPercent.capacityOfEachBldg))
                {
                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[1];
                }
            }
            Debug.Log("Yellow");
        }

        else if (density.text.Equals("75% and above"))
        {
            for (int i = 0; i < densityPercent.counts.Count; i++)
            {
                densityPercent.capacityOfEachBldg = (Int32)densityPercent.capacity[i];
                densityPercent.countsOfStudents = (int)densityPercent.counts[i];
                if (densityPercent.countsOfStudents > (densityPercent.seventyfour * densityPercent.capacityOfEachBldg) && densityPercent.countsOfStudents <= densityPercent.capacityOfEachBldg)
                {
                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[2];
                }
            }
            Debug.Log("Orange");
        }
        else
        {
            for (int i = 0; i < densityPercent.counts.Count; i++)
            {
                densityPercent.capacityOfEachBldg = (Int32)densityPercent.capacity[i];
                densityPercent.countsOfStudents = (int)densityPercent.counts[i];
                if (densityPercent.countsOfStudents > densityPercent.capacityOfEachBldg)
                {
                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[3];
                }
            }
            Debug.Log("Orange");
        }


        //int total = 0;
        //query2 = "SELECT COUNT (*) FROM  ROOM_INFO WHERE BUILDING_NAME = '" + building + "'";
        //cmd2 = new SqlCommand(query2, con);
        //bldgcap = (Int32)cmd2.ExecuteScalar();

        //for (int i = 0; i < bldgcap; i++)
        //{
        //    total += (int)capacity[i];
        //}


        //float zRotation = 0f;
        //for (int i = 0; i < graph.values.Length; i++)
        //{
        //    Image newWedge = Instantiate(graph.wedgePrefab) as Image;
        //    newWedge.transform.SetParent(graph.transform, false);
        //    newWedge.color = graph.wedgeColors[i];
        //    newWedge.fillAmount = graph.values[i] / total;
        //    newWedge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));
        //    zRotation -= newWedge.fillAmount * 360f;
        //}


        //for (int i = 0; i < counts.Count; i++)
        //{
        //    for (int y = 0; y < rm.MyImage.Length; y++)
        //    {
        //        if (rm.MyImage[y].name.Equals(rms[i].ToString()))
        //        {
        //            if (countsOfStudents <= (capacityOfEachRoom * fifty) && countsOfStudents > 0)
        //            {
        //                rm.MyImage[y].color = densityPercent.wedgeColors[0];
        //            }
        //            else if (countsOfStudents > (capacityOfEachRoom * fifty) && countsOfStudents <= (seventyfour * capacityOfEachRoom))
        //            {
        //                rm.MyImage[y].color = densityPercent.wedgeColors[1];
        //            }
        //            else if (countsOfStudents > (seventyfour * capacityOfEachRoom) && countsOfStudents <= capacityOfEachRoom)
        //            {
        //                rm.MyImage[y].color = densityPercent.wedgeColors[2];
        //            }
        //            else if (countsOfStudents > capacityOfEachRoom)
        //            {
        //                rm.MyImage[y].color = densityPercent.wedgeColors[3];
        //            }
        //            else
        //            {
        //                rm.MyImage[y].color = densityPercent.wedgeColors[4];

        //            }
        //        }
        //    }
        //}

        //if (r.MyImage[0].name.Equals(rms[0].ToString()))
        //    Debug.Log("THIS IS ROOM 1");
        //else
        //    Debug.Log("LEFT");



      

    }



}





