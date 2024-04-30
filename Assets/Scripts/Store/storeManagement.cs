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


    [Header("Original Colors")]
    public Color mainColor;
    public Color ambientShadow;
    public Color mainShadow;
    public Material blenderMaterial;

    [Header("Golden Colors")]
    public Color mainColorG;
    public Color ambientShadowG;
    public Color mainShadowG;

    private Renderer busRenderer;
    public almaCurrentBus thisBus;
    public Client_Manager thisClientManager;


    private void Awake()
    {

        

        GameObject[] objs = GameObject.FindGameObjectsWithTag("storeManager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        




    }

    private void Start()
    {
        levelScores.almaLife = 22;
        levelScores.clientsNewTimer = 40;
        
    }

    private void Update()
    {
        thisBus = FindObjectOfType<almaCurrentBus>();
        busRenderer = thisBus.GetComponent<Renderer>();
        thisClientManager = FindObjectOfType<Client_Manager>();


        blenderMaterial.SetColor("_Color", mainColor);
        blenderMaterial.SetColor("_AmbientShadow", ambientShadow);
        blenderMaterial.SetColor("_MainShadow", mainShadow);

        if(levelScores.blenderIsGolden == true)
        {
            blenderMaterial.SetColor("_Color", mainColorG);
            blenderMaterial.SetColor("_AmbientShadow", ambientShadowG);
            blenderMaterial.SetColor("_MainShadow", mainShadowG);
        }

        for (int i = 0; i < busMaterial.Count; i++)
        {
            if (currentBusMaterial == i)
            {
                busRenderer.material = busMaterial[i];
            }
        }
    }

    

}
