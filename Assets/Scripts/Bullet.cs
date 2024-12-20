﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 20f;
    public int damage = 20;
    public Rigidbody2D rb;
    public GameObject impactEffect;

	// Use this for initialization
	void Start () {
        // moves bullet forward
        rb.velocity = transform.right * speed;
	} // start

    // Bullet hit registered
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        } // if

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    } // OnTriggerEnter
}
