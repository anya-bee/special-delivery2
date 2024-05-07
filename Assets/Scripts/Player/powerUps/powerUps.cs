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
    public int powerUpNumber;
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
            powerUpNumber = 3;
        }
        
    }
    public void OrbSpawn()
    {
        int randomOrb = Random.Range(0, 3);
        powerUpNumber = randomOrb;
        if (powerUpNumber == 0)
        {
            powerUpNumber = 0;
            StartCoroutine(bananaShoesMode());
            refreshBlender.Invoke();
            

        }
        else if (powerUpNumber == 1)
        {
            powerUpNumber = 2;
            StartCoroutine(cocoShieldMode());
            refreshBlender.Invoke();
            
        }
        else if (powerUpNumber == 2)
        {
            powerUpNumber = 2;
            StartCoroutine(fruitySwordMode());
            refreshBlender.Invoke();
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if ( powerUpNumber < 3)
        {
            PowerUpBar.fillAmount = (powerUpTimer -= Time.deltaTime) / PowerUpDuration;
        }
        
    }

    IEnumerator bananaShoesMode()
    {
        Debug.Log(" BANANA EFFECT ");
        currentPowerUp = "BananaShoes";
        PowerUpBar.color = PowerUpBar.GetComponent<barColorCode>().targetGreenColor;
        currentSprite.sprite = bananaShoe;
        currentSprite.gameObject.SetActive(true);
        bananaTrail.SetActive(true);
        PowerUpBar.fillAmount = 1;
        PowerUpBar.gameObject.SetActive(true);
        //PowerUpBar.fillAmount = (powerUpTimer -= Time.deltaTime) / PowerUpDuration;
        //powerUpVFX.SetVector4("ParticlesColor", bananaShoesColor);
        //powerUpVFX.gameObject.SetActive(true);


        almaController.speed = originalSpeed + plusSpeed;
        isActivated = true;
        yield return new WaitForSeconds(PowerUpDuration);

        currentSprite.gameObject.SetActive(false);
        bananaTrail.SetActive(false);
        
        currentSprite.sprite = null;
        powerUpVFX.gameObject.SetActive(false);
        almaController.speed = originalSpeed;
        powerUpTimer = PowerUpDuration;
        isActivated = false;
        currentPowerUp = " ";
        PowerUpBar.color = PowerUpBar.GetComponent<barColorCode>().targetGreenColor;
        powerUpTimer = PowerUpDuration;
        powerUpNumber = 3;

    }
    

    IEnumerator fruitySwordMode()
    {
        Debug.Log(" FRUITY SWOOOORD");
        currentPowerUp = "FruitSword";
        PowerUpBar.color = PowerUpBar.GetComponent<barColorCode>().targetGreenColor;
        currentSprite.sprite = fruitySword;
        currentSprite.gameObject.SetActive(true);
        fruitySwordVFX.SetActive(true);
        PowerUpBar.fillAmount = 1;
        //powerUpVFX.SetVector4("ParticlesColor", swordColor);
        //powerUpVFX.gameObject.SetActive(true);
        PowerUpBar.gameObject.SetActive(true);
        //PowerUpBar.fillAmount = (powerUpTimer -= Time.deltaTime) / PowerUpDuration;
        GetComponent<PlayerAttack>().damagePlayer = 7f;
        isActivated = true;
        yield return new WaitForSeconds(PowerUpDuration);

        powerUpVFX.gameObject.SetActive(false);
        fruitySwordVFX.SetActive(false);
        currentSprite.gameObject.SetActive(false);
        currentSprite.sprite = null;
        GetComponent<PlayerAttack>().damagePlayer = originalAttack;
        
        isActivated = false;
        PowerUpBar.color = PowerUpBar.GetComponent<barColorCode>().targetGreenColor;
        currentPowerUp = " ";
        powerUpTimer = PowerUpDuration;
        powerUpNumber = 3;

    }

    IEnumerator cocoShieldMode()
    {
        Debug.Log(" cocoshield");
        currentPowerUp = "cocoShieldMode";
        PowerUpBar.color = PowerUpBar.GetComponent<barColorCode>().targetGreenColor;
        PowerUpBar.fillAmount = 1;
        currentSprite.sprite = cocoShield;
        currentSprite.gameObject.SetActive(true);
        PowerUpBar.gameObject.SetActive(true);
        //PowerUpBar.fillAmount = (powerUpTimer -= Time.deltaTime) / PowerUpDuration;

        powerUpVFX.SetVector4("ParticlesColor", cocoColor);
        powerUpVFX.gameObject.SetActive(true);
        isActivated = true;
        yield return new WaitForSeconds(PowerUpDuration);
        currentSprite.gameObject.SetActive(false);
        powerUpVFX.gameObject.SetActive(false);
        
        currentSprite.sprite = null;
        isActivated = false;
        currentPowerUp = " ";
        PowerUpBar.color = PowerUpBar.GetComponent<barColorCode>().targetGreenColor;
        powerUpTimer = PowerUpDuration;
        powerUpNumber = 3;
    }





}
