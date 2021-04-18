using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnEnable()
    {
        //Player.OnPlayerEvent += this.OnPlayerDetection;
        GameManager.instance.AddListener(GameManager.EventType.Touch, this.OnPlayerDetection);
        GameManager.instance.AddListener(GameManager.EventType.Die, this.OnPlayerDie);
        GameManager.instance.AddListener(GameManager.EventType.ExitTouch, this.OnPlayerExitDetection);
        
    }

    private void OnDisable()
    {
        //Player.OnPlayerEvent -= this.OnPlayerDetection;
    }

    void OnPlayerDetection()
    {
        Debug.Log("Red Alert");
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void OnPlayerDie()
    {
        Debug.Log("Player Dead");
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void OnPlayerExitDetection()
    {
        Debug.Log("Exit Detection");
        GetComponent<MeshRenderer>().material.color = Color.green;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
