using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("The player's movement speed.")]
    public float moveSpeed = 6.0f;
    [Tooltip("The player's jump height.")]
    public float jumpSpeed = 8.0f;
    [Tooltip("The player's gravity value.")]
    public float gravity = 20.0f;

    [Tooltip("The player's walking animation.")]
    
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal != 0 || vertical != 0)
            {
                // Rotate the player to face the direction of movement.
                transform.rotation = Quaternion.LookRotation(new Vector3(horizontal, 0, vertical));

                // Set the walking animation to true.
                animator.SetBool("isWalking", true);
            }
            else
            {
                // Set the walking animation to false.
                animator.SetBool("isWalking", false);
            }

            moveDirection = new Vector3(horizontal, 0, vertical);
            moveDirection *= moveSpeed;

            if (Input.GetButton("Jump"))
            {
                animator.SetTrigger("jump");
                moveDirection.y = jumpSpeed;
                
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}