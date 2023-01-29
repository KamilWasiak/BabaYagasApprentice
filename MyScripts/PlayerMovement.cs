using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    bool isCrouching;
    Vector3 velocity;
    public float speed = 5f;
    public float gravity = -10f;
    public float jumpHeight = 1f;
    public bool allowJump;
    public bool allowCrouch;
    public float crouchModifier;
    private Vector3 origin;
    public GameObject standingCollider;
    public GameObject crouchingCollider;
    public Camera playerCamera;
    public GameObject cameraPlayer;


    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        if (StaticPlayer.lives > 0 && cameraPlayer.active)
        {

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            characterController.Move(move * speed * Time.deltaTime);

            if (allowJump)
            {
                if (Input.GetButtonDown("Jump") && isGrounded && !isCrouching)
                {
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

                }

            }

            if (allowCrouch)
            {
                if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
                {
                    speed *= crouchModifier;
                    playerCamera.transform.position = new Vector3 (playerCamera.transform.position.x, playerCamera.transform.position.y - 45f, playerCamera.transform.position.z);
                    standingCollider.SetActive(false);
                    crouchingCollider.SetActive(true);
                    isCrouching = true;
                }
                else if (Input.GetKeyUp(KeyCode.LeftControl) && isCrouching)
                {
                    speed /= crouchModifier;
                    playerCamera.transform.position = new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y + 45f, playerCamera.transform.position.z);
                    standingCollider.SetActive(true);
                    crouchingCollider.SetActive(false);
                    isCrouching = false;
                }

            }

            velocity.y += gravity * Time.deltaTime;

            characterController.Move(velocity * Time.deltaTime);

        }
    }
}
