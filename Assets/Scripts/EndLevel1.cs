using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class EndLevel1 : MonoBehaviour
{
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Level 1 End collision happened with " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log("Player complete level 1!");
        }
    }
}
