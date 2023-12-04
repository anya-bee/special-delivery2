using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float currentLifeAmount;
    public float maxLifeAmount;
    public bool isDead;

    [Header("UI_Display")]
    public Transform heartSlot;
    public Transform heartIcon;
    public Image[] HeartSprite;
    public Sprite fullHeart;
    public float cellsize;

    [Header("RetryMenu")]

    public Image fadeToBlack;
    public Image iconBorad;
    



    private void Start()
    {
        currentLifeAmount = maxLifeAmount;
        fadeToBlack.gameObject.SetActive(false);
        iconBorad.gameObject.SetActive(false);

    }

    private void Update()
    {
        if(currentLifeAmount > maxLifeAmount)
        {
            currentLifeAmount = maxLifeAmount;
        }

        for (int i =0; i< HeartSprite.Length; i++)
        {
            if (i< currentLifeAmount)
            {
                HeartSprite[i].gameObject.SetActive(true);
                HeartSprite[i].sprite = fullHeart;
            }
            else
            {
                HeartSprite[i].gameObject.SetActive(false);
            }

            if (i < maxLifeAmount)
            {
                HeartSprite[i].enabled = true;
            }
            else
            {
                HeartSprite[i].enabled = false;
            }
        }
       

    }


    public void Damage(float amount)
    {
        currentLifeAmount -= amount;

        

        if (currentLifeAmount <= 0)
        {
            StartCoroutine(loseScreen());
        }
    }




    private void Die()
    {
        isDead = true;
        Destroy(this.gameObject);
    }


    IEnumerator loseScreen()
    {
        fadeToBlack.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        iconBorad.gameObject.SetActive(true);




    }



}
