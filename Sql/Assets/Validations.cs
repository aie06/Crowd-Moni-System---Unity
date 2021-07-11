using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Validations : MonoBehaviour
{
    public TMP_InputField id;
    public TMP_InputField courseAndDept;
    public TMP_InputField lastName;
    public TMP_InputField firstName;
    public TMP_InputField middleName;
    public Image imgQr;
    public Button btnSave;
    public TMP_Text message;
    public GameObject BgMessage;

    public void InvalidInputNull()
    {
        if(id.text.Equals("") || courseAndDept.text.Equals("") || lastName.text.Equals("") || firstName.text.Equals("") || middleName.text.Equals(""))
        {
            message.text = "Please fill up all input fields!";
            message.color = Color.red;
            BgMessage.gameObject.SetActive(true);
            imgQr.gameObject.SetActive(false);
            btnSave.gameObject.SetActive(false);
        }
    }

    public void SaveInfoWIthQrCode()
    {
        message.text = "Saved Successfully!";
        message.color = Color.green;
        BgMessage.gameObject.SetActive(true);
        imgQr.gameObject.SetActive(false);
        btnSave.gameObject.SetActive(false);
        id.text = "";
        courseAndDept.text = "";
        lastName.text = "";
        firstName.text = "";
        middleName.text = "";
    }

    public void ClearInfo()
    {
        if (id.text == "" || courseAndDept.text == "" || lastName.text == "" || firstName.text == "" || middleName.text == "")
        {
            message.text = "Input fields are already clear!";
            message.color = Color.red;
            BgMessage.gameObject.SetActive(true);
        }
        id.text = "";
        courseAndDept.text = "";
        lastName.text = "";
        firstName.text = "";
        middleName.text = "";
    }
    
}
