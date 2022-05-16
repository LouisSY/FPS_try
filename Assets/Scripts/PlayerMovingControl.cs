using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// use to control the movement of player
public class PlayerMovingControl : MonoBehaviour
{
    private CharacterController characterController;

    public float walkSpeed = 10F;
    public float runSpeed = 15F;
    public float speed;
    private bool runFlag = false;  //check if running
    public Vector3 moveDirection;

    public float jumpForce = 3F;
    public Vector3 velocity;

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
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        runFlag = Input.GetKey(runInputKey);
        speed = runFlag ? runSpeed : walkSpeed;
        //Debug.Log(runFlag);

        moveDirection = (transform.right * hor + transform.forward * ver).normalized;  //get the moveDirection, and normalize the vector
        characterController.Move(moveDirection * speed * Time.deltaTime);

        //Debug.Log("hor: " + hor);
        //Debug.Log("ver: " + ver);
    }

    void Jump()
    {

    }
}
