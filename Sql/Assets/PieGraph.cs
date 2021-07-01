using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;
using System.Data;
using System;


public class PieGraph : MonoBehaviour
{
    public float[] values;
    public Color[] wedgeColors;
    public Image wedgePrefab;
    SqlConnection con;
    SqlCommand cmd, cmd1, cmd2, cmd3;
    SqlDataReader rd, rd1, rd2;
    string query, query1, query2, query3, query4;
    string connectionString = @"Data Source=DESKTOP-SSEOURC\SQLEXPRESS,1433;Initial Catalog = CROWD_MONITORING_SYSTEM; MultipleActiveResultSets=true; User ID = sa; Password=adminaie";
    string building, id, cap;
    int count, capa, bldgcap, white, green, yellow, orange, red;
    float fifty = .5f, seventyfour = .74f;
    ArrayList colors = new ArrayList();
    ArrayList counts = new ArrayList();
    ArrayList capacity = new ArrayList();
    ArrayList buildings = new ArrayList();


    public SpriteRenderer[] bldgs;

    // Start is called before the first frame update
    void Start()
    {
        MakeGraph();
    }

    public void MakeGraph()
    {


        //for (int i = 0; i < values.Length; i++)
        //{
        //    total += values[i];
        //}

        con = new SqlConnection(connectionString);
        //entryTemplate.gameObject.SetActive(false);

        con.Open();
        if (con.State == ConnectionState.Open)
        {

            // Number of People on a building
            query = "SELECT BUILDING_NAME FROM BUILDING_INFO";

            cmd = new SqlCommand(query, con);
            rd = cmd.ExecuteReader();
            int temp = 0;
            while (rd.Read())
            {

                building = rd["BUILDING_NAME"].ToString();

                query3 = "SELECT ID FROM INFORMATION";
                cmd3 = new SqlCommand(query3, con);
                rd2 = cmd3.ExecuteReader();

                while (rd2.Read())
                {

                    id = rd2["ID"].ToString();

                    query4 = "SELECT COUNT(*) FROM ATTENDANCE WHERE BUILDING_NAME = '" + building + "' AND ID = '" + id + "' AND REMARKS = 'IN'";

                    cmd3 = new SqlCommand(query4, con);
                    count += (Int32)cmd3.ExecuteScalar();


                }

                counts.Add(count);
                buildings.Add(building);
                count = 0;

            }
            // Capacity of each Building
            query1 = "SELECT CAPACITY FROM BUILDING_INFO";

            cmd1 = new SqlCommand(query1, con);
            rd1 = cmd1.ExecuteReader();

            while (rd1.Read())
            {
                cap = rd1["CAPACITY"].ToString();

                capa = Convert.ToInt32(cap);
                capacity.Add(capa);
            }
            //TODO: EDIT (SABE NI CHA)
            for (int i = 0; i < counts.Count; i++)
            {
                int capacityOfEachBldg = (Int32)capacity[i];
                int countsOfStudents = (Int32)counts[i];
                if (countsOfStudents <= capacityOfEachBldg * fifty)
                {
                    green += (int)counts[i];
                    //bldgs[i].color = wedgeColors[0];
                }
                else if (countsOfStudents > capacityOfEachBldg * fifty && countsOfStudents <= seventyfour * capacityOfEachBldg)
                {
                    yellow += (int)counts[i];
                    //bldgs[i].color = wedgeColors[1];
                }
                else if (countsOfStudents > seventyfour * capacityOfEachBldg && countsOfStudents <= capacityOfEachBldg)
                {
                    orange += (int)counts[i];
                    //bldgs[i].color = wedgeColors[2];
                }
                else
                {
                    red += (int)counts[i];
                    //bldgs[i].color = wedgeColors[3];
                }

            }
            colors.Add(green);
            colors.Add(yellow);
            colors.Add(orange);
            colors.Add(red);
            //Total Capacity of all buildings

            int total = 0;
            query2 = "SELECT COUNT (*) FROM BUILDING_INFO";
            cmd2 = new SqlCommand(query2, con);
            bldgcap = (Int32)cmd2.ExecuteScalar();

            for (int i = 0; i < bldgcap; i++)
            {
                total += (int)capacity[i];

            }

            float zRotation = 0f;
            values = new float[5];

            for (int i = 0; i < 4; i++)
            {
                values[i] = (int)colors[i];
            }

            for (int i = 0; i < 4; i++)
            {

                Image newWedge = Instantiate(wedgePrefab) as Image;
                newWedge.transform.SetParent(transform, false);
                newWedge.color = wedgeColors[i];
                newWedge.fillAmount = values[i] / total;
                newWedge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));
                zRotation -= newWedge.fillAmount * 360f;
            }



            Debug.Log(green);
            Debug.Log(orange);
            Debug.Log(red);
            Debug.Log(total);


            //colors.Add(green);
            //colors.Add(yellow);
            //colors.Add(orange);
            //colors.Add(red);
            //int capacityOfEachBldg = (Int32)capacity[i];
            //int countsOfStudents = (Int32)counts[i];
            //if (countsOfStudents <= capacityOfEachBldg * fifty)
        }
    }
}
