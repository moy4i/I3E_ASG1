/*
* Author: Justin Tan
* Date: 13-6-2025
* Description: Controls bullet behavior, such as movement and collision with enemies or environment.
*/
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float damage;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (other.CompareTag("Untagged"))
        {
            Destroy(gameObject);
        }

    }


}
