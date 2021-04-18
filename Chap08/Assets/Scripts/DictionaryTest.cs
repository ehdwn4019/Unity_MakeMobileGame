using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class DictionaryTest : MonoBehaviour
{
    Dictionary<string, string> dic = new Dictionary<string, string>()
    {
        {"이름","조상철" },{"취미","축구"}
    };

    // Start is called before the first frame update
    void Start()
    {
        dic["이름"] += "조단비";
        dic["이름"] += "조은비";

        StringBuilder str = new StringBuilder();

        foreach(var tmp in dic)
        {
            str.Append("key = " + tmp.Key + "valye = " + tmp.Value+"\n");
        }

        Debug.Log(str.ToString());

        foreach(KeyValuePair<string,string> tmp in dic)
        {
            Debug.Log(tmp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
