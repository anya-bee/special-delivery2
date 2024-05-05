using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
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
    public UnityEvent refreshBlender;

    [Header("Power Ups Sprites")]
    public Sprite bananaShoe;
    public float plusSpeed;
    public Sprite cocoShield;
    public Sprite fruitySword;
    public Image PowerUpBar;
    public float powerUpTimer;

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
            PowerUpBar.gameObject.SetActive(false);
            PowerUpBar.fillAmount = 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPowerUp == "bananaShoesMode")
        {
            StartCoroutine(bananaShoesMode());
            
            PowerUpBar.fillAmount = (powerUpTimer -= Time.deltaTime) / PowerUpDuration;

        }
        else if (currentPowerUp == "cocoShieldMode")
        {
            StartCoroutine(cocoShieldMode());
            
            PowerUpBar.fillAmount = (powerUpTimer -= Time.deltaTime) / PowerUpDuration;
        }
        else if ( currentPowerUp == "fruitySwordMode")
        {
            StartCoroutine(fruitySwordMode());
            
            PowerUpBar.fillAmount = (powerUpTimer -= Time.deltaTime) / PowerUpDuration;
        }
    }

    IEnumerator bananaShoesMode()
    {
        Debug.Log(" BANANA EFFECT ");
        currentSprite.sprite = bananaShoe;
        currentSprite.gameObject.SetActive(true);
        bananaTrail.SetActive(true);
        PowerUpBar.fillAmount = 1;
        PowerUpBar.gameObject.SetActive(true);
        
        //powerUpVFX.SetVector4("ParticlesColor", bananaShoesColor);
        //powerUpVFX.gameObject.SetActive(true);
        
        
        almaController.speed = originalSpeed + plusSpeed;
        isActivated = true;
        yield return new WaitForSeconds(PowerUpDuration);

        currentSprite.gameObject.SetActive(false);
        bananaTrail.SetActive(false);
        refreshBlender.Invoke();
        currentSprite.sprite = null;
        powerUpVFX.gameObject.SetActive(false);
        almaController.speed = originalSpeed;
        powerUpTimer = PowerUpDuration;
        isActivated = false;
        currentPowerUp = " ";
        PowerUpBar.color = Color.green;
        powerUpTimer = PowerUpDuration;


    }

    IEnumerator fruitySwordMode()
    {
        Debug.Log(" FRUITY SWOOOORD");
        currentSprite.sprite = fruitySword;
        currentSprite.gameObject.SetActive(true);
        fruitySwordVFX.SetActive(true);
        PowerUpBar.fillAmount = 1;
        //powerUpVFX.SetVector4("ParticlesColor", swordColor);
        //powerUpVFX.gameObject.SetActive(true);
        PowerUpBar.gameObject.SetActive(true);
        
        GetComponent<PlayerAttack>().damagePlayer = 7f;
        isActivated = true;
        yield return new WaitForSeconds(PowerUpDuration);

        powerUpVFX.gameObject.SetActive(false);
        fruitySwordVFX.SetActive(false);
        currentSprite.gameObject.SetActive(false);
        currentSprite.sprite = null;
        GetComponent<PlayerAttack>().damagePlayer = originalAttack;
        refreshBlender.Invoke();
        isActivated = false;
        PowerUpBar.color = Color.green;
        currentPowerUp = " ";
        powerUpTimer = PowerUpDuration;

    }

    IEnumerator cocoShieldMode()
    {
        Debug.Log(" cocoshield");
        PowerUpBar.fillAmount = 1;
        currentSprite.sprite = cocoShield;
        currentSprite.gameObject.SetActive(true);
        PowerUpBar.gameObject.SetActive(true);
        
        
        powerUpVFX.SetVector4("ParticlesColor", cocoColor);
        powerUpVFX.gameObject.SetActive(true);
        isActivated = true;
        yield return new WaitForSeconds(PowerUpDuration);
        currentSprite.gameObject.SetActive(false);
        powerUpVFX.gameObject.SetActive(false);
        refreshBlender.Invoke();
        currentSprite.sprite = null;
        isActivated = false;
        currentPowerUp = " ";
        PowerUpBar.color = Color.green;
        powerUpTimer = PowerUpDuration;
    }





}
