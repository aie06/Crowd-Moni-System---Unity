using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System.Data.SqlClient;
using TMPro;

public class DatabaseClass : MonoBehaviour
{
    public TMP_InputField fname;
    public TMP_InputField lname;
  
    static string query;
    static SqlCommand cmd;
    string temp;
    SqlConnection con;
    string connectionString = @"Data Source=DESKTOP-SSEOURC\SQLEXPRESS,1433;Initial Catalog = sample; User ID = sa; Password=adminaie";

    void Start()
    {
       
    }

    public void saveData()
    {
        con = new SqlConnection(connectionString);
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                query = ("INSERT INFO (LNAME, FNAME) VALUES ('"+lname.text+"','" + fname.text + "')");
                cmd = new SqlCommand(query, con);


                cmd.ExecuteNonQuery();
                con.Close();
                Debug.Log("Connection Open");
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex);
        }
        //yield return null;
    }




    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        
    }
}
