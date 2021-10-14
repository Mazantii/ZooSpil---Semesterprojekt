using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostScript : MonoBehaviour
{
    public float multiplier = 1.4f;
    public float duration = 5f;
    public GameObject pickupEffect;

    private void OnTriggerEnter(Collider other) // når et andet objekt rammer vores powerup. vil der ske førlgende. 
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("namnam");
            StartCoroutine(PickUp(other)); // 
            //gameObject.SetActive(false);
        }
    }

    IEnumerator PickUp(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation); // her laver vi en pickup effekt. 

        PlayerMovement stats = player.GetComponent<PlayerMovement>();
         stats.speed *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.speed /= multiplier; // her sætter vi farten tilbage til det normale. 

        Destroy(gameObject); // Her fjerner vi vores powerup objekt. 
    }
}
