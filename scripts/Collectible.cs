using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string itemName;
    public Sprite icon; // Set in Inspector
    public ItemPopup itemPopup; // Drag UI here in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null)
            {
                inventory.AddItem(itemName);
                if (itemPopup != null && icon != null)
                    itemPopup.ShowPopup(icon);

                Destroy(gameObject);
            }
        }
    }
}
