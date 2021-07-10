using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;
using System.Data;
using System;
using TMPro;

public class DatabaseSetupAndLogIn : MonoBehaviour
{
    public TMP_InputField serverName;
    public TMP_InputField portNo;
    public TMP_InputField userId;
    public TMP_InputField password;
    public TMP_Text message;
    public GameObject BgMessage;
    public GameObject BgDatabase;
    public GameObject Form;
    public GameObject Map;
    SqlConnection con;
    SqlCommand cmd;

    public string DatabaseSetup()
    {
        return @"Data Source="+serverName.text.Trim()+","+portNo.text.Trim()+";Initial Catalog = CROWD_MONITORING_SYSTEM; MultipleActiveResultSets=true; User ID = "+userId.text.Trim()+"; Password="+password.text.Trim();
    }
    public void InvalidInputNull()
    {
        con = new SqlConnection(DatabaseSetup());

        if (serverName.text.Equals("") || portNo.text.Equals("") || userId.text.Equals("") || password.text.Equals(""))
        {
            message.text = "Please fill up all inputfields!";
            message.color = Color.red;
            BgMessage.gameObject.SetActive(true);

        }
        else
        {
            try
            {              
                cmd = new SqlCommand("SELECT COUNT(*) FROM BUILDING_INFO", con);
                con.Open();
                int count = (Int32)cmd.ExecuteScalar();
                con.Close();
                if (count > 0)
                {
                    BgDatabase.gameObject.SetActive(false);
                    Form.gameObject.SetActive(true);
                    Map.gameObject.SetActive(true);
                }
                else
                {
                    message.text = "Invalid Connection, Please check your input data!";
                    message.color = Color.red;
                    BgMessage.gameObject.SetActive(true);
                }
            }
            catch (Exception)
            {
                message.text = "Invalid Connection, Please check your input data!";
                message.color = Color.red;
                BgMessage.gameObject.SetActive(true);
            }

        }
    }
}
