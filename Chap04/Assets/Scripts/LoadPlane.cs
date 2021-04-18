using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlane : MonoBehaviour
{
    public GameObject PlaneObject;
    public GameObject[] planes;
    public string all_data;
    public string[] data_list;

    private void Awake()
    {
        TextAsset TextF = (TextAsset)Resources.Load("planepos") as TextAsset;
        all_data = TextF.text;
        data_list = all_data.Split('\n');

        planes = new GameObject[data_list.Length];
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<data_list.Length-1; i++)
        {
            string[] splitedData = data_list[i].Split(',');
            Debug.Log(splitedData[0] + " " + float.Parse(splitedData[1]) + " " + float.Parse(splitedData[2]) + " " + float.Parse(splitedData[3]));

            planes[i] = Instantiate(PlaneObject) as GameObject;

            planes[i].transform.position = new Vector3(float.Parse(splitedData[1]), float.Parse(splitedData[2]), float.Parse(splitedData[3]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
