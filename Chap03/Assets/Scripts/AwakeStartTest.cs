using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeStartTest : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("I am Awake");
    }

    private void OnEnable()
    {
        Debug.Log("I am OnEnable");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am Start!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
