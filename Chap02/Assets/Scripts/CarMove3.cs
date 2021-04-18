using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove3 : MonoBehaviour
{
    float h = 0.0f;
    float v = 0.0f;
    float speed = 5.0f;

    Vector3 moveCar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        moveCar = (Vector3.forward * v)+(Vector3.right*h);

        transform.Translate(moveCar.normalized * speed * Time.deltaTime);

        Debug.Log(moveCar.normalized.magnitude);
    }
}
