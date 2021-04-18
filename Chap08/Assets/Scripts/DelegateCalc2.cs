using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelegateCalc2 : MonoBehaviour
{
    InputField input1;
    InputField input2;

    GameObject inputObj1;
    GameObject inputObj2;
    GameObject resultText;

    Text result;

    public delegate void MCalculator(int x, int y);
    MCalculator mCalc;

    // Start is called before the first frame update
    void Start()
    {
        inputObj1 = GameObject.Find("Input1");
        inputObj2 = GameObject.Find("Input2");
        resultText = GameObject.Find("ResultText");
        result = resultText.GetComponent<Text>();

        mCalc = Sum;
        mCalc += Minus;
        mCalc += Multi;
    }

    public void OnPlusBtnClick()
    {
        input1 = inputObj1.GetComponent<InputField>();
        input2 = inputObj2.GetComponent<InputField>();
        mCalc(System.Convert.ToInt32(input1.text), System.Convert.ToInt32(input2.text));
    }

    public void Sum(int x, int y)
    {
        int answer = x + y;
        result.text = answer.ToString();
        Debug.Log(answer);
    }

    public void Minus(int x, int y)
    {
        int answer = x - y;
        result.text = answer.ToString();
        Debug.Log(answer);
    }

    public void Multi(int x, int y)
    {
        int answer = x * y;
        result.text = answer.ToString();
        Debug.Log(answer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
