using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerController : MonoBehaviour
{
    float horizontalMovement = 3f; // Adjust this value as needed
    public int counter = 0; // counter for direction

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        counter += 1; 

        // Update the object's position
        if (counter > 500)
        {
            horizontalMovement *= -1;
            counter = 0; 
        }
        
        transform.position += new Vector3(horizontalMovement * Time.deltaTime, 0, 0);
    }
}
