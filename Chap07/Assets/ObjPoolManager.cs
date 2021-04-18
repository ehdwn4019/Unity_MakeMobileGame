using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPoolManager : MonoBehaviour
{
    public static ObjPoolManager instance = null;
    public GameObject missileObj;

    int maxNum = 8;

    public List<GameObject> misPools = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);
        DontDestroyOnLoad(this.gameObject);
        MakeMissile();
    }

    public GameObject GetMissile()
    {
        for(int i=0; i<maxNum; i++)
        {
            if (misPools[i].activeSelf == false)
                return misPools[i];
        }

        return null;
    }

    void MakeMissile()
    {
        GameObject objPools = new GameObject("ObjPools");

        for(int i=0; i<maxNum; i++)
        {
            var poolObj = Instantiate<GameObject>(missileObj, objPools.transform);
            poolObj.SetActive(false);
            poolObj.name = "Missile_ " + i.ToString("0");
            misPools.Add(poolObj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
