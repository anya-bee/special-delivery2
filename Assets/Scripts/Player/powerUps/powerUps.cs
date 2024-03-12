using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class powerUps : MonoBehaviour
{
    [Header("Current Power Up")]
    public PlayerController almaController;
    public string currentPowerUp;
    public bool isActivated;
    public float originalSpeed;
    public float originalAttack;
    public float PowerUpDuration;
    public Image currentSprite;

    [Header("Power Ups Sprites")]
    public Sprite bananaShoe;
    public float plusSpeed;
    public Sprite cocoShield;
    public Sprite fruitySword;

    [Header("Power Ups VFX")]
    public VisualEffect bananaVFX;
    public VisualEffect cocoVFX;
    public VisualEffect swordVFX;



    void Start()
    {
        originalSpeed = almaController.speed;
        originalAttack = GetComponent<PlayerAttack>().damagePlayer;
        bananaVFX.gameObject.SetActive(false);
        cocoVFX.gameObject.SetActive(false);
        swordVFX.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (currentPowerUp == "bananaShoesMode")
        {
            StartCoroutine(bananaShoesMode());
            currentPowerUp = " ";

        }
        else if (currentPowerUp == "cocoShieldMode")
        {
            StartCoroutine(cocoShieldMode());
            
        }
        else if ( currentPowerUp == "fruitySwordMode")
        {
            StartCoroutine(fruitySwordMode());
            currentPowerUp = " ";
        }
    }

    IEnumerator bananaShoesMode()
    {
        Debug.Log(" BANANA EFFECT ");
        bananaVFX.gameObject.SetActive(true);
        currentSprite.sprite = bananaShoe;
        currentSprite.gameObject.SetActive(true);
        almaController.speed = originalSpeed + plusSpeed;
        isActivated = true;
        yield return new WaitForSeconds(PowerUpDuration);
        currentSprite.gameObject.SetActive(false);
        currentSprite.sprite = null;
        bananaVFX.gameObject.SetActive(false);
        almaController.speed = originalSpeed;
        isActivated = false;
        

    }

    IEnumerator fruitySwordMode()
    {
        Debug.Log(" FRUITY SWOOOORD");
        swordVFX.gameObject.SetActive(true);
        currentSprite.sprite = fruitySword;
        currentSprite.gameObject.SetActive(true);
        GetComponent<PlayerAttack>().damagePlayer = 7f;
        isActivated = true;
        yield return new WaitForSeconds(PowerUpDuration);
        currentSprite.gameObject.SetActive(false);
        currentSprite.sprite = null;
        GetComponent<PlayerAttack>().damagePlayer = originalAttack;
        isActivated = false;
        swordVFX.gameObject.SetActive(false);
        currentPowerUp = " ";

    }

    IEnumerator cocoShieldMode()
    {
        Debug.Log(" cocoshield");
        cocoVFX.gameObject.SetActive(true);
        currentSprite.sprite = cocoShield;
        currentSprite.gameObject.SetActive(true);
        isActivated = true;
        yield return new WaitForSeconds(PowerUpDuration);
        currentSprite.gameObject.SetActive(false);
        cocoVFX.gameObject.SetActive(false);
        currentSprite.sprite = null;
        isActivated = false;
        currentPowerUp = " ";
    }





}
