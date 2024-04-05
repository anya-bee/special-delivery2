using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barColorCode : MonoBehaviour
{
    public Image thisBar;
    public float barFillAmount;
    public float yellowBar, redBar;
    public Color32 targetYellowColor;
    public Color32 targetRedColor;
    public Color32 targetGreenColor;

    void Start()
    {
        thisBar.color = targetGreenColor;
    }

    // Update is called once per frame
    void Update()
    {
        
        barFillAmount = GetComponent<Image>().fillAmount;

        if (barFillAmount < 0.6f)
        {
            yellowBar += (Time.deltaTime * 0.6f) ;
            thisBar.color = Color.Lerp(targetGreenColor, targetYellowColor, yellowBar);
        }

        if (barFillAmount < 0.35f)
        {
            redBar += (Time.deltaTime * 0.6f);
            thisBar.color = Color.Lerp(targetYellowColor, targetRedColor, redBar);
        }
    }



    public void resetColors()
    {
        yellowBar = 0;
        redBar = 0;
    }

}

