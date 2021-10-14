using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalingAnimals : MonoBehaviour
{
    public Transform Goal;            //goal
    public GameObject Animal;         //animal to keep
    public GameObject ThisPlayer; 

    private bool CanGoal = false;     

    void Update()
    {
        if (CanGoal) //hvis det er true at man er within the collider af et animal tag object
        {
           Animal.transform.parent = null; //disabler animal
           Animal.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider other) 
    {
       
        if (other.tag == "Animal" && ThisPlayer.GetComponent<CapsuleCollider>()) //tjekker hvis det 'tag' på den collider man går ind i er et animal
        {
            CanGoal = true; //man aflevere
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Animal" && ThisPlayer.GetComponent<CapsuleCollider>()) //tjekker hvis det 'tag' på den collider der rører en er et animal
        {
            CanGoal = false; //man kan ikke aflevere
        }
    }

}