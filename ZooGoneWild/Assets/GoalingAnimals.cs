using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalingAnimals : MonoBehaviour
{
    public Transform Goal;            //goal
    public GameObject Animal;         //animal to keep
    private bool CanGoal = false;     

    void Update()
    {
        if (CanGoal) //hvis det er true at man er within the collider af et animal tag object
        {
           Animal.SetActive(false); //disabler animal
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Animal") //tjekker hvis det 'tag' p� den collider man g�r ind i er et animal
        {
            CanGoal = true; //man aflevere
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Animal") //tjekker hvis det 'tag' p� den collider der r�rer en er et animal
        {
            CanGoal = false; //man kan ikke aflevere
        }
    }

}