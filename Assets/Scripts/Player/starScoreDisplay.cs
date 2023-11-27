using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class starScoreDisplay : MonoBehaviour
{
    public Image star1;
    public Image star2;
    public Image star3;
    public TextMeshProUGUI totalScoreText;
    public int numberTotalScore;

    [Header("Alma Sprites")]
    public Image almaImage;
    public Sprite happyAlma;
    public Sprite SadAlma;
    [Header("Congrats Text")]
    public Image congratText;
    public Sprite excellent;
    public Sprite ohWell;
    public bool travelMenu;

    void Start()
    {
        star1.gameObject.SetActive(false);
        star2.gameObject.SetActive(false);
        star3.gameObject.SetActive(false);
        if (travelMenu == true)
        {
            almaImage = null;
            happyAlma = null;
            SadAlma = null;
            congratText = null;
            excellent = null;
            ohWell = null;
        }
        else
        {
            almaImage.gameObject.SetActive(false);
            congratText.gameObject.SetActive(false);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        int.TryParse(totalScoreText.text, out numberTotalScore);

        if (travelMenu == true)
        {
            almaImage = null;
            happyAlma = null;
            SadAlma = null;
            congratText = null;
            excellent = null;
            ohWell = null;
        }



    }




    public void callForStars()
    {
        if (numberTotalScore >= 1)
        {
            star1.gameObject.SetActive(true);
            almaImage.sprite = SadAlma;
            almaImage.gameObject.SetActive(true);
            congratText.sprite = ohWell;
            congratText.gameObject.SetActive(true);

        }
        if (numberTotalScore >=65)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            almaImage.sprite = happyAlma;
            almaImage.gameObject.SetActive(true);
            congratText.sprite = excellent;
            congratText.gameObject.SetActive(true);

        }
        if (numberTotalScore >= 95)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            star3.gameObject.SetActive(true);
            almaImage.sprite = happyAlma;
            almaImage.gameObject.SetActive(true);
            congratText.sprite = excellent;
            congratText.gameObject.SetActive(true);

        }

    }




    public void starsCoroutine()
    {
        StartCoroutine(callForStarsMenu());
    }

    IEnumerator callForStarsMenu()
        
    {
        yield return new WaitForSeconds(0.1f);
        if (numberTotalScore >= 1)
        {
            star1.gameObject.SetActive(true);
        }
        if (numberTotalScore >= 65)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
        }
        if (numberTotalScore >= 95)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            star3.gameObject.SetActive(true);

        }

    }

    public void hideStars()
    {
        star1.gameObject.SetActive(false);
        star2.gameObject.SetActive(false);
        star3.gameObject.SetActive(false);
    }





}
