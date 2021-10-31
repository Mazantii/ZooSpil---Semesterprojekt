using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // public ParticleSystem BulletParticles;
    // public AudioSource BulletAudio;
    public float Damage = 33f;
    public float MaxLifeTime = 2f;

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, MaxLifeTime); // slettes efter maxlifetime tid.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);
            Destroy(gameObject);
        }
        else if (other.tag == "Ground")
        {
            Destroy(gameObject);
        }

        /*BulletParticles.transform.parent = null;
        BulletParticles.Play();

        BulletAudio.Play();

        Destroy(BulletParticles.gameObject, BulletParticles.main.duration);
        Destroy(gameObject);
        */

    }



}
