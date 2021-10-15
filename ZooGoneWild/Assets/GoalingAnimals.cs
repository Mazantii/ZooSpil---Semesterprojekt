using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalingAnimals : MonoBehaviour
{
    public Transform Goal;            //goal
    public GameObject Animal;         //animal to keep
    public GameObject ThisPlayer;     //den player hvis goalzone det er

    public TouchPickUp touchpickup;
    public bool CanGoal = false;

    void Update()
    {
        if (CanGoal) //hvis det er true at man er within the collider af et animal tag object
        {
           Animal.transform.parent = null;                          //sætter animals parent til goal
           Animal.GetComponent<BoxCollider>().enabled = false;      //disabler animals collider
           Animal.GetComponent<CapsuleCollider>().enabled = false;  //disabler animals trigger collider
            touchpickup.HasPickedUp = false;
        }
    }

    void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject == ThisPlayer) //tjekker hvis det object der collider er goalzonens player
        {
            if (touchpickup.HasPickedUp == true) 
            {
            CanGoal = true; //man aflevere
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == ThisPlayer) //tjekker hvis det object på den collider er den player hvis goalzone det er
        {
            CanGoal = false; //man kan ikke aflevere
        }
    }
}