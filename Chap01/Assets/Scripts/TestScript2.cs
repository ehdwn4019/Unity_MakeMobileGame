using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript2 : MonoBehaviour
{
    public static TestScript2 instance;
    public int a = 10;

    private void Awake()
    {
        if(TestScript2.instance==null)
        {
            TestScript2.instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(a);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(a);
    }


    public void TestScript2Func()
    {
        Debug.Log("다른 오브젝트 스크립트 함수 호출");
    }
}
