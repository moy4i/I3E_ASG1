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
