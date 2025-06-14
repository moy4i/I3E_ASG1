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
}
