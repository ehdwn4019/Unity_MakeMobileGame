using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallJump : MonoBehaviour
{
    float gravity = 0.0f;
    Vector3 YPos;

    Vector3 pos = new Vector3(0f, 250f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        YPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(KeyCode.Space))
        //{
        //    gravity = 10.0f;
        //}
        //
        //YPos.y += gravity * Time.deltaTime;
        //transform.position = YPos;
        //Debug.Log(gravity);
        //
        //if(YPos.y<=0.0f)
        //{
        //    YPos.y = 0.0f;
        //    gravity = 0.0f;
        //}
        //
        //gravity -= 0.4f;

        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody>().AddForce(pos);
    }
}
