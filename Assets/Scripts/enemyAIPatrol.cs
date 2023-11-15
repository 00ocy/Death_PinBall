using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyAIPatrol : MonoBehaviour
{
    GameObject player;
    Animator animator;
    NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer, playerLayer;

    //patrol
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float range;

    //state change
    [SerializeField] float sightRange;
    bool playerInSight;

    public float bugTime;
    public float stop = 10;

    bool death = false;
    bool domang = false;
    private Vector3 lastPosition;  // 이전 프레임의 포지션을 저장하기 위한 변수


    void Chase()
    {
        //agent.SetDestination(player.transform.position);
        domang = true;
    }


    void Start()
    {

        lastPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (animator.GetBool("walk") || animator.GetBool("run"))
        {
            // 현재 포지션 저장
            Vector3 currentPosition = transform.position;

            // 이전 프레임의 포지션과 비교
            if (Mathf.Approximately(currentPosition.x, lastPosition.x) && Mathf.Approximately(currentPosition.z, lastPosition.z))
            {
                walkpointSet = false;
            }
            else
            {
                // 변화가 있으면 walk 또는 run 값을 유지
            }

            // 현재 프레임의 포지션을 이전 포지션에 저장
            lastPosition = currentPosition;
        }

        if (!death)
        {
            if (!domang)
            {
                playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);

                if (agent.speed > 0.5f)
                {
                    animator.SetBool("walk", true);
                }
                else if (agent.speed == 0)
                {
                    animator.SetBool("walk", false);
                }

                Patrol();
                if (playerInSight) Chase();

                bugTime += Time.deltaTime;
                if (bugTime >= 8)
                {
                    walkpointSet = false;
                    agent.speed = 1.5f;
                }
            }
            else
            {
                Patrol();
                bugTime += Time.deltaTime;
                if (bugTime >= 8)
                {
                    walkpointSet = false;
                    agent.speed = 4f;
                }
                animator.SetBool("run", true);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            animator.SetBool("death", true);
            agent.speed = 0;
            death = true;
            gameObject.layer = LayerMask.NameToLayer("Player");
            //피 때문에 일단 고민
            GetComponent<Collider>().isTrigger = true;
        }
    }
    void Patrol()
    {
        if (!walkpointSet) SearchForDest();
        if (walkpointSet) agent.SetDestination(destPoint);
        if (domang) agent.speed = 4f;
        if (stop >= 1)
        {
            if (Vector3.Distance(transform.position, destPoint) < 3) walkpointSet = false;
        }
        else if (stop < 1)
        {
            if (!domang)
            {
                agent.speed = 0;
                if (bugTime > 3)
                {
                    agent.speed = 1.5f;
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, destPoint) < 3) walkpointSet = false;
            }

        }

    }
    void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);
        stop = Random.Range(0, 10);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
            bugTime = 0;
        }
    }
}
