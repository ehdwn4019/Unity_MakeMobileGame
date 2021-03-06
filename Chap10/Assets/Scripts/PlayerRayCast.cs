using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    float distance = 30.0f;
    private RaycastHit hit;

    Transform camTr;
    CharacterController cc;
    private Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        camTr = Camera.main.GetComponent<Transform>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(camTr.position, camTr.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.green);

        if (Physics.Raycast(ray, out hit, distance, 1 << 9))
        {
            Debug.Log("Looking");
        }
        else
            Debug.Log("Out of looking");
    }
}
