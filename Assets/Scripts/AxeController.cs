using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{

    [SerializeField] public float rotationSpeed = 100f;
    public int counter = 0; // counter for direction

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // float zPosition = transform.eulerAngles.z;
        if (counter > 30)
        {
            rotationSpeed *= -1;
            counter = 0; 
        }
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
