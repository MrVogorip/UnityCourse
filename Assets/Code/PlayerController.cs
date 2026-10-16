using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float WalkSpeed = 2.5f;
    public float RunSpeed = 5f;
    public float RotationSpeed = 720f;
    public float JumpSpeed = 5f;

    private CharacterController characterController;
    private Animator animator;
    private InputAction moveAction;
    private InputAction sprintAction;
    private InputAction jumpAction;
    private float verticalSpeed;

    private string currentTrigger;
    
    private const string IsIdleTrigger = "IsIdle";
    private const string IsRunningTrigger = "IsRunning";
    private const string IsWalkingTrigger = "IsWalking";
    private const string IsJumpTrigger = "IsJump";

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        moveAction = InputSystem.actions.FindAction("Move");
        sprintAction = InputSystem.actions.FindAction("Sprint");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        var input = moveAction.ReadValue<Vector2>();
        var direction = new Vector3(input.x, 0, input.y);
        var isRunning = sprintAction.IsPressed();
        var speed = isRunning ? RunSpeed : WalkSpeed;

        if (characterController.isGrounded)
        {
            verticalSpeed = -2f;

            if (jumpAction.WasPressedThisFrame())
            {
                verticalSpeed = JumpSpeed;
                PlayAnimation(IsJumpTrigger);
            }
        }

        verticalSpeed += Physics.gravity.y * Time.deltaTime;

        var velocity = direction * speed;
        velocity.y = verticalSpeed;
        characterController.Move(velocity * Time.deltaTime);

        if (direction != Vector3.zero)
        {
            var targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }

        if (!characterController.isGrounded)
            return;

        if (direction == Vector3.zero)
            PlayAnimation(IsIdleTrigger);
        else if (isRunning)
            PlayAnimation(IsRunningTrigger);
        else
            PlayAnimation(IsWalkingTrigger);
    }

    private void PlayAnimation(string trigger)
    {
        if (currentTrigger == trigger)
            return;
        
        animator.ResetTrigger(currentTrigger);
        currentTrigger = trigger;
        animator.SetTrigger(trigger);
    }
}
