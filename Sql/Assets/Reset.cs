using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text label;
    public void resetFilter() {

        label.text = "All";

    }
}
