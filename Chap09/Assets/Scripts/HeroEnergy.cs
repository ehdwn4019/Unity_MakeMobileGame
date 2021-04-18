using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroEnergy : MonoBehaviour
{

    public Image mEnergy;
    public float currentEnergy;
    public float fullEnergy = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = fullEnergy;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("MUMMY"))
        {
            currentEnergy -= 10.0f;
            mEnergy.fillAmount = currentEnergy / fullEnergy;
        }
    }
}
