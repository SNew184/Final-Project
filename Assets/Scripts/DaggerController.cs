using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerController : MonoBehaviour
{
    float horizontalMovement = 5f; // Adjust this value as needed

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the horizontal axis (e.g., left/right arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Update the object's position
        if ((int)Time.deltaTime % 2 == 0)
        {
            horizontalMovement *= -1;
        }
        transform.position += new Vector3(horizontalMovement * Time.deltaTime, 0, 0);
    }
}
