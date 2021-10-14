using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.InputSystem;

public class PickUpObject : MonoBehaviour
{
    public Transform Player;            //where to hold the animal 
    public GameObject Animal;          //animal to pick up
    private bool CanPickUp = false;    //

    void OnPickup(InputValue PickupValue) //det nye inputsystem siger det skal hedde det her dont ask why
    {
        if (CanPickUp) //hvis det er true at man er within the collider af et animal tag object
        {
            Animal.transform.parent = Player.transform; //s�tter animal som et child af player 
        }
    }

    void OnTriggerEnter(Collider other) //n�r man g�r ind i en collider
    {
        if (other.tag == "Animal") //tjekker hvis det 'tag' p� den collider man g�r ind i er et animal
        {
            CanPickUp = true; //man kan samle det op
        }
    }

    void OnTriggerExit(Collider other) //n�r man g�r ud af animals collider
    {
        if (other.tag == "Animal") //tjekker hvis det 'tag' p� den collider man g�r ud af er et animal
        {
            CanPickUp = false; //man kan ikke l�ngere samle det op
        }
    }

}