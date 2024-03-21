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
    public static int totalCoins;

    [Header("StoreImage")]
    public Image storeImage;
    public bool display;
    public static float almaLife;
    public static float clientsNewTimer;




    [Header("blenderGolden")]
    public static bool blenderIsGolden = false;


    [Header("levelScores")]
    public TextMeshProUGUI lvl1Score;
    public TextMeshProUGUI lvl2Score;
    public TextMeshProUGUI totalCoinsDisplay;

    private void Start()
    {
        storeImage.gameObject.SetActive(false);
        display = false;
        

    }

    private void Update()
    {
        lvl1Score.text =  levelOneScore.ToString();
        lvl2Score.text = levelTwoScore.ToString();
        
        

        totalCoinsDisplay.text = ("Coins : " + totalCoins.ToString());


        if (Input.GetKeyDown(KeyCode.F))
        {
            if ( display == false)
            {
                storeImage.gameObject.SetActive(true);

                display = true;
            }
            else if(display == true)
            {
                storeImage.gameObject.SetActive(false);
                display = false;
            }
        }
    }


    public void buyBlueColor(int money)
    {
        totalCoins = totalCoins - money;
        storeManagement.currentBusMaterial = 1;
    }

    public void buyOrangeColor(int money)
    {
        totalCoins = totalCoins - money;
        storeManagement.currentBusMaterial = 2;
    }

    public void buyPurple(int money)
    {
        totalCoins = totalCoins - money;
        storeManagement.currentBusMaterial = 3;
    }

    public void buyLife(int money)
    {
        totalCoins = totalCoins - money;
        almaLife = 25;
    }


    public void buyClientsTime(int money)
    {
        totalCoins = totalCoins - money;
        clientsNewTimer = 100;
    }


    public void blenderGolden(int money)
    {
        totalCoins = totalCoins - money;
        blenderIsGolden = true;
    }
}
