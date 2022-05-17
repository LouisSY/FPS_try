using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100F;
    public Transform playerPosition;  // current player position
    public float x_rotation = 0F;
    // Start is called before the first frame update
    void Start()
    {
        //hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        x_rotation -= mouseY;
        x_rotation = Mathf.Clamp(x_rotation, -80F, 80F);   //limit x_rotation

        playerPosition.Rotate(Vector3.up * mouseX);  //left and right
        transform.localRotation = Quaternion.Euler(x_rotation, 0F, 0F);  //up and down

        // Debug.Log("mouseX: " + mouseX);
        // Debug.Log("mouseY: " + mouseY);
    }
}
