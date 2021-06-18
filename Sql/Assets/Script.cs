using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;
using QRCoder;
using QRCoder.Unity;
using System;



public class Script : MonoBehaviour
{
    public Image img;

    public void generateQR(string data)
    {
        QRCodeGenerator qr = new QRCodeGenerator();
        QRCodeData qRCodeData = qr.CreateQrCode(data, QRCodeGenerator.ECCLevel.H);
        UnityQRCode code = new UnityQRCode(qRCodeData);
        Texture2D text = code.GetGraphic(4);
       
        byte[] arr = text.ImgToBytes();
        Texture2D result = arr.BytesToImg();
        Sprite convert = Sprite.Create(text, new Rect(0,0,text.width,text.height), Vector2.one * .5f);
        img.sprite = convert;
        Debug.Log(BitConverter.ToString(arr));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
