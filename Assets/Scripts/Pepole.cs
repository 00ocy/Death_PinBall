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

    public AudioSource Scream_Source;
    
    //patrol
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float range;

    //state change
    [SerializeField] float sightRange;
    bool CorpseInSight;

    public float bugTime;
    private Vector3 lastPosition;  // ���� �������� �������� �����ϱ� ���� ����
    public float stop = 10;

    bool death = false;
    bool domang = false;

    void Scream_Sound(AudioClip ac)
    {
        Scream_Source.clip = ac;
        Scream_Source.Play();
    }
  
    void Find_corpse()
    {
        if (gameObject.CompareTag("m")) Scream_Sound(SoundManager.instance.m_screamSound);
        else Scream_Sound(SoundManager.instance.f_screamSound);
        domang = true;
    }


    void Start()
    {
        lastPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        gm = GameObject.Find("GM").GetComponent<GameManager>();
        Scream_Source = GetComponent<AudioSource>();
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
                CorpseInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);

                if (agent.speed > 0.5f)
                {
                    animator.SetBool("walk", true);
                }
                else if (agent.speed == 0)
                {
                    animator.SetBool("walk", false);
                }

                Patrol();
                if (CorpseInSight) Find_corpse();

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
        else
        {
            // death ���¿��� 10�� �Ŀ� DeactivateObject �޼��带 ȣ���ϵ��� ����
            Invoke("DeactivateObject", 10f);
        }
    }
    void DeactivateObject()
    {
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            animator.SetBool("death", true);
            agent.speed = 0;
            agent.enabled = false;
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
