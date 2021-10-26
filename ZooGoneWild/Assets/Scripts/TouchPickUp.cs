using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPickUp : MonoBehaviour
{
    public GameObject Animal;
    public GameObject Player;
    
    public bool HasPickedUp;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Animal")
        {
            Animal.transform.parent = Player.transform;
            Animal.transform.localPosition = new Vector3 (-1, 0, 1);
            Animal.transform.localRotation = Quaternion.identity;
            HasPickedUp = true;
        }
    }
}
