using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string Level2;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger caused" + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player reached");
            SceneManager.LoadScene(Level2);
        }
    }
}
