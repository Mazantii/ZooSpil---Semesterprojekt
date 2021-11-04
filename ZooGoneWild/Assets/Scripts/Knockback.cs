using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float KnockbackStrenght;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
               Vector3 direction = rb.transform.position - transform.position;
                direction.y = 0;

                rb.AddForce(direction.normalized * KnockbackStrenght, ForceMode.Impulse);
            }

        }
    }

}
