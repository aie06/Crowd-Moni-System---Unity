using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;
using System.Data;


public class PieGraph : MonoBehaviour
{
    public float[] values;
    public Color[] wedgeColors;
    public Image wedgePrefab;
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rd;
    string query;
    string connectionString = @"Data Source=DESKTOP-SSEOURC\SQLEXPRESS,1433;Initial Catalog = CROWD_MONITORING_SYSTEM; User ID = sa; Password=adminaie";

    // Start is called before the first frame update
    void Start()
    {
        MakeGraph();
    }
    public void MakeGraph()
    {
        float total = 1f;
        float zRotation = 0f;
        //for (int i = 0; i < values.Length; i++)
        //{
        //    total += values[i];
        //}
        con = new SqlConnection(connectionString);
        con.Open();
        if (con.State == ConnectionState.Open)
        {
          
            query = "SELECT * FROM INFORMATION";
            cmd = new SqlCommand(query, con);
            rd = cmd.ExecuteReader();
            rd.Read();
            Debug.Log(rd["ID"].ToString());

        }
        float []values= new float[5];
        for (int i = 0; i < values.Length; i++) {
            values[i] = i;
            total += i;
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