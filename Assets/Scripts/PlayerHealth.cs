using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Health values.
    public int maxHealth = 100;
    private int currentHealth;
    //Calls the Player Controls Class.
    private PlayerControls playerControls;
    // Sets values and gets component PlayerControls.
    void Start()
    {
        currentHealth = maxHealth;
        playerControls = GetComponent<PlayerControls>();
    }

    // If health is <= 0 cause player death by calling HandleDeath function.
    void Update()
    {
        if (currentHealth <= 0)
        {
            HandleDeath();
        }
    }
    // Take damage and calculate if health is equal to 0.
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Took damage! Current Health: " + currentHealth);

        currentHealth = Mathf.Max(currentHealth, 0);

    }
    private void HandleDeath()
    {
        transform.position = playerControls.respawnPoint;
        currentHealth = 100;
    }
}
