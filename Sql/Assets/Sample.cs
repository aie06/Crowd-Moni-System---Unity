using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;
using System.Data;
using System;


public class Sample : MonoBehaviour
{


    SqlConnection con;
    bool c;
    SqlCommand cmd, cmd1, cmd2, cmd3, cmd4, cmdf, cmdID,cmdR;
    SqlDataReader rd, rd1, rd2, rdf, rdID,rdR;
    string query, query1, query2, query3, query4, queryf, queryID,queryRoom;
    string connectionString = @"Data Source=DESKTOP-SSEOURC\SQLEXPRESS,1433;Initial Catalog = CROWD_MONITORING_SYSTEM; MultipleActiveResultSets=true; User ID = sa; Password=adminaie";
    string building, floor, room, id, cap;
    int count, roomcount, count2,capa, bldgcap, white, green, yellow, orange, red, capacityOfEachRoom, countsOfStudents,countsperRoom, temp,whitelbl, greenlbl, yellowlbl, orangelbl, redlbl;
    float fifty = .5f, seventyfour = .74f;
    ArrayList counting = new ArrayList();
    ArrayList counts = new ArrayList();
    ArrayList capacity = new ArrayList();
    ArrayList buildings = new ArrayList();
    ArrayList rms = new ArrayList();
    

    // Start is called before the first frame update

    public SpriteRenderer[] bldgs;

    public GameObject build;
    public GameObject eachbldg;
    public GameObject rooms;
    public PieGraph graph;
    string bldg;
    Rooms r;
     void Start()
    {
        r = GetComponent<Rooms>();
    }
    public void OnMouseDown()
    {
        graph.greenCount.text = "0"; graph.yellowCount.text = "0"; graph.orangeCount.text = "0"; graph.redCount.text = "0"; graph.whiteCount.text = "0";
        whitelbl = 0; greenlbl = 0; yellowlbl = 0; orangelbl = 0; redlbl = 0;
        build.gameObject.SetActive(true);
        eachbldg.gameObject.SetActive(true);
        bldg = eachbldg.ToString();
        counts = new ArrayList();
        counting = new ArrayList();
        buildings = new ArrayList();
        capacity = new ArrayList();
        green = 0; yellow = 0; orange = 0; red = 0; white = 0;

        if (graph.transform.childCount > 0)
        {
            Transform[] con = new Transform[graph.transform.childCount];
            for (int i = 0; i < con.Length; i++)
            {
                con[i] = graph.transform.GetChild(i);
            }

            for (int i = 0; i < con.Length; i++)
            {
             
                Destroy(con[i].gameObject);

            }
        }
        for (int i = 0; i < graph.values.Length; i++)
        {
            graph.values[i] = 0;

        }
    
        Graph(bldg);
    }
    public void Graph(string ICT) {

        con = new SqlConnection(connectionString);
        con.Open();
        if (con.State == ConnectionState.Open)
        {
            //Number of People on a building
            //query = "SELECT BUILDING_NAME FROM BUILDING_INFO";

            //cmd = new SqlCommand(query, con);
            //rd = cmd.ExecuteReader();
            //int temp = 0;
            //while (rd.Read())
            //{

            building = eachbldg.name;

            query3 = "SELECT FLOOR_NO FROM FLOOR_INFO WHERE BUILDING_NAME = '" + building + "'";
            cmd3 = new SqlCommand(query3, con);
            rd2 = cmd3.ExecuteReader();
            queryRoom = "SELECT COUNT(ROOM_NO) FROM ROOM_INFO WHERE BUILDING_NAME = '" + building + "'";
            cmdR = new SqlCommand(queryRoom, con);
            roomcount= (Int32)cmdR.ExecuteScalar();

            

           
            while (rd2.Read())
            {

                floor = rd2["FLOOR_NO"].ToString();
                queryf = "SELECT ROOM_NO FROM ROOM_INFO WHERE BUILDING_NAME = '" + building + "' AND FLOOR_NO = '"+floor+"'";
                cmdf = new SqlCommand(queryf, con);
                rdf = cmdf.ExecuteReader();


                while (rdf.Read())
                {

                    room = rdf["ROOM_NO"].ToString(); //ROOM1 //ROOM2 //ROOM3

                    queryID = "SELECT ID FROM INFORMATION";
                    cmdID = new SqlCommand(queryID, con);
                    rdID = cmdID.ExecuteReader();

                    while (rdID.Read())
                    {
                        id = rdID["ID"].ToString();
                        query4 = "SELECT COUNT(*) FROM ATTENDANCE WHERE BUILDING_NAME = '" + building + "' AND FLOOR_NO = '" + floor + "' AND REMARKS = 'IN' AND ROOM_NO = '" + room + "' AND ID = '" + id + "'";
                        cmd3 = new SqlCommand(query4, con);
                        count += (Int32)cmd3.ExecuteScalar();
                        count2 += (Int32)cmd3.ExecuteScalar();

                    }

                    if (count > 0)
                    {
                        counting.Add(count);
                      
                        count = 0;
                    }    
                    counts.Add(count2);
                    rms.Add(room);
                    count2 = 0;    
                }
                buildings.Add(building);      
            }


            //}
         

            for (int i = 0; i < counts.Count; i++)
            {
                temp += (int)counts[i];
            }
            //Capacity of each Building
            query1 = "SELECT CAPACITY FROM ROOM_INFO WHERE BUILDING_NAME = '" + building + "'";
            cmd1 = new SqlCommand(query1, con);
            rd1 = cmd1.ExecuteReader();


            while (rd1.Read())
            {
                cap = rd1["CAPACITY"].ToString();
                capa = Convert.ToInt32(cap);
                capacity.Add(capa);
            }
           


            //Debug.Log("Capacity " + capacity.Count);
            //Debug.Log("counting " + counting.Count);
            //GRAPH
            for (int i = 0; i < counting.Count; i++)
            {
                capacityOfEachRoom = (int)capacity[i];
                countsOfStudents = (int)counting[i];
                if (countsOfStudents <= (capacityOfEachRoom * fifty) && countsOfStudents > 0)
                {
                   
                    green = (int)counting[i];
                    graph.values[0] += green;
                 
                 
                }
                else if (countsOfStudents > (capacityOfEachRoom * fifty) && countsOfStudents <= (seventyfour * capacityOfEachRoom))
                {
                 
                    yellow = (int)counting[i];
                    graph.values[1] += yellow;
                   
                  
                }
                else if (countsOfStudents > (seventyfour * capacityOfEachRoom) && countsOfStudents <= capacityOfEachRoom)
                {
                    
                    orange = (int)counting[i];
                    graph.values[2] += orange;
                   
                }
                else if (countsOfStudents > capacityOfEachRoom)
                {
                    red = (int)counting[i];
                    graph.values[3] += red;
                   
                }
                else
                {
                    graph.values[4] = capacityOfEachRoom;
                }
            }

            int total = 0;
            query2 = "SELECT COUNT (*) FROM  ROOM_INFO WHERE BUILDING_NAME = '" + building + "'";
            cmd2 = new SqlCommand(query2, con);
            bldgcap = (Int32)cmd2.ExecuteScalar();

            for (int i = 0; i < bldgcap; i++)
            {
                total += (int)capacity[i];
            }


            float zRotation = 0f;
            for (int i = 0; i < graph.values.Length; i++)
            {
                Image newWedge = Instantiate(graph.wedgePrefab) as Image;
                newWedge.transform.SetParent(graph.transform, false);
                newWedge.color = graph.wedgeColors[i];
                newWedge.fillAmount = graph.values[i] / total;
                newWedge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));
                zRotation -= newWedge.fillAmount * 360f;
            }








