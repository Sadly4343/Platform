using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Used for EnemyHealth Values
public class EnemyHealth : MonoBehaviour
{
    //Initialize maxHealth of Enemy and CurrentHealth values.
    public int maxHealth = 50;
    private int currentHealth;


    //Start of game enemyhealth is = to 50 the MaxHealth Value.
    void Start()
    {
        currentHealth = maxHealth;
    }

    // If currentHealth <= 0 call HandleDeath() function
    void Update()
    {
        if (currentHealth <= 0)
        {
            HandleDeath();
        }
    }
    //If character takes damage subract from the enemy object health.
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        //Used to calculate if Max is always going to be 0.
        currentHealth = Mathf.Max(currentHealth, 0);
    }
    //Method for handling death of enemy.
    private void HandleDeath()
    {
        //Removes GameObject from the scene.
        Destroy(gameObject);
    }
}
