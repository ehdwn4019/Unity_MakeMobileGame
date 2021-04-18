using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test00 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody;
        rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        //Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("I am Update");
    }
}
