using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DataEntry : MonoBehaviour
{
    public TMP_Text id;
    public TMP_Text courseAndYr;
    public TMP_Text lastName;
    public TMP_Text firstName;
    public TMP_Text middleName;

    public void Initialize(string id, string CnY, string lName, string fName, string mName)
    {
        this.id.text = id;
        this.courseAndYr.text = CnY;
        this.lastName.text = lName;
        this.firstName.text = fName;
        this.middleName.text = mName;
        this.gameObject.SetActive(true);
    }
}
