using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("I am Player Awake");
    }

    private void OnEnable()
    {
        Debug.Log("I am Player OnEnable");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am Player Start");
    }

    private void OnDisable()
    {
        Debug.Log("I am Player OnDisable");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
