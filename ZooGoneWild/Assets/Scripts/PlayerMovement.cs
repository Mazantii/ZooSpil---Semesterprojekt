    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0; // speed forøger
    public float jumpSpeed = 0; // Hop forøger
    public bool isGrounded; // Tjekker om spilleren står på Ground
    public float rotationSpeed; // er hastigheden spilleren drejer til den retning der kigges

    private Rigidbody rb;

    private float movementX;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;

        }
    }

    void OnJump(InputValue jumpValue)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpSpeed * 100);
        }

    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

        //Hvis spilleren rykker sig, skal spilleren kigge i den rykkede retning.
        if(movement != Vector3.zero)
        {
            /*Denne type er brugt til at gemme rotationer*/
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);

            //Her faer vi spilleren til at rotere til den retning der kigges, saa det ikke sker i et hurtigt unaturligt hug.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void Update()
    {

    }

}