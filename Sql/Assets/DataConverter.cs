using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
[System.Serializable]
public static class DataConverter
{
    static byte[] bytes;
    static Texture2D texture = null;

    public static string ImgToBase64(this Texture2D tex)
    {
        bytes = tex.EncodeToPNG();
        return Convert.ToBase64String(bytes);
    }
    public static Texture2D Base64ToImg(this string str)
    {
        bytes = Convert.FromBase64String(str);
        texture = new Texture2D(1,1);
        texture.LoadImage(bytes);
        texture.Apply();
        return texture;
    }
    public static byte[] ImgToBytes(this Texture2D tex)
    {
        bytes = tex.EncodeToPNG();
       
        return bytes;
    }
    public static Texture2D BytesToImg(this byte[] bits)
    {
        //string[] res = str.Split('-');
        //byte[] arr = new byte[res.Length];

        //for (int i = 0; i<=arr.Length; i++) {
        //    arr[i] = Convert.ToByte(res[i]);
        //}

        texture = new Texture2D(1,1);

        texture.LoadImage(bits);
        texture.Apply();
        return texture;    }


}
