using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingCar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -0.04f);
        if (transform.position.z < -5)
            transform.position = new Vector3(Random.Range(-7f, 7f), 0, Random.Range(28f, 32f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="MISSILE")
        {
            transform.position = new Vector3(Random.Range(-7f, 7f), 0, Random.Range(28f, 32f));
            Destroy(collision.gameObject);
        }
    }
}
