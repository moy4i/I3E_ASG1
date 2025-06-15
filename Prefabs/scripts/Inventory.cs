/*
* Author: Justin Tan
* Date: 13-6-2025
* Description: Stores and tracks collected items (e.g., key parts), checks if crafting conditions are met.
*/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public Sprite icon;
}

public class Inventory : MonoBehaviour
{
    public List<string> collectedItems = new List<string>();
    public List<InventoryItem> itemSprites;       // Assign item name + sprite pairs here
    public Image[] inventorySlots;                // Assign 5 UI images here (in order)

    public GameObject masterKeyPrefab;            // Assign the Master Key prefab
    public Transform spawnPoint;                  // Assign the spawn location (e.g. near Blacksmith)

    public ItemPopup itemPopup;           // Drag your popup UI script here
    public Sprite masterKeyIcon;         // Assign the Master Key sprite here
    public void AddItem(string itemName)
    {
        if (!collectedItems.Contains(itemName))
        {
            collectedItems.Add(itemName);
            UpdateInventoryUI();
        }
    }

    public bool HasKey()
    {
        return collectedItems.Contains("MasterKey");
    }

    public void CraftKey()
    {
        if (collectedItems.Count == 5 && !collectedItems.Contains("MasterKey"))
        {
            collectedItems.Clear();                     // Remove all old items
            UpdateInventoryUI();
            if (itemPopup != null)
                itemPopup.ShowPopup(masterKeyIcon);

            if (masterKeyPrefab != null && spawnPoint != null)
            {
                Instantiate(masterKeyPrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }
    
    void UpdateInventoryUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < collectedItems.Count)
            {
                string item = collectedItems[i];
                Sprite icon = itemSprites.Find(x => x.itemName == item)?.icon;

                if (icon != null)
                {
                    inventorySlots[i].sprite = icon;
                    inventorySlots[i].color = Color.white;
                }
            }
            else
            {
                inventorySlots[i].sprite = null;
                inventorySlots[i].color = new Color(1, 1, 1, 0); // transparent slot
            }
        }
    }
}
