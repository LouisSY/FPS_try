using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// use to control the movement of player
public class PlayerMovingControl : MonoBehaviour
{
    private CharacterController characterController;
    public float speed = 5F;
    public Vector3 moveDirection;
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

    void Move() {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        moveDirection = (transform.right * hor + transform.forward * ver).normalized;  //get the moveDirection, and normalize the vector

        characterController.Move(moveDirection * speed * Time.deltaTime);

        // Debug.Log("hor: " + hor);
        // Debug.Log("ver: " + ver);
    }
}
