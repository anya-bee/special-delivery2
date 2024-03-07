using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class levelScores : MonoBehaviour
{
    public static int levelOneScore;
    public static int levelTwoScore;
    public static int totalPoints;

    public TextMeshProUGUI lvl1Score;
    public TextMeshProUGUI lvl2Score;
    public TextMeshProUGUI totalScoreDisplay;


    private void Update()
    {
        lvl1Score.text =  levelOneScore.ToString();
        lvl2Score.text = levelTwoScore.ToString();

        totalPoints = levelOneScore + levelTwoScore;

        totalScoreDisplay.text = ("Coins : " + totalPoints.ToString());
    }


    public void buySomething(float money)
    {
        totalPoints -= 20;
        Debug.Log("Bought something by " +  money.ToString()  + " coins");
    }


}
