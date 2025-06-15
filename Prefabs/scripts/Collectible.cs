using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string itemName;
    public Sprite iconFound; // Set in Inspector
    public ItemPopup imagePopup; // Drag UI here in Inspector
    public AudioSource collectSound; // Drag AudioSource here in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();

            if (inventory != null)
            {
                inventory.AddItem(itemName);

                if (imagePopup != null && iconFound != null)
                    imagePopup.ShowPopup(iconFound);

                if (collectSound != null)
                {
                    // Detach sound from this object so it can play after destroy
                    collectSound.transform.parent = null;
                    collectSound.Play();
                    Destroy(collectSound.gameObject, collectSound.clip.length); // cleanup sound object
                }

                Destroy(gameObject);
            }
        }
    }
}
