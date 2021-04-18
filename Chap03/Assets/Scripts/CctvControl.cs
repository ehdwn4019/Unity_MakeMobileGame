using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CctvControl : MonoBehaviour
{
    Transform pos = null;

    // Start is called before the first frame update
    void Start()
    {
        pos = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(pos);
    }
}
