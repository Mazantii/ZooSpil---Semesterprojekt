using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public Rigidbody Bullet;
    public Transform FireTransform;
    public AudioSource ShootingAudio;
    public AudioClip FireClip;
    public float BulletSpeed;
    public float BulletCooldown;

    private bool Fired;
    private void FixedUpdate()
    {
        if (BulletCooldown > 0)
        {
            BulletCooldown -= 1 * Time.deltaTime;
        }
    }
    void OnFire(InputValue FireValue)
    {
        if (BulletCooldown <= 0)
        {
            Fire();
            BulletCooldown += 1;
        }
    }

    private void Fire()
    {
        Rigidbody BulletInstance = Instantiate(Bullet, FireTransform.position, FireTransform.rotation) as Rigidbody;

        BulletInstance.velocity = BulletSpeed * FireTransform.forward;
    }
}
