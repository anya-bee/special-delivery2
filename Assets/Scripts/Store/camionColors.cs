using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camionColors : MonoBehaviour
{
    public Image gameSprite;
    public Sprite blueCamion;
    public Sprite redCamion;
    public Sprite purpleCamion;
    public Sprite original;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (storeManagement.currentBusMaterial == 0)
        {
            gameSprite.sprite = original;
        }
        else if (storeManagement.currentBusMaterial == 1)
        {
            gameSprite.sprite = blueCamion;
        }
        else if (storeManagement.currentBusMaterial == 2)
        {
            gameSprite.sprite = redCamion;
        }
        else if (storeManagement.currentBusMaterial == 3)
        {
            gameSprite.sprite = purpleCamion;
        }

    }
}
