using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;
using System.Data;
using System;
using TMPro;


public class SearchBldg : MonoBehaviour
{
    public TMP_InputField search;
    public SpriteRenderer ICT;
    public SpriteRenderer Lib;
    public SpriteRenderer AgriBusiness;
    public SpriteRenderer map;
    private Color color;
   

   
    public void Search() {

        if (search.text.ToUpper().Equals("ICT")) {
            color = map.color;
            color.a = .25f;
            map.color = color;

            color = Lib.color;
            color.a = .5f;
            Lib.color= color;

            color = AgriBusiness.color;
            color.a = .5f;
            AgriBusiness.color = color;
            
        }
        else if (search.text.ToUpper().Equals("LIBRARY")) {
            color = map.color;
            color.a = .25f;
            map.color = color;

            color = AgriBusiness.color;
            color.a = .5f;
            AgriBusiness.color = color;

            color = ICT.color;
            color.a = .5f;
            ICT.color = color;

        }
        else if (search.text.ToUpper().Equals("AGRICULTURAL BUSINESS") || search.text.ToUpper().Equals("AGRICULTURE"))
        {
            color = map.color;
            color.a = .25f;
            map.color = color;

            color = ICT.color;
            color.a = .5f;
            ICT.color = color;

            color = Lib.color;
            color.a = .5f;
            Lib.color = color;

        }
        

    }
    public void resetvalues() {
        search.text = "";
        color = map.color;
        color.a = 1;
        map.color = color;

        color = ICT.color;
        color.a = 1;
        ICT.color = color;

        color = Lib.color;
        color.a = 1;
        Lib.color = color;

        color = AgriBusiness.color;
        color.a = 1;
        AgriBusiness.color = color;

    }




}
