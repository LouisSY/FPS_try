using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100F;
    public Transform playerPosition;  // current player position
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        playerPosition.Rotate(Vector3.up * mouseX);  //left and right
        transform.localRotation = Quaternion.Euler(mouseY, 0F, 0F);

        // Debug.Log("mouseX: " + mouseX);
        // Debug.Log("mouseY: " + mouseY);
    }
}
