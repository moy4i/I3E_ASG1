using UnityEngine;
using TMPro;
using System.Collections;

public class Interactable : MonoBehaviour
{
    public float interactDistance = 3f;
    public Transform playerCamera;

    [Header("UI Prompts")]
    public TextMeshProUGUI doorPrompt;
    public TextMeshProUGUI blacksmithPrompt;
    public TextMeshProUGUI doorLockedPrompt;
    public TextMeshProUGUI blacksmithErrorPrompt;

    private Doorbehavior currentDoor;
    private GameObject currentBlacksmith;

    void Start()
    {
        if (playerCamera == null)
            playerCamera = Camera.main?.transform;

        if (doorPrompt != null) doorPrompt.enabled = false;
        if (blacksmithPrompt != null) blacksmithPrompt.enabled = false;

        SetupCanvasGroup(doorLockedPrompt);
        SetupCanvasGroup(blacksmithErrorPrompt);
    }

    void SetupCanvasGroup(TextMeshProUGUI prompt)
    {
        if (prompt != null)
        {
            prompt.enabled = false;
            if (prompt.GetComponent<CanvasGroup>() == null)
                prompt.gameObject.AddComponent<CanvasGroup>();
        }
    }

    void Update()
    {
        if (playerCamera == null) return;

        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        bool isLookingAtSomething = false;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            GameObject target = hit.collider.gameObject;

            // === DOOR ===
            if (target.CompareTag("Door"))
            {
                currentDoor = target.GetComponent<Doorbehavior>();
                currentBlacksmith = null;

                if (currentDoor != null)
                {
                    doorPrompt.enabled = true;
                    blacksmithPrompt.enabled = false;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (!currentDoor.TryToggleDoor())
                        {
                            if (doorLockedPrompt != null)
                            {
                                StopAllCoroutines();
                                StartCoroutine(FadeMessage(doorLockedPrompt.text, doorLockedPrompt));
                            }
                        }
                    }

                    isLookingAtSomething = true;
                    return;
                }
            }

            // === BLACKSMITH ===
            if (target.CompareTag("Blacksmith"))
            {
                currentBlacksmith = target;
                currentDoor = null;

                doorPrompt.enabled = false;
                blacksmithPrompt.enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
                    if (inventory != null)
                    {
                        if (inventory.collectedItems.Count < 5)
                        {
                            if (blacksmithErrorPrompt != null)
                            {
                                StopAllCoroutines();
                                StartCoroutine(FadeMessage(blacksmithErrorPrompt.text, blacksmithErrorPrompt));
                            }
                        }
                        else
                        {
                            inventory.CraftKey();
                        }
                    }
                }

                isLookingAtSomething = true;
                return;
            }
        }

        if (!isLookingAtSomething)
        {
            doorPrompt.enabled = false;
            blacksmithPrompt.enabled = false;
        }

        currentDoor = null;
        currentBlacksmith = null;
    }

    IEnumerator FadeMessage(string msg, TextMeshProUGUI prompt)
    {
        if (prompt == null) yield break;

        prompt.text = msg;
        prompt.enabled = true;

        CanvasGroup group = prompt.GetComponent<CanvasGroup>();
        group.alpha = 1f;

        yield return new WaitForSeconds(2f);

        while (group.alpha > 0)
        {
            group.alpha -= Time.deltaTime;
            yield return null;
        }

        prompt.enabled = false;
    }
}
