using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject ball;
    public Transform shootPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            GameObject tmp = Instantiate(ball, shootPos.position, shootPos.rotation);
            Destroy(tmp, 0.5f);
        }
    }
}
