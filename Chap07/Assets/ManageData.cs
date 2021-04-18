using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageData : MonoBehaviour
{

    string mName;
    int mPower = 0;

    // Start is called before the first frame update
    void Start()
    {
        SaveData();
        GetData();

        Debug.Log("Name : " + mName);
        Debug.Log("Power : " + mPower);
    }

    public void GetData()
    {
        mName = PlayerPrefs.GetString("Name", "N/A");
        mPower = PlayerPrefs.GetInt("Power");
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("Name", "마징가");
        PlayerPrefs.SetInt("Power", 30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
