using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip pickupTreasureSound;
    public Transform playerCamera;
    public float sensitivity;
    public float speed;
    public float jump;

    private AudioSource playerAudio;
    private Rigidbody playerRb;
    private float mouseX;
    private float mouseY;
    private float horizontalInput;
    private float verticalInput;

    private bool isOnGround = true;
    private bool hasTreasure = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
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

        if (other.CompareTag("Treasure"))
        {
            Destroy(other.gameObject);
            hasTreasure = true;
            playerAudio.PlayOneShot(pickupTreasureSound);
        }
    }
}
