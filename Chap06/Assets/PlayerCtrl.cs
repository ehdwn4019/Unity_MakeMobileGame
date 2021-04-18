using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    CharacterController controller;

    Vector3 moveDir = Vector3.zero;

    int speed = 3;
    int rotation_speed = 2;

    float gravity = 9.8f;
    float jumpSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDir.z = Input.GetAxis("Vertical") * speed;
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotation_speed, 0);

        //if (controller.isGrounded)
        //    moveDir.y = 0;
        //else
        //    moveDir.y -= gravity * Time.deltaTime;

        if(controller.isGrounded)
            if(Input.GetKeyDown(KeyCode.Space))
            {
                gravity = 10.0f;
                moveDir.y = jumpSpeed;
            }

        Vector3 globalDir = transform.TransformDirection(moveDir); // 로컬좌표에서 글로벌 좌표로 변경

        controller.Move(moveDir * Time.deltaTime);
    }
}
