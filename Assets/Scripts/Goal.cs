using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{


    // This method is automatically called when something enters the trigger collider
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Log to the console when the trigger is hit

        // Check if the object has the tag "Player"
        if (collider.CompareTag("Player"))
        {
            //Load the scene Level2 or any level after depending.
            SceneManager.LoadScene(sceneBuildIndex: 1, LoadSceneMode.Single);
        }
    }
}