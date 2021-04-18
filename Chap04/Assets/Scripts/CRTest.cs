using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TestCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TestCoroutine()
    {
        Debug.Log("TestCoroutine() start");
        yield return new WaitForSeconds(3.0f);
        Debug.Log("3 seconds lapsed");
    }
}
