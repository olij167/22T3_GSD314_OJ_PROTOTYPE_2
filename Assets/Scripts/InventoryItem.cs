using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="InventoryItem")]
public class InventoryItem : ScriptableObject
{
    public GameObject prefab;
    public string itemName;
    public int numCarried;

}
