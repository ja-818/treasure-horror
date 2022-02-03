using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerCamera;
    private Rigidbody playerRb;
    public float sensitivity;
    public float speed;
    public float jump;

    private float mouseX;
    private float mouseY;
    private float horizontalInput;
    private float verticalInput;
    private bool isOnGround = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Store keys and mouse inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        //Methods
        PlayerMovement();
        PlayerAndCameraRotation();
    }

    void PlayerMovement()
    {
        //Moves the player according to key imput
        playerRb.velocity = transform.TransformDirection(horizontalInput * speed, playerRb.velocity.y, verticalInput * speed);

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isOnGround = false;
        }
    }
    void PlayerAndCameraRotation()
    {
        //Rotates camera with mouse input
        playerCamera.transform.Rotate(mouseY * sensitivity * -1, 0f, 0f);

        //Rotates player with mouse input
        transform.Rotate(0f, mouseX * sensitivity, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
