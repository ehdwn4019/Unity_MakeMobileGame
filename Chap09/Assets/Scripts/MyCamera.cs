using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    Vector3 offset;

    public float cameraSpeed;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        Vector3 pos = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * cameraSpeed);

        transform.position = pos;
    }
}
