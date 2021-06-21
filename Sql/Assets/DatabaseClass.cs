using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System.Data.SqlClient;
using TMPro;
using QRCoder;
using QRCoder.Unity;

public class DatabaseClass : MonoBehaviour
{
    public TMP_InputField id;
    public TMP_InputField course;
    public TMP_InputField lastname;
    public TMP_InputField firstname;
    public TMP_InputField middlename;
    public Image qrimg;



    static string query;
    static SqlCommand cmd;
    string temp;
    SqlConnection con;
    string connectionString = @"Data Source=DESKTOP-SSEOURC\SQLEXPRESS,1433;Initial Catalog = CROWD_MONITORING_SYSTEM; User ID = sa; Password=adminaie";

    void Start()
    {
       
    }

    //public void saveData()
    //{
    //    con = new SqlConnection(connectionString);
    //    try
    //    {
    //        con.Open();
    //        if (con.State == ConnectionState.Open)
    //        {
    //            query = ("INSERT INFO (LNAME, FNAME) VALUES ('"+lname.text+"','" + fname.text + "')");
    //            cmd = new SqlCommand(query, con);

    //            cmd.ExecuteNonQuery();
    //            con.Close();
    //            Debug.Log("Connection Open");
    //        }
    //    }
        //catch (System.Exception ex)
        //{
        //    Debug.Log(ex);
        //}
      
        //yield return null;
    //}
    public void InsertMethod()
    {
        QRCodeGenerator qr = new QRCodeGenerator();
        QRCodeData qRCodeData = qr.CreateQrCode(("["+id.text+"]"), QRCodeGenerator.ECCLevel.H);
        UnityQRCode code = new UnityQRCode(qRCodeData);
        Texture2D text = code.GetGraphic(4);
        byte[] arr = text.ImgToBytes();
        Texture2D result = arr.BytesToImg();
        Sprite convert = Sprite.Create(text, new Rect(0, 0, text.width, text.height), Vector2.one * .5f);
        qrimg.sprite = convert;
        con = new SqlConnection(connectionString);
        try
        {

            con.Open();
            if (con.State == ConnectionState.Open)
            {
                query = "INSERT INTO INFORMATION(ID,COURSE_AND_YEAR,LAST_NAME,FIRST_NAME,MIDDLE_NAME, QRCODE)VALUES('" + id.text + "','" + course.text + "','" + lastname.text + "','" + firstname.text + "','" + middlename.text + "' , '" + arr + "')";
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
      
    }



    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
