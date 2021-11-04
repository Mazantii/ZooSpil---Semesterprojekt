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
    public float speedBoost; //Hvor mange sekunders speedboost spilleren har
    public float speedBoostMultiplier; //Hvor meget hurtigere spilleren skal blive af speedboost

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
        if (other.tag == "Ground")
        {
            isGrounded = true;

        }
        else if (other.tag == "SpeedBoost") // her ser vi om vi rammer en speedboost
        {
            StartCoroutine(SpeedBoost()); // Hvis vi gør, så starter vi SpeedBoost Coroutinen-
            other.gameObject.SetActive(false); //- og sletter speedboosten.
        }
    }

    IEnumerator SpeedBoost()
    {
        speed *= speedBoostMultiplier; // Her sætter vi spillerens hastighed til at svare til den speedboost vi vil give.

       yield return new WaitForSeconds(speedBoost); // Her venter vi den antal tid vi har sat speedboost til at vare.

        speed /= speedBoostMultiplier; // Her går vi tilbage til normal hastighed efter speedboost er løbet ud.

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
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

}