using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    private void Start()
    {
        currentLifeAmount = maxLifeAmount;
        
        
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
            Die();
        }
    }




    protected void Die()
    {
        isDead = true;
        Destroy(this.gameObject);
    }



}
