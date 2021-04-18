using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Move : MonoBehaviour
{

    public float missile_speed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * missile_speed);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2f);
    }
}
