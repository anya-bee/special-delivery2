using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juiceGenerator : MonoBehaviour
{
    public Transform prefabJuice;
    public string juiceType;
    private Renderer fruitrender1;

    // creates a juice glass based on the fruits added to the blender
    public void SetJuice(List<string> juiceOrder)
    {
        
        Transform transform = Instantiate(prefabJuice, this.transform.position, Quaternion.identity);
        juiceGlass juiceGlass1 = transform.GetComponent<juiceGlass>();
        juiceGlass1.glassOrder = juiceOrder;
        juiceGlass1.juiceType = juiceGlass1.glassOrder[0];
        juiceGlass1.juiceColor = juiceGlass1.GetColor();

        

    }

    


}
