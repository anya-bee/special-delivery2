using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/clientListForLevel", order = 1)]
public class SO_ClientList : ScriptableObject
{

    public List<Orders> levelOrders;



    //call an order list based on a function


    
}


[System.Serializable]
public class Orders
{
    public List<string> singleOrder = new List<string>(3); 
}
