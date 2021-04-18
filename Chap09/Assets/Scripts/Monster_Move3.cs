using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Monster_Move3 : MonoBehaviour
{
    public List<Transform> movePoints;
    public int nextPoint = 0;
    public Transform heroTr;
    private WaitForSeconds wfs;

    public NavMeshAgent Monster_Agent;
    public bool isPatrolling;
    public Animator animator;
    public Vector3 targetPosition;

    public int monster_Energy = 5;

    private void OnEnable()
    {
        StartCoroutine(CheckMonster());
        var p_group = GameObject.Find("EnemyMovePos2");

        p_group.GetComponentsInChildren<Transform>(movePoints);
        nextPoint = Random.Range(0, movePoints.Count);
        movePoints.RemoveAt(0);
    }

    IEnumerator CheckMonster()
    {
        while(true)
        {
            yield return wfs;

            float distance = Vector3.Distance(this.transform.position , heroTr.transform.position);
            
            if(distance<=2.0)
            {
                Monster_Agent.speed = 0.1f;
                Monster_Agent.autoBraking = true;
            }
            else if(distance > 2.0 && distance<=8.0f)
            {
                Monster_Agent.autoBraking = false;
                Monster_Agent.speed = 0.8f;
                isPatrolling = false;

                ApproachTarget(heroTr.position);
            }
            else
            {
                Monster_Agent.autoBraking = false;
                Monster_Agent.speed = 0.5f;
                isPatrolling = true;
                Monster_Agent.destination = movePoints[nextPoint].position;
                MoveMonster();
            }
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
        isPatrolling = true;
        MoveMonster();
        Monster_Agent.speed = 1.0f;
    }

    void MoveMonster()
    {
        if(isPatrolling)
        Monster_Agent.destination = movePoints[nextPoint].position;
        Monster_Agent.isStopped = false;
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
        if (!isPatrolling) return;
        if(Monster_Agent.remainingDistance<=0.5f)
        {
            nextPoint = Random.Range(0, movePoints.Count);
            MoveMonster();
        }
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
            this.gameObject.SetActive(false);
            GameManager.instance.UpgradeScore();
            Invoke("SpawnMonster", 10f);
        }
    }

    void SpawnMonster()
    {
        monster_Energy = 5;
        nextPoint = Random.Range(0, movePoints.Count);
        this.gameObject.SetActive(true);
    }
}
