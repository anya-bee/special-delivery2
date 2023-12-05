using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerNewHealth : MonoBehaviour
{
    public float currentLifeAmount;
    public float maxLifeAmount;

    [Header("HeartIcons")]
    public GameObject heartPrefab;
    List<healthHeart> hearts = new List<healthHeart>();


    private void Update()
    {
        currentLifeAmount = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().currentLifeAmount;
        maxLifeAmount = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().maxLifeAmount;
        drawHearts();
    }

    public void drawHearts()
    {
        clearHearts();

        float maxHealthRemainder = maxLifeAmount % 3;
        int heartToMake = (int)(maxLifeAmount / 3 + maxHealthRemainder);
        for(int i=1; i < heartToMake; i++)
        {
            createEmptyHeart();
        }
        for(int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(currentLifeAmount - (i * 3), 0, 3);
            hearts[i].setHeartImage((HeartStatus)heartStatusRemainder);
        }

    }

    public void createEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        healthHeart heartComponent = newHeart.GetComponent<healthHeart>();
        heartComponent.setHeartImage(HeartStatus.empty);
        hearts.Add(heartComponent);
    }


    public void clearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);

        }
        hearts = new List<healthHeart>();
    }

    
}
