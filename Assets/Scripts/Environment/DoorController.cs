using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider))] // added collider requirement
public class DoorController : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false; // added isOpen variable

    [Tooltip("The name of the trigger parameter to open the door.")]
    public string openTrigger = "openDoor";
    [Tooltip("The name of the trigger parameter to close the door.")]
    public string closeTrigger = "closeDoor";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOpen) // if door is open, close it
            {
                animator.SetTrigger(closeTrigger);
                isOpen = false;
            }
            else // if door is closed, open it
            {
                animator.SetTrigger(openTrigger);
                isOpen = true;
            }
        }
    }
}