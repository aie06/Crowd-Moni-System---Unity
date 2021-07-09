using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;
using System.Data;
using System;
using TMPro;


public class PieGraph : MonoBehaviour
{
    public float[] values;
    public Color[] wedgeColors;
    public Image wedgePrefab;
    public TMP_Text whiteCount;
    public TMP_Text greenCount;
    public TMP_Text yellowCount;
    public TMP_Text orangeCount;
    public TMP_Text redCount;


    SqlConnection con;
    SqlCommand cmd, cmd1, cmd2, cmd3,cmd4;
    SqlDataReader rd, rd1, rd2;
    string query, query1, query2, query3, query4;
    DateTime oDate;
    string connectionString = @"Data Source=DESKTOP-SSEOURC\SQLEXPRESS,1433;Initial Catalog = CROWD_MONITORING_SYSTEM; MultipleActiveResultSets=true; User ID = sa; Password=adminaie";
    string building, id, cap;
   public int count, capa, bldgcap, white, green, yellow, orange, red,whitelbl,greenlbl,yellowlbl,orangelbl,redlbl,capacityOfEachBldg,countsOfStudents;
   public float fifty = .5f, seventyfour = .74f;
    ArrayList colors = new ArrayList();
    public ArrayList counts = new ArrayList();
    public ArrayList capacity = new ArrayList();
    public ArrayList buildings = new ArrayList();


    public SpriteRenderer[] bldgs;

    // Start is called before the first frame update
    void Start()
    {
        Graphbldg();
     
    }

    public void Graphbldg()
    {
       
        
        counts = new ArrayList();
        buildings = new ArrayList();
        capacity = new ArrayList();
        green = 0; yellow = 0; orange = 0; red = 0;white = 0;
        whitelbl = 0; greenlbl = 0; yellowlbl = 0; orangelbl = 0; redlbl = 0;
        greenCount.text = "0"; yellowCount.text = "0"; orangeCount.text = "0"; redCount.text = "0"; whiteCount.text = "0";
        if (transform.childCount > 0)
        {
            Transform[] con = new Transform[transform.childCount];
            for (int i = 0; i < con.Length; i++)
            {
                con[i] = transform.GetChild(i);
            }
            for (int i = 0; i < con.Length; i++)
            {
                Destroy(con[i].gameObject);
            }
        }
        float zRotation = 0f;
        values = new float[5];


        for (int i = 0; i < values.Length; i++)
        {
            values[i]=0;
        }

        con = new SqlConnection(connectionString);
        //entryTemplate.gameObject.SetActive(false);

        con.Open();
        if (con.State == ConnectionState.Open)
        {
            // Number of People on a building
            query = "SELECT BUILDING_NAME FROM BUILDING_INFO";

            cmd = new SqlCommand(query, con);
            rd = cmd.ExecuteReader();
            int temp = 0,container=0;
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
            
            for (int i = 0; i < counts.Count; i++) 
            temp += (int)counts[i];
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
               capacityOfEachBldg = (Int32)capacity[i];
               countsOfStudents = (Int32)counts[i];
                if (countsOfStudents <= (capacityOfEachBldg * fifty) && countsOfStudents > 0)
                {
                    greenlbl++;
                    green = (int)counts[i];
                    values[0] += green;
                    bldgs[i].color = wedgeColors[0];
                    greenCount.text = greenlbl.ToString();

                   
                }
                else if (countsOfStudents > (capacityOfEachBldg * fifty) && countsOfStudents <= (seventyfour * capacityOfEachBldg))
                {
                    yellowlbl++; 
                    yellow = (int)counts[i];
                    values[1] += yellow;
                    bldgs[i].color = wedgeColors[1];
                    yellowCount.text = yellowlbl.ToString();
                }
                else if (countsOfStudents > (seventyfour * capacityOfEachBldg) && countsOfStudents <= capacityOfEachBldg)
                {
                    orangelbl++;
                    orange = (int)counts[i];
                    values[2] += orange;
                    bldgs[i].color = wedgeColors[2];
                    orangeCount.text = orangelbl.ToString();
                }
                else if (countsOfStudents > capacityOfEachBldg)
                {
                    redlbl++;
                    red = (int)counts[i];
                    values[3] += red;
                    bldgs[i].color = wedgeColors[3];
                    redCount.text = redlbl.ToString();
                }
                else {
                    whitelbl++;
                    values[4] = capacityOfEachBldg;
                    bldgs[i].color = wedgeColors[4];
                    whiteCount.text = whitelbl.ToString();
                }

            }
          

            int total = 0;
            query2 = "SELECT COUNT (*) FROM BUILDING_INFO";
            cmd2 = new SqlCommand(query2, con);
            bldgcap = (Int32)cmd2.ExecuteScalar();

            for (int i = 0; i < bldgcap; i++)
            {
                total += (int)capacity[i];

            }

            for (int i = 0; i < values.Length; i++)
            {
                Image newWedge = Instantiate(wedgePrefab) as Image;
                newWedge.transform.SetParent(transform, false);
                newWedge.color = wedgeColors[i];
                newWedge.fillAmount = values[i] / total;
                newWedge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));
                zRotation -= newWedge.fillAmount * 360f;
            }
         
        }

       
    }
}
