/*
* Author: Justin Tan
* Date: 13-6-2025
* Description: Triggers the end screen when player reaches the final mesh/area after unlocking the final door.
*/
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject endScreenUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show end screen
            if (endScreenUI != null)
                endScreenUI.SetActive(true);

            // Freeze everything
            Time.timeScale = 0f;

            // Unlock mouse and make it visible
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
