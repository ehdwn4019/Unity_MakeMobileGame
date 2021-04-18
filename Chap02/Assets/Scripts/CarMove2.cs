using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove2 : MonoBehaviour
{
    float h = 0.0f;
    float v = 0.0f;
    float speed = 5.0f;
    float rot = 90.0f;

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

        moveCar = (Vector3.forward * v);

        transform.Translate(moveCar * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * h * Time.deltaTime*rot);

        Debug.Log("h= " + h.ToString());
        Debug.Log("v= " + v.ToString());
    }
}
