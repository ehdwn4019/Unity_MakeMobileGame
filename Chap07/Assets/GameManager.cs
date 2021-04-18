using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform randPos;
    public GameObject fightingCar;
    int numOfCar = 15;
    GameObject timeTextObj;
    int startTime = 0;
    int lapsedTime;
    Text lapsedTimeText;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<numOfCar; i++)
        {
            randPos.position = new Vector3(Random.Range(-7f, 7f), 0, Random.Range(28f, 32f));
            Instantiate(fightingCar, randPos.position, randPos.rotation);
        }

        timeTextObj = GameObject.Find("Timer");
        lapsedTimeText = timeTextObj.GetComponent<Text>();

        lapsedTimeText.text = startTime.ToString();
        startTime = (int)Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        lapsedTime = (int)Time.time - startTime;
        lapsedTimeText.text = "지나간 시간 : " + lapsedTime.ToString();
    }
}
