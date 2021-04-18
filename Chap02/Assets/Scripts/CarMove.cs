using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    float speed = 3.0f;
    float startTime = 0.0f;

    float rot = 90f;
    

    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(Vector3.up * rot);
        //
        //transform.Translate(Vector3.forward* speed);
        //Debug.Log("distance=" + this.transform.position.z);
        //
        //transform.position += new Vector3(0, 0, 1f* speed);
        //Debug.Log("distance=" + this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //startTime += Time.deltaTime;
        //
        //if(startTime<=3.0f)
        //{
        //    transform.Translate(Vector3.forward * speed *Time.deltaTime);
        //    transform.Rotate(Vector3.up * rot * Time.deltaTime);
        //}

        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up * -rot * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up * rot * Time.deltaTime);
    }
}
