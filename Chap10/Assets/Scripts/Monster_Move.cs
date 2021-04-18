using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Monster_Move : MonoBehaviour
{
    public Transform heroTr;
    private WaitForSeconds wfs;
    public NavMeshAgent Monster_Agent;
    public Animator animator;
    public Vector3 targetPosition;

    private void OnEnable()
    {
        StartCoroutine(CheckMonster());
        Debug.Log("OnEnable");
    }


    IEnumerator CheckMonster()
    {
        while (true)
        {
            yield return wfs;
            Monster_Agent.autoBraking = true;
            Monster_Agent.speed = 0.2f;
            ApproachTarget(heroTr.position);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        heroTr = player.GetComponent<Transform>();

        wfs = new WaitForSeconds(0.4f);

        Monster_Agent = GetComponent<NavMeshAgent>();
        Monster_Agent.autoBraking = false;

        animator = GetComponent<Animator>();
    }

    void ApproachTarget(Vector3 pos)
    {
        if (Monster_Agent.isPathStale) return;
        Monster_Agent.destination = pos;
        Monster_Agent.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
