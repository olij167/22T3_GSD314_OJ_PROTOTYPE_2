using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    // Control Inventory UI
    // Add objects to a list
    // Interact with objects
    // Drop objects

    [SerializeField] private List<TextMeshProUGUI> inventoryListUI;
    [SerializeField] public List<InventoryItem> inventory;
    [SerializeField] private GameObject inventoryItemPrefab;
    [SerializeField] private GameObject inventoryPanel;

    [SerializeField] private Transform player;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void AddItemToInventory(InventoryItem item)
    {
        if (inventory.Contains(item))
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i] == item)
                {
                    inventory[i].numCarried += 1;
                    inventoryListUI[i].text = item.itemName + " x " + item.numCarried;
                }
            }
        }
        else
        {
            inventory.Add(item);
            item.numCarried = 1;
            GameObject newItemUI = Instantiate(inventoryItemPrefab, inventoryPanel.transform);
            TextMeshProUGUI newItemText = newItemUI.GetComponent<TextMeshProUGUI>();
            newItemText.text = item.itemName + " x " + item.numCarried;
            inventoryListUI.Add(newItemText);
        }
    }

    public void DropItem(InventoryItem item)
    {
        RemoveItemFromInventory(item);
        GameObject droppedItem = Instantiate(item.prefab, player);
        droppedItem.transform.parent = null;
    }

    public void RemoveItemFromInventory(InventoryItem item)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i] == item)
            {
                inventory[i].numCarried -= 1;

                if (inventory[i].numCarried <= 0f)
                {
                    inventory.RemoveAt(i);
                    Destroy(inventoryListUI[i].gameObject);
                }
            }
        }
    }



}
