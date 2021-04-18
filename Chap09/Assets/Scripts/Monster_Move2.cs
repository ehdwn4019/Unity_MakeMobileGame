using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Monster_Move2 : MonoBehaviour
{
    public int monster_Energy = 5;
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
        while(true)
        {
            yield return wfs;

            Monster_Agent.autoBraking = true;
            Monster_Agent.speed = 1.2f;
            ApproachTarget(heroTr.position);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        var player = GameObject.FindGameObjectWithTag("Player");

        heroTr = player.GetComponent<Transform>();
        wfs = new WaitForSeconds(0.4f);


        Monster_Agent = GetComponent<NavMeshAgent>();
        Monster_Agent.autoBraking = false;

        animator = GetComponent<Animator>();
        Monster_Agent.speed = 1.0f;
    }

    void ApproachTarget(Vector3 pos)
    {
        if (Monster_Agent.isPathStale) return;
        Monster_Agent.destination = pos;
        Monster_Agent.isStopped = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (monster_Energy > 0)
            if (collision.collider.CompareTag("MISSILE"))
            {
                monster_Energy -= 1;
            }
            else
                return;

        if (monster_Energy <= 0)
        {
            Destroy(this.gameObject,0.1f);
            GameManager.instance.UpgradeScore();
        }
    }
}
