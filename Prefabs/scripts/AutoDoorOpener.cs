/*
* Author: Justin Tan
* Date: 13-6-2025
* Description: Automatically opens big door when player collects 3 items.
*/
using UnityEngine;

public class AutoDoorOpener : MonoBehaviour
{
    private bool hasOpened = false;

    void Update()
    {
        if (hasOpened) return;

        Inventory inventory = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Inventory>();
        if (inventory != null && inventory.collectedItems.Count >= 3)
        {
            // Rotate door instantly
            transform.rotation *= Quaternion.Euler(0f, 90f, 0f);
            hasOpened = true;
        }
    }
}
