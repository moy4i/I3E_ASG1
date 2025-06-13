using UnityEngine;

public class BlacksmithTrigger : MonoBehaviour
{
    public string playerTag = "Player";

    private bool isPlayerNearby = false;
    private Inventory playerInventory;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isPlayerNearby = true;
            playerInventory = other.GetComponent<Inventory>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isPlayerNearby = false;
            playerInventory = null;
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (playerInventory != null)
            {
                if (playerInventory.collectedItems.Count < 5)
                {
                    // Show your error message via TMP UI here
                    Debug.Log("You need all 5 key parts to use the blacksmith.");
                }
                else
                {
                    playerInventory.CraftKey();
                }
            }
        }
    }
}
