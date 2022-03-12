using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float EnemyHealth = 200;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        // Decreases the health of enemy
        GetDamage(damageDealer.GetDamageValue());
        //Destroys the laser
        CheckIfDestroyed();
    }

    private void CheckIfDestroyed()
    {
        if (EnemyHealth <= 0) {
            Destroy(gameObject);
        }
    }

    private void GetDamage(int damage)
    {
        EnemyHealth -= damage; 
    }

}
