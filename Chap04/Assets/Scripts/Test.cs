using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject ball;
    public Transform shootPos;
    bool shootOK = true;
    
    // Start is called before the first frame update
    void Start()
    {
        if (shootOK)
            if (Input.GetKey(KeyCode.Space))
                StartCoroutine("ShootBall");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShootBall()
    {
        shootOK = false;
        GameObject tmp = Instantiate(ball, shootPos.position, shootPos.rotation);
        Destroy(tmp, 0.1f);
        yield return new WaitForSeconds(0.5f);
        shootOK = true;
    }
}
