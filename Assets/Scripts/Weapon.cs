using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        } // if
	} // Update

    void Shoot ()
    {
        // shooting logic
        // Spawn a bullet into the world
        // Method below allows for spawning bullets
        // Instantiane(Object, Where to spawn, what rotation to spawn)
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    } // Shoot
} // Weapon
