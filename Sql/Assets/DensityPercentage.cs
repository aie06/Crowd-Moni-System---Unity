using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;
using System.Data;
using System;
using TMPro;

public class DensityPercentage : MonoBehaviour
{
    public PieGraph densityPercent;

    public TMP_Text density;
    int whitelbl, greenlbl, yellowlbl, orangelbl, redlbl = 0;
    void Start()
    {
       


    }
    public void OnMouseDown()
    {
     

    }
    public void Graphs()
    {
        densityPercent.greenCount.text = "0"; densityPercent.yellowCount.text = "0"; densityPercent.orangeCount.text = "0"; densityPercent.redCount.text = "0"; densityPercent.whiteCount.text = "0";
        whitelbl = 0; greenlbl = 0; yellowlbl = 0; orangelbl = 0; redlbl = 0;
        for (int i = 0; i < densityPercent.counts.Count; i++)
        {
            densityPercent.bldgs[i].color = densityPercent.wedgeColors[4];
        }
     

        //GRAPH
        if (density.text.Equals("All"))
        {
            for (int i = 0; i < densityPercent.counts.Count; i++)
            {
                densityPercent.capacityOfEachBldg = (Int32)densityPercent.capacity[i];
                densityPercent.countsOfStudents = (Int32)densityPercent.counts[i];
                if (densityPercent.countsOfStudents <= (densityPercent.capacityOfEachBldg * densityPercent.fifty) && densityPercent.countsOfStudents > 0)
                {
                    greenlbl++;
                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[0];
                    densityPercent.greenCount.text = greenlbl.ToString();
                }
                else if (densityPercent.countsOfStudents > (densityPercent.capacityOfEachBldg * densityPercent.fifty) && densityPercent.countsOfStudents <= (densityPercent.seventyfour * densityPercent.capacityOfEachBldg))
                {
                    yellowlbl++;
                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[1];
                    densityPercent.yellowCount.text = yellowlbl.ToString();
                }
                else if (densityPercent.countsOfStudents > (densityPercent.seventyfour * densityPercent.capacityOfEachBldg) && densityPercent.countsOfStudents <= densityPercent.capacityOfEachBldg)
                {
                    orangelbl++;
                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[2];
                    densityPercent.orangeCount.text = orangelbl.ToString();
                }
                else if (densityPercent.countsOfStudents > densityPercent.capacityOfEachBldg)
                {
                    redlbl++;
                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[3];
                    densityPercent.redCount.text = redlbl.ToString();
                }
                else
                {
                    whitelbl++;
                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[4];
                    densityPercent.whiteCount.text = whitelbl.ToString();
                }
            }
        }

        else if (density.text.Equals("50% and Below"))
        {
            for (int i = 0; i < densityPercent.counts.Count; i++)
            {
                densityPercent.capacityOfEachBldg = (Int32)densityPercent.capacity[i];
                densityPercent.countsOfStudents = (int)densityPercent.counts[i];
                if (densityPercent.countsOfStudents <= (densityPercent.capacityOfEachBldg * densityPercent.fifty) && densityPercent.countsOfStudents > 0)
                {
                    greenlbl++;
                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[0];
                    densityPercent.greenCount.text = greenlbl.ToString();
                }
            }          
        }
        else if (density.text.Equals("50% and above"))
        {
            for (int i = 0; i < densityPercent.counts.Count; i++)
            {
                densityPercent.capacityOfEachBldg = (Int32)densityPercent.capacity[i];
                densityPercent.countsOfStudents = (int)densityPercent.counts[i];
                if (densityPercent.countsOfStudents > (densityPercent.capacityOfEachBldg * densityPercent.fifty) && densityPercent.countsOfStudents <= (densityPercent.seventyfour * densityPercent.capacityOfEachBldg))
                {
                    yellowlbl++;
                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[1];
                    densityPercent.yellowCount.text = yellowlbl.ToString();
                }
            }
        }

        else if (density.text.Equals("75% and above"))
        {
            for (int i = 0; i < densityPercent.counts.Count; i++)
            {
                densityPercent.capacityOfEachBldg = (Int32)densityPercent.capacity[i];
                densityPercent.countsOfStudents = (int)densityPercent.counts[i];
                if (densityPercent.countsOfStudents > (densityPercent.seventyfour * densityPercent.capacityOfEachBldg) && densityPercent.countsOfStudents <= densityPercent.capacityOfEachBldg)
                {
                    orangelbl++;
                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[2];
                    densityPercent.orangeCount.text = orangelbl.ToString();
                }
            }
        }
        else
        {
            for (int i = 0; i < densityPercent.counts.Count; i++)
            {
                densityPercent.capacityOfEachBldg = (Int32)densityPercent.capacity[i];
                densityPercent.countsOfStudents = (int)densityPercent.counts[i];
                if (densityPercent.countsOfStudents > densityPercent.capacityOfEachBldg)
                {
                    redlbl++;
                    densityPercent.bldgs[i].color = densityPercent.wedgeColors[3];
                    densityPercent.redCount.text = redlbl.ToString();
                }
            }
        }
    }
}





