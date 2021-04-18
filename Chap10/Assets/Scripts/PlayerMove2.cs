using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMove2 : MonoBehaviour
{
    public float playerSpeed = 3.0f;
    public float targetTime = 3.0f;
    public float elapsedTime = 0.0f;
    float dist = 4.0f;

    Transform camTr;
    CharacterController cc;

    GameObject previousObj;
    GameObject currentObj;
    public Image progressBar;

    RaycastHit hit;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        camTr = Camera.main.GetComponent<Transform>();
        cc = GetComponent<CharacterController>();

        ray = new Ray(camTr.position, camTr.forward * 100);
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(camTr.position, camTr.forward * 10);
        CheckGazeBtn();

        if (PlayerRayCast1.isStopped) return;
        MoveLookAt();
    }

    void MoveLookAt()
    {
        Vector3 dir = camTr.TransformDirection(Vector3.forward);
        cc.SimpleMove(dir * playerSpeed);
    }

    void CheckGazeBtn()
    {
        PointerEventData data = new PointerEventData(EventSystem.current);
        if(Physics.Raycast(ray,out hit,dist , 1<<9))
        {
            currentObj = hit.collider.gameObject;

            progressBar = currentObj.GetComponentsInChildren<Image>()[1];

            if(currentObj != previousObj)
            {
                elapsedTime = 0.0f;
                progressBar.fillAmount = 0.0f;

                if(previousObj != null)
                {
                    previousObj.GetComponentsInChildren<Image>()[1].fillAmount = 0.0f;
                }

                ExecuteEvents.Execute(currentObj, data, ExecuteEvents.pointerEnterHandler);
            }

            ExecuteEvents.Execute(previousObj, data, ExecuteEvents.pointerExitHandler);
            previousObj = currentObj;


        }
        else
        {
            elapsedTime += Time.deltaTime;
            progressBar.fillAmount = elapsedTime / targetTime;

            if(elapsedTime>=targetTime)
            {
                Debug.Log("Success!");
                hit.collider.gameObject.SetActive(false);
            }
        }
    }
}
