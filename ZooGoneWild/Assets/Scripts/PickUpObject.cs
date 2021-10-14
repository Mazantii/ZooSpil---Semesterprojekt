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
            Animal.transform.parent = Player.transform; //sætter animal som et child af player 
        }
    }

    void OnTriggerEnter(Collider other) //når man går ind i en collider
    {
        if (other.tag == "Animal") //tjekker hvis det 'tag' på den collider man går ind i er et animal
        {
            CanPickUp = true; //man kan samle det op
        }
    }

    void OnTriggerExit(Collider other) //når man går ud af animals collider
    {
        if (other.tag == "Animal") //tjekker hvis det 'tag' på den collider man går ud af er et animal
        {
            CanPickUp = false; //man kan ikke længere samle det op
        }
    }

}