/*
* Author: Justin Tan
* Date: 13-6-2025
* Description: Hazard script that instantly kills the player while standing in lava.
*/
using UnityEngine;

public class Lava : MonoBehaviour
{
    public string playerTag = "Player";
    public float lavaDamage = 9999f; // Enough to instantly "kill" player

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            PlayerStats stats = other.GetComponent<PlayerStats>();
            if (stats != null)
            {
                stats.TakeDamage(lavaDamage);
            }
        }
    }
}