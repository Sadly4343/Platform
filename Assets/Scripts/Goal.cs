using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // The scene to load
    private string Level2;


    // This method is automatically called when something enters the trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Log to the console when the trigger is hit

        // Check if the object has the tag "Player"
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player reached goal!");
            SceneManager.LoadScene(sceneBuildIndex: 1, LoadSceneMode.Single);
        }
    }
}