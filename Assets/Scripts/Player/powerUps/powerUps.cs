using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class powerUps : MonoBehaviour
{
    public bool isTutorial ;

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
    public VisualEffect powerUpVFX;
    public GameObject bananaTrail;
    public GameObject fruitySwordVFX;
    [ColorUsage(true, true)]
    public Color bananaShoesColor;
    [ColorUsage(true, true)]
    public Color cocoColor;
    [ColorUsage(true, true)]
    public Color swordColor;



    void Start()
    {
        if (isTutorial == false)
        {
            originalSpeed = almaController.speed;
            originalAttack = GetComponent<PlayerAttack>().damagePlayer;
            powerUpVFX.gameObject.SetActive(false);
            bananaTrail.SetActive(false);
            fruitySwordVFX.SetActive(false);
        }
        
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
        currentSprite.sprite = bananaShoe;
        currentSprite.gameObject.SetActive(true);
        bananaTrail.SetActive(true);
        powerUpVFX.SetVector4("ParticlesColor", bananaShoesColor);
        powerUpVFX.gameObject.SetActive(true);

        almaController.speed = originalSpeed + plusSpeed;
        isActivated = true;
        yield return new WaitForSeconds(PowerUpDuration);

        currentSprite.gameObject.SetActive(false);
        bananaTrail.SetActive(false);
        
        currentSprite.sprite = null;
        powerUpVFX.gameObject.SetActive(false);
        almaController.speed = originalSpeed;
        isActivated = false;
        

    }

    IEnumerator fruitySwordMode()
    {
        Debug.Log(" FRUITY SWOOOORD");
        currentSprite.sprite = fruitySword;
        currentSprite.gameObject.SetActive(true);
        fruitySwordVFX.SetActive(true);
        powerUpVFX.SetVector4("ParticlesColor", swordColor);
        powerUpVFX.gameObject.SetActive(true);

        GetComponent<PlayerAttack>().damagePlayer = 7f;
        isActivated = true;
        yield return new WaitForSeconds(PowerUpDuration);

        powerUpVFX.gameObject.SetActive(false);
        fruitySwordVFX.SetActive(false);
        currentSprite.gameObject.SetActive(false);
        currentSprite.sprite = null;
        GetComponent<PlayerAttack>().damagePlayer = originalAttack;
        isActivated = false;
        currentPowerUp = " ";

    }

    IEnumerator cocoShieldMode()
    {
        Debug.Log(" cocoshield");
        currentSprite.sprite = cocoShield;
        currentSprite.gameObject.SetActive(true);
        powerUpVFX.SetVector4("ParticlesColor", cocoColor);
        powerUpVFX.gameObject.SetActive(true);
        isActivated = true;
        yield return new WaitForSeconds(PowerUpDuration);
        currentSprite.gameObject.SetActive(false);
        powerUpVFX.gameObject.SetActive(false);
        currentSprite.sprite = null;
        isActivated = false;
        currentPowerUp = " ";
    }





}
