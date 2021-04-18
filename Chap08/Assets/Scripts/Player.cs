using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void PlayerEventHandler();

    public static PlayerEventHandler OnPlayerEvent;
    int health = 50;
    public float speed = 3f;

    GameObject[] enemyObj;

    public int Health
    {
        get { return health; }
        set
        {
            health = Mathf.Clamp(value, 0, 100);
        }
    }

    private void Awake()
    {
        enemyObj = GameObject.FindGameObjectsWithTag("ENEMY");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
            health = Health - 5;
        if (health <= 0) OnPlayerEvent();

        PlayerMove();

        if (Health <= 0)
            //GameManager.instance.NotifyEvent(GameManager.EventType.Die);
            foreach (GameObject obj in enemyObj)
                obj.SendMessage("OnPlayerDie", SendMessageOptions.DontRequireReceiver);
    }

    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CHECKPOINT"))
        {
            //GameManager.instance.NotifyEvent(GameManager.EventType.Touch);
            foreach (GameObject cmp in enemyObj)
                cmp.SendMessage("OnPlayerDetection", SendMessageOptions.DontRequireReceiver);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("CHECKPOINT"))
        {
            //GameManager.instance.NotifyEvent(GameManager.EventType.ExitTouch);
            foreach (GameObject cmp in enemyObj)
                cmp.SendMessage("OnPlayerExitDetection", SendMessageOptions.DontRequireReceiver);
        }
    }
}
