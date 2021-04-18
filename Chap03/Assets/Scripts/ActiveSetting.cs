using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSetting : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.SetActive(true);
        }
    }
}
