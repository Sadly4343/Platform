using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    private int currentHealth;
    private PlayerControls playerControls;
    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Health initialized to: " + currentHealth);
        playerControls = GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            HandleDeath();
        }
    }

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
