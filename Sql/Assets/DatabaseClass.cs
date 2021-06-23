using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System.Data.SqlClient;
using TMPro;
using QRCoder;
using QRCoder.Unity;
using System.IO;
using System;
public class DatabaseClass : MonoBehaviour
{
    public TMP_InputField id;
    public TMP_InputField course;
    public TMP_InputField lastname;
    public TMP_InputField firstname;
    public TMP_InputField middlename;
    public Image qrimg;


    static Texture2D text;
    static string query;
    static SqlCommand cmd;
    string temp;
    SqlConnection con;
    string connectionString = @"Data Source=CHA_ROLD,1433;Initial Catalog = CROWD_MONITORING_SYSTEM; User ID = sa; Password=cha08";

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
    public void GenerateQr() {
        QRCodeGenerator qr = new QRCodeGenerator();
        QRCodeData qRCodeData = qr.CreateQrCode(("[" + id.text + "]"), QRCodeGenerator.ECCLevel.H);
        UnityQRCode code = new UnityQRCode(qRCodeData);
        text = code.GetGraphic(4);
        Sprite convert = Sprite.Create(text, new Rect(0, 0, text.width, text.height), Vector2.one * .5f);
        qrimg.sprite = convert;
    }
    public void InsertMethod()
    {
        
        byte[] arr = text.ImgToBytes();      
      
        con = new SqlConnection(connectionString);
        try
        {

            con.Open();
            if (con.State == ConnectionState.Open)
            {
                query = "INSERT INTO INFORMATION(ID,COURSE_AND_YEAR,LAST_NAME,FIRST_NAME,MIDDLE_NAME, QRCODE)VALUES('" + id.text + "','" + course.text.ToUpper() + "','" + lastname.text.ToUpper() + "','" + firstname.text.ToUpper() + "','" + middlename.text.ToUpper() + "' , '" + arr + "')";
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
        con.Close();
        var bytes = text.ImgToBytes();
        var dirPath = Application.dataPath + "/../QRCode Files/";

        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        var fileNameQrCode = lastname.text + ", " + firstname.text + " - " + id.text;
        File.WriteAllBytes(dirPath + "QRCode - " + fileNameQrCode + ".png", bytes);
        ResetData();
    }
   
    public void ResetData()
    {
        id.text = null;
        course.text = null;
        lastname.text = null;
        firstname.text = null;
        middlename.text = null;
    }


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
