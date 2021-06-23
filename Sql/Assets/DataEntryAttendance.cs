using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataEntryAttendance : MonoBehaviour
{
    public TMP_Text fullname;
    public TMP_Text courseAndYr;
    public TMP_Text time;
    public TMP_Text remarks;

    public void Initialize(string fullname, string CnY, string time, string remarks)
    {
        this.fullname.text = fullname;
        this.courseAndYr.text = CnY;
        this.time.text = time;
        this.remarks.text = remarks;
        
        this.gameObject.SetActive(true);
    }
}
