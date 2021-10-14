using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPickUp : MonoBehaviour
{
    public GameObject Animal;
    public Transform Player;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Animal")
        {
            Animal.transform.parent = Player.transform;
        }
    }
}
