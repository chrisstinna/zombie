using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FireBullet : MonoBehaviour
{
    public float speed = 50f;
    public GameObject bulletObj;
    public Transform frontOfGun;
    public float damage = 10f; // Adjust damage value as needed
    public int maxAmmo = 100; // Maximum ammunition count
    private int currentAmmo; // Current ammunition count

    public static event Action GunFired;

    private void Start()
    {
        currentAmmo = maxAmmo; // Initialize current ammunition count
    }

    public void Fire()
    {
        if (currentAmmo > 0)
        {
        GetComponent<AudioSource>().Play();
        GameObject spawnedBullet = Instantiate(bulletObj, frontOfGun.position, frontOfGun.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * frontOfGun.forward;
        Destroy(spawnedBullet, 5f);
        GunFired?.Invoke();
        currentAmmo--; // Decrement ammunition count
        } else
        {
            Debug.Log("Out of ammo!");
            // Play out of ammo sound or provide feedback to the player
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is a zombie
        if (collision.gameObject.CompareTag("Zombie"))
        {
            // Get the zombie script component from the collided object
            zombieScript zombie = collision.gameObject.GetComponent<zombieScript>();

            // Check if the zombie script component is not null
            if (zombie != null)
            {
                // Call the TakeDamage method on the zombie, passing in the damage value
                zombie.TakeDamage(damage);
            }

            // Destroy the bullet object
            Destroy(gameObject);
        }
    }
}