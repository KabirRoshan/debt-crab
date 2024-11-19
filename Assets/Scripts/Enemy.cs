using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public int health = 100;

    public GameObject deathEffect;
    public Slider healthBar;

    public void TakeDamage(int damage)
    {
        health -= damage;

        // If health goes below zero then DIE!
        if (health <= 0)
        {
            Die();
        } // if
    } // TakeDamage

    void Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    } // Die
	
	// Update is called once per frame
	void Update () {
        healthBar.value = health;
	} // Update

}
