using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{

    private Scene scene; // scene manager stuff

    //Sound effects
    public AudioClip jump;
    public AudioClip land;
    public AudioSource movementSource;

    public AudioSource sandbox;
    public AudioSource carCrash;


    //Movement
    public float moveSpeed;

    public float groundDrag;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplyer;
    public bool readyToJump;

    //Keybinds
    public KeyCode jumpKey = KeyCode.Space;

    //Ground Check
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        readyToJump = true;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        movementSource = GetComponent<AudioSource>();

        scene = SceneManager.GetActiveScene(); //get current scene
    }

    // Update is called once per frame
    void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        //on ground
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }

        //in air
        else if(!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplyer, ForceMode.Force);
        }
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x,rb.velocity.y, limitedVel.z);
        }
    }

    void Jump()
    {
        
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        movementSource.clip = jump;
        movementSource.Play();
    }

    void ResetJump()
    {
        movementSource.clip = land;
        readyToJump = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sand Box")
        {
            sandbox.Play(); // play sandbox collision sound
            SceneManager.LoadScene("Credits"); //Change to game over scene when created
            Debug.Log("Switch to gameOver");
        }
    }
    

}
