using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject player;
    public float speed = 12.0f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded = false;
    public static bool isInDialogue = false;
    public static bool canMove = true;

    public LayerMask isInteractableObj;
    public GameObject Letter_E;
    private bool objInInteractableRange = false;
    public float interactableRange;

    private CharacterController controller;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        objInInteractableRange = Physics.CheckSphere(transform.position, interactableRange, isInteractableObj);
        if (canMove)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.forward * z + transform.right * x;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        if (objInInteractableRange)
        {
            // print("E");
            Letter_E.SetActive(true);
        }
        else
        {
            // print("!E");
            Letter_E.SetActive(false);
        }
    }

    public void Disactivate()
    {
        player.SetActive(false);
    }

    public void Activate()
    {
        player.SetActive(true);
    }
}