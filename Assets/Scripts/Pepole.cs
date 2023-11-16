using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Pepole : MonoBehaviour
{
    
    Animator animator;

    NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer, playerLayer;
    
    public GameManager gm;

    AudioSource m_audioSource;
    public AudioClip f_screamSound;
    public AudioClip m_screamSound;
    
    //patrol
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float range;

    //state change
    [SerializeField] float sightRange;
    bool playerInSight;

    public float bugTime;
    private Vector3 lastPosition;  // ���� �������� �������� �����ϱ� ���� ����
    public float stop = 10;

    bool death = false;
    bool domang = false;

    void PlaySound(AudioClip ac)
    {
        m_audioSource.clip = ac;
        m_audioSource.Play();
    }
  
    void Chase()
    {
        if (gameObject.CompareTag("m")) PlaySound(m_screamSound);
        else PlaySound(f_screamSound);
        domang = true;
    }


    void Start()
    {

        lastPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        gm = GameObject.Find("GM").GetComponent<GameManager>();
        m_audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!death)
        {
            if (animator.GetBool("walk") || animator.GetBool("run"))
            {
                // ���� ������ ����
                Vector3 currentPosition = transform.position;

                // ���� �������� �����ǰ� ��
                if (Mathf.Approximately(currentPosition.x, lastPosition.x) && Mathf.Approximately(currentPosition.z, lastPosition.z))
                {
                    walkpointSet = false;
                }
                else
                {
                    // ��ȭ�� ������ walk �Ǵ� run ���� ����
                }

                // ���� �������� �������� ���� �����ǿ� ����
                lastPosition = currentPosition;
            }

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
            GetComponent<Collider>().isTrigger = true;
            gm.score += 100;
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
