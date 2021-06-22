using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewInformation : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;
    public TMP_Text id;
    public TMP_Text courseAndYr;
    public TMP_Text lastName;
    public TMP_Text fistName;
    public TMP_Text middleName;
    public void ViewTableData()
    {
        
        entryTemplate.gameObject.SetActive(false);

        float templateView = 20f;
        for (int i = 0; i < 20; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateView * i);
            entryTransform.gameObject.SetActive(true);
        }


    }
}