            Debug.Log(counts.Count);
            Debug.Log(capacity.Count);
            Debug.Log(counts[0]);
            Debug.Log(counts[1]);




            for (int i = 0; i < roomcount; i++)
            {
                for (int y = 0; y < r.MyImage.Length; y++)
                {
                    countsOfStudents = (int)counts[i];
                    capacityOfEachRoom = (int)capacity[i];
                    if (r.MyImage[y].name.Equals(rms[i].ToString()))
                    {
                        if (countsOfStudents <= (capacityOfEachRoom * fifty) && countsOfStudents > 0)
                        {
                            greenlbl++;
                            r.MyImage[y].color = graph.wedgeColors[0];
                            graph.greenCount.text = greenlbl.ToString();
                            Debug.Log("GREEN " + graph.greenCount.text);
                        }
                        else if (countsOfStudents > (capacityOfEachRoom * fifty) && countsOfStudents <= (seventyfour * capacityOfEachRoom)) {
                            r.MyImage[y].color = graph.wedgeColors[1];
                        }
                        else if (countsOfStudents > (seventyfour * capacityOfEachRoom) && countsOfStudents <= capacityOfEachRoom)
                        {
                            r.MyImage[y].color = graph.wedgeColors[2];
                        }
                        else if (countsOfStudents > capacityOfEachRoom)
                        {
                            r.MyImage[y].color = graph.wedgeColors[3];
                        }
                        else
                        {
                            whitelbl++;
                            r.MyImage[y].color = graph.wedgeColors[4];
                            graph.whiteCount.text = whitelbl.ToString();
                            Debug.Log("WHITE " + graph.whiteCount.text);

                        }
                    }
                }
               
            }

            greenlbl = 0;
            //if (r.MyImage[0].name.Equals(rms[0].ToString()))
            //    Debug.Log("THIS IS ROOM 1");
            //else
            //    Debug.Log("LEFT");





        }



    }
}


