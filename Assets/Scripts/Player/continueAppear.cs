using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continueAppear : MonoBehaviour
{

    public GameObject continueButton;
    // Start is called before the first frame update
    void Start()
    {
        if (levelScores.levelOneScore > 0)
        {
            continueButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
