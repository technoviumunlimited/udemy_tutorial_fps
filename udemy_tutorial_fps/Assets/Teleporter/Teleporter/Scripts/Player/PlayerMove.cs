using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Speed stings")]    
    public float WalkSpeed = 400;
    public float SprintSpeed = 700;
    
    [Header("Drag stings")]    
    public float airMultiplier = 0.1f;
    public float groundDrag = 5;
    public float airDrag = 0.5f;

    [Header("Jump stings")]    
    public float jumpForce = 500;
    public float jumpCooldown = 1f;
    public int multiJumpAmound = 1;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode SprintKey = KeyCode.LeftShift;

    [Header("Other")]
    public LayerMask whatIsGround;
    public Transform orientation;

    float MovmendSpeed;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;
    bool grounded;
    bool readyToJump = true;
    int JumpAmound;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        MyInput();

        grounded =Physics.Raycast(transform.position, Vector3.down, 1.3f, whatIsGround);

        // set Drag
        rb.drag = grounded ? groundDrag: airDrag;
        //reset JumpAmound
        if(grounded) JumpAmound = multiJumpAmound;
    }

    void FixedUpdate()
    {
        PlayerMovement();
        
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); // A en D
        verticalInput = Input.GetAxisRaw("Vertical");  // W en S

        
        MovmendSpeed = Input.GetKey(SprintKey)? SprintSpeed : WalkSpeed;

        if (Input.GetKeyDown(jumpKey))
        {
            Jump();

        }
    }

    private void PlayerMovement()
    {
        moveDirection = orientation.forward * verticalInput + horizontalInput * orientation.right;

        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * MovmendSpeed * 10,ForceMode.Force);
        }
        else
        {
            rb.AddForce(moveDirection.normalized *MovmendSpeed *10 *airMultiplier,ForceMode.Force);
        }
    }



   public void Jump()
    {
        if(readyToJump && JumpAmound > 0)
        {
            readyToJump = false;
            Invoke(nameof(ResetJump), jumpCooldown);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void ResetJump()
    {
        readyToJump = true;
        JumpAmound -=1;
    }
}
