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


    [Header("RetryMenu")]

    public Image fadeToBlack;
    public Image iconBorad;
    



    private void Start()
    {
        maxLifeAmount = levelScores.almaLife;
        currentLifeAmount = maxLifeAmount;
        fadeToBlack.gameObject.SetActive(false);
        iconBorad.gameObject.SetActive(false);
        GetComponent<Animator>().SetLayerWeight(1, 0);

    }

    private void Update()
    {
        if(currentLifeAmount > maxLifeAmount)
        {
            currentLifeAmount = maxLifeAmount;
        }



    }


    public void Damage(float amount)
    {
        if ( GetComponent<powerUps>().currentPowerUp != "cocoShieldMode")
        {
            currentLifeAmount -= amount;
            
        }
        

        

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
