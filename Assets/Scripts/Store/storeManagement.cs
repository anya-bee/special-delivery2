using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storeManagement : MonoBehaviour
{

    private static storeManagement _instance;
    public static int materialListNumber;
    public static int currentBusMaterial;

    public static storeManagement instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<storeManagement>();
            }

            return _instance;
        }
    }

    [Header("Bus Materials")]
    public List<Material> busMaterial = new List<Material>();

    private static storeManagement dontDestroyOnLoadScript_storeManagement;


    

    private Renderer busRenderer;
    public almaCurrentBus thisBus;


    private void Awake()
    {
        

        GameObject[] objs = GameObject.FindGameObjectsWithTag("storeManager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);






    }

    private void Update()
    {
        thisBus = FindObjectOfType<almaCurrentBus>();
        busRenderer = thisBus.GetComponent<Renderer>();

        for (int i = 0; i < busMaterial.Count; i++)
        {
            if (currentBusMaterial == i)
            {
                busRenderer.material = busMaterial[i];
            }
        }
    }

    

}
