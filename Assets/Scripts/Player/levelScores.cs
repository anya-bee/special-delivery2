using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class levelScores : MonoBehaviour
{
    public static int levelOneScore;
    public static int levelTwoScore;
    public static int levelThreeScore;
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
    public TextMeshProUGUI lvl3Score;
    public TextMeshProUGUI totalCoinsDisplay;
    public Button_UI storeButton;
    

    private void Start()
    {
        storeImage.gameObject.SetActive(false);
        display = false;
        

    }


    private void Update()
    {
        lvl1Score.text =  levelOneScore.ToString();
        lvl2Score.text = levelTwoScore.ToString();
        lvl3Score.text = levelThreeScore.ToString();



        totalCoinsDisplay.text = ("Coins : " + totalCoins.ToString());

        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if ( display == false)
            {
                storeImage.gameObject.SetActive(true);
                Script_AudioManager.instance.PlayPlayerSFX("woodStore");
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
        if (totalCoins > money)
        {
            Script_AudioManager.instance.PlaySFX("clientExit");
            totalCoins = totalCoins - money;
            storeManagement.currentBusMaterial = 1;
        }
        
    }

    public void buyOrangeColor(int money)
    {
        if (totalCoins > money)
        {
            Script_AudioManager.instance.PlaySFX("clientExit");
            totalCoins = totalCoins - money;
            storeManagement.currentBusMaterial = 2;
        }
    }

    public void buyPurple(int money)
    {
        if (totalCoins > money)
        {
            Script_AudioManager.instance.PlaySFX("clientExit");
            totalCoins = totalCoins - money;
            storeManagement.currentBusMaterial = 3;
        }
    }

    public void buyLife(int money)
    {
        if (totalCoins > money)
        {
            Script_AudioManager.instance.PlaySFX("clientExit");
            totalCoins = totalCoins - money;
            almaLife = 25;
        }
    }


    public void buyClientsTime(int money)
    {
        if (totalCoins > money)
        {
            Script_AudioManager.instance.PlaySFX("clientExit");
            totalCoins = totalCoins - money;
            clientsNewTimer = 55;
        }
    }


    public void blenderGolden(int money)
    {
        if (totalCoins > money)
        {
            Script_AudioManager.instance.PlaySFX("clientExit");
            totalCoins = totalCoins - money;
            blenderIsGolden = true;
        }
    }
}
