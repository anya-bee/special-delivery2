using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Points : MonoBehaviour
{
    [Header("Points")]
    public TextMeshProUGUI Text1;
    public int totalPoints = 0;
    [Header("Trays")]
    public GameObject tray1;
    public int tray1points;



    private void Start()
    {
        
    }


    void Update()
    {
        tray1points = tray1.GetComponent<orderChecked>().points;
        
        Text1.text = "Points : " + totalPoints.ToString();
    }

    public void pointsTracker(int number)
    {
        totalPoints += number;
    }


}
