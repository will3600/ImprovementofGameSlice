using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    static Animator anim;

    private float speed = 5.0f;
    private CharacterController controller;
    private Vector3 moveVector;
    private float gravity = 12.0f;
    private float verticalVelocity = 0.0f;
    private float jumpForce = 4.5f;

    private float animationDuration = 1.0f;
    private float startTime;

    // isDead false when you have not hit a collider
    private bool isDead = false;

    // Use this for initialization
    public void Start ()
    {
        anim = GetComponent<Animator>();

        // Refers to the character controller on the character (stored in the private CharacterController controller field)
        controller = GetComponent<CharacterController>();

        // Helps to prevent the player moving side to side when reloading the scene
        startTime = Time.time;
	}
	
	// Update is called once per frame
    public void Update ()
    {
        // If player dies, prevents player from playing further
        if (isDead)
            return;

        // Prevents the player from moving left or right as long as the camera animation is playing, as well as on death and reloading the scene
        if (Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            anim.SetBool("isRunning", true);
            return;
        }

        // Checks that the character is grounded and makes them effected by gravity
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;

            // When jump is activated, character jumps
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }   
        }
        else
        { 
          {
            // Brings the character back down to the ground
            verticalVelocity -= gravity * Time.deltaTime;
          }
        }

        // Controls for the character
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = Input.GetAxis("Vertical") * speed;

        // Allows the character to move and be seen moving
        controller.Move (moveVector * Time.deltaTime);


        // If the space bar is pressed, the jump animation activates
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
        }

        // Deals with the running and idle animations
        if (moveVector.z != 0)
        {
            // if the character is moving forward, the running animation plays and the idle animation stops
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            // if the character is moving forward, the running animation plays and the idle animation stops
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);
        }
    }

    // Controls speed in relation to diffiuclty level 
    public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }

    // When the collider hits something, this is called
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // If position in z and radius of capsule collider hit something tagged enemy, calls death
        if (hit.point.z > transform.position.z + 0.1f && hit.gameObject.tag == "Enemy")
            Death();
    }

    // Death function
    public void Death()
    {
        // isDead true when you do hit a collider
        isDead = true;
        // Gets the score of the player on death
        GetComponent<Score>().OnDeath ();
    }
}
