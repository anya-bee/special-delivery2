using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthHeart : MonoBehaviour
{

    public Sprite fullHeart, halfHeart, oneThirdHeart, emptyHeart;
    public Image heartImage;


    private void Start()
    {
        heartImage = GetComponent<Image>();

    }

    public void setHeartImage( HeartStatus status)
    {
        switch (status)
        {
            case HeartStatus.empty:
                heartImage.sprite = emptyHeart;
                break;
            case HeartStatus.oneThird:
                heartImage.sprite = oneThirdHeart;
                break;
            case HeartStatus.half:
                heartImage.sprite = halfHeart;
                break;
            case HeartStatus.full:
                heartImage.sprite = fullHeart;
                break;
        }
    }



}

public enum HeartStatus
{
    empty=0,
    oneThird=1,
    half= 2,
    full = 3,
}
