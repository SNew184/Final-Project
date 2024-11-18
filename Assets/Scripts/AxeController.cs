using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{

    [SerializeField] public float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        float zPosition = transform.eulerAngles.z;
        if (zPosition > 80)
        {
            rotationSpeed *= -1;
        }
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        // Debug.Log(transform.rotation);
        // Debug.Log(transform.eulerAngles.z);
    }
}
