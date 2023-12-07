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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        barFillAmount = GetComponent<Image>().fillAmount;

        if (barFillAmount < 0.6f)
        {
            yellowBar += (Time.deltaTime * 0.6f) ;
            thisBar.color = Color.Lerp(Color.green, targetYellowColor, yellowBar);
        }

        if (barFillAmount < 0.35f)
        {
            redBar += (Time.deltaTime * 0.6f);
            thisBar.color = Color.Lerp(targetYellowColor, targetRedColor, redBar);
        }
    }

}