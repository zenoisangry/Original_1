using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public Player player;
    public Transform muzzle;
    public Projectile projectile;
    public float msBetweenShots;
    public float muzzleVelocity;
    public float nextShotTime;

    public void Shoot()
    {
        msBetweenShots = 100;
        muzzleVelocity = 35;

        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as Projectile;
            newProjectile.SetSpeed(muzzleVelocity);

            source.clip = clip;
            source.Play();
        }
    }
}
