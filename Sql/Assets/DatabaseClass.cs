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
    public TMP_InputField serverName;
    public TMP_InputField portNo;
    public TMP_InputField userId;
    public TMP_InputField password;

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
    public void GenerateQr() {
        if (!(id.text == "" || course.text == "" || lastname.text == "" || firstname.text == "" || middlename.text == ""))
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData qRCodeData = qr.CreateQrCode(("[" + id.text + "]"), QRCodeGenerator.ECCLevel.H);
            UnityQRCode code = new UnityQRCode(qRCodeData);
            text = code.GetGraphic(4);
            Sprite convert = Sprite.Create(text, new Rect(0, 0, text.width, text.height), Vector2.one * .5f);
            qrimg.sprite = convert;
        }
    }

    public void InsertMethod()
    {
        if (!(id.text == "" || course.text == "" || lastname.text == "" || firstname.text == "" || middlename.text == ""))
        {
            byte[] arr = text.ImgToBytes();

            if (!(serverName.text.Equals("") || portNo.text.Equals("") || userId.text.Equals("") || password.text.Equals("")))
                con = new SqlConnection(@"Data Source=" + serverName.text.Trim() + "," + portNo.text.Trim() + ";Initial Catalog = CROWD_MONITORING_SYSTEM; MultipleActiveResultSets=true; User ID = " + userId.text.Trim() + "; Password=" + password.text.Trim());
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
    }
   
    public void ResetData()
    {
        id.text = null;
        course.text = null;
        lastname.text = null;
        firstname.text = null;
        middlename.text = null;
    }
}
