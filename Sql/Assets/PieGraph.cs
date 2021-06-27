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
    SqlCommand cmd,cmd1,cmd2;
    SqlDataReader rd,rd1,rd2;
    string query,query1,query2;
    string connectionString = @"Data Source=DESKTOP-SSEOURC\SQLEXPRESS,1433;Initial Catalog = CROWD_MONITORING_SYSTEM; MultipleActiveResultSets=true; User ID = sa; Password=adminaie";
    string building, id,cap;
    int count, capa,bldgcap;
    float fifty = .5f, seventyfour = .74f;
    ArrayList counts = new ArrayList();
    ArrayList capacity = new ArrayList();
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

            while (rd.Read()) 
            {

                building = rd["BUILDING_NAME"].ToString();

                query = "SELECT ID FROM INFORMATION";
                cmd = new SqlCommand(query, con);
                rd = cmd.ExecuteReader();


                while (rd.Read()) 
                {

                    id = rd["ID"].ToString();

                    query = "SELECT COUNT(*) FROM ATTENDANCE WHERE BUILDING_NAME = '" + building + "' AND ID = '" + id + "' AND REMARKS = 'IN'";
                    
                    cmd = new SqlCommand(query, con);
                    count += (Int32)cmd.ExecuteScalar();

                }
                counts.Add(count);
              
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
               

            }
            //Total Capacity of all buildings
            int total = 0;
            float zRotation = 0f;

            query2 = "SELECT COUNT (*) FROM BUILDING_INFO";
            cmd2 = new SqlCommand(query2, con);
            bldgcap = (Int32)cmd2.ExecuteScalar();

            for (int i = 0; i < bldgcap; i++)
            {
                total += (int)capacity[i];
            }


            float[] values = new float[5];
            Image newWedge = Instantiate(wedgePrefab) as Image;
            newWedge.transform.SetParent(transform, false);

            for (int i = 0; i < counts.Count; i++)
            {
               int capacityOfEachBldg = (Int32)capacity[i];
               int countsOfStudents = (Int32)counts[i];
                if (countsOfStudents <= capacityOfEachBldg * fifty)
                {
                    values[i] = countsOfStudents;
                    newWedge.color = wedgeColors[2];
                    newWedge.fillAmount = values[i] / total;
                    newWedge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));
                    zRotation -= newWedge.fillAmount * 360f;
                }
            }

        }



      
        //for (int i = 0; i < values.Length; i++) {
        //    values[i] = i;
        //    total += i;
        //}

        //for (int i = 0; i < values.Length; i++)
        //{
         
        //    newWedge.color = wedgeColors[i];
        //    newWedge.fillAmount = values[i] / total;
        //    newWedge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));
        //    zRotation -= newWedge.fillAmount * 360f;

        //}



    }
}