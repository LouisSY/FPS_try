using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// use to control the movement of player
public class PlayerMovingControl : MonoBehaviour
{
    private CharacterController characterController;

    // Move and run
    [Header("Move and run settings")]
    public float walkSpeed = 10F;
    public float runSpeed = 15F;
    public float speed;
    private bool runFlag = false;  //check if running
    public Vector3 moveDirection;

    // Jump
    [Header("Jump settings")]
    public Vector3 playerVelocity;   // Player's y axis impulse changes
    private bool jumpFlag = false;
    private bool isGrounded = true;
    public float gravityValue = -9.81F;
    public float jumpHeight = 1.0F;

    // check slope
    private float onSlopeForce = 6.5f;   // The force on the slope prevents the character from bouncing when going downhill
    private float checkSlopeRayLength = 2.0f;  // the length of ray

    // keyboard input settings
    [Header("Keyboard settings")]
    [SerializeField][Tooltip("Press this key to run")] private KeyCode runInputKey = KeyCode.LeftShift;
    [SerializeField][Tooltip("Press this key to jump")] private KeyCode jumpInputKey = KeyCode.Space;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        isGrounded = characterController.isGrounded;
        if(isGrounded && playerVelocity.y < 0f)
        {
            playerVelocity.y = 0f;
        }

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        runFlag = Input.GetKey(runInputKey);
        speed = runFlag ? runSpeed : walkSpeed;
        //Debug.Log("run: " + runFlag);

        moveDirection = (transform.right * hor + transform.forward * ver).normalized;  //get the moveDirection, and normalize the vector
        characterController.Move(moveDirection * speed * Time.deltaTime);

        Jump();

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);

        if (IsOnSlope())
        {
            characterController.Move(Vector3.down * characterController.height / 2 * onSlopeForce * Time.deltaTime);
        }

        //Debug.Log("hor: " + hor);
        //Debug.Log("ver: " + ver);
    }

    void Jump()
    {
        jumpFlag = Input.GetKey(jumpInputKey);
        //Debug.Log(jumpFlag);
        if(jumpFlag && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * gravityValue * -3.0F);
        }
    }

    public bool IsOnSlope()
    {
        if(jumpFlag)
        {
            return false;
        }

        RaycastHit hit;
        bool generateRay = Physics.Raycast(transform.position, Vector3.down, out hit, characterController.height/2*checkSlopeRayLength);

        if (generateRay)
        {
            if (hit.normal != Vector3.up)
            {
                return true;   // is on slope
            }
        }

        return false;
    }
}
