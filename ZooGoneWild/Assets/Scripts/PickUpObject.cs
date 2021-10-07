using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.InputSystem;

public class PickUpObject : MonoBehaviour
{
    public Transform Player;            //where to hold the animal 
    public GameObject Animal;          //animal to pick up


    void Start()
    {
       
    }

    void Update()
    {

    }

    void OnPickup(InputValue PickupValue)
    {
        Animal.transform.parent = Player.transform;
    }
}