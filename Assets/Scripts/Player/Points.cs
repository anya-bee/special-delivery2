using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// points for lvl 1

public class Points : MonoBehaviour
{
    [Header("Points")]
    public TextMeshProUGUI Text1;
    public TextMeshProUGUI gameBoardText;
    public int totalPoints = 0;
    public int scene;
    [Header("Trays")]
    public GameObject tray1;
    public int tray1points;



    private void Start()
    {
        
    }


    void Update()
    {
        tray1points = tray1.GetComponent<orderChecked>().points;
        
        Text1.text = "Points: " + totalPoints.ToString();
        gameBoardText.text = totalPoints.ToString();
        


        if (scene == 1)
        {
            
            if(totalPoints > levelScores.levelOneScore)
            {
                levelScores.levelOneScore = totalPoints;
            }
            
        }
        if (scene == 2)
        {
            
            if (totalPoints > levelScores.levelTwoScore)
            {
                levelScores.levelTwoScore = totalPoints;
            }
                
        }
    }

    public void pointsTracker(int number)
    {
        totalPoints += number;
    }


    public void add20Points()
    {

        totalPoints += 20;
        
    }

    public void addCoins()
    {
        levelScores.totalCoins += totalPoints;
    }

}
