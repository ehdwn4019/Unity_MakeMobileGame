using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public delegate void PlayerEventHandler();
    public enum EventType
    {
        Touch,
        Die,
        ExitTouch
    }
    public static Dictionary<EventType, PlayerEventHandler> _delegateDic;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddListener(EventType EventType,PlayerEventHandler delegateFunc)
    {
        if(_delegateDic.ContainsKey(EventType)==false)
        {
            _delegateDic.Add(EventType, delegateFunc);
        }

        _delegateDic[EventType] += delegateFunc;
    }

    public void NotifyEvent(EventType EventType)
    {
        if (_delegateDic.ContainsKey(EventType) == false)
            return;

        foreach(PlayerEventHandler delegator in _delegateDic[EventType].GetInvocationList())
        {
            delegator();
        }
    }
   

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
