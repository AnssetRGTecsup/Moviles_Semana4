using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratorMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
    }
}
