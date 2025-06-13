using UnityEngine;

public class Doorbehavior : MonoBehaviour
{
    public Transform hinge;
    public float openAngle = 90f;
    public float openSpeed = 2f;
    public float autoCloseDelay = 3f;

    public bool isLocked = true;
    private bool isOpen = false;
    private float openTimer = 0f;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = hinge.localRotation;
        openRotation = hinge.localRotation * Quaternion.Euler(0, openAngle, 0);
    }

    void Update()
    {
        Quaternion targetRotation = isOpen ? openRotation : closedRotation;
        hinge.localRotation = Quaternion.Slerp(hinge.localRotation, targetRotation, Time.deltaTime * openSpeed);

        if (isOpen)
        {
            openTimer -= Time.deltaTime;
            if (openTimer <= 0f)
            {
                CloseDoor();
            }
        }
    }

    public bool TryToggleDoor()
    {
        if (isLocked)
        {
            Inventory inventory = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Inventory>();
            if (inventory.HasKey())
            {
                isLocked = false; // Unlock the door
            }
            else
            {
                return false; // Still locked
            }
        }

        if (isOpen)
            CloseDoor();
        else
            OpenDoor();

        return true;
    }

    public void OpenDoor()
    {
        isOpen = true;
        openTimer = autoCloseDelay;
    }

    public void CloseDoor()
    {
        isOpen = false;
    }

    public bool IsOpen => isOpen;
    public bool IsLocked()
    {
        return isLocked;
    }
}
