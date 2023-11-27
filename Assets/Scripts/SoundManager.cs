using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    // �������
    public AudioSource BG_Source;
    public AudioClip BG_Music;
    
    void BG_Sound(AudioClip ac)
    {
        BG_Source.clip = ac;
        BG_Source.Play();
    }

    // �� �ε�����
    public AudioClip lamp;
    public AudioClip metal;
    public AudioClip bbang;
    public AudioClip fHit;
    public AudioClip mHit;
    public AudioClip parking;
    public AudioClip trash;
    
    // ������
    public AudioClip siren;


    // ��ü �߰� ���
    public AudioClip f_screamSound;
    public AudioClip m_screamSound;

    // �ø���
    public AudioClip flipperUpSound;
    public AudioClip flipperDownSound;
    private void Start()
    {
        BG_Sound(BG_Music);
    }
    private void Awake()
    {
        if (null == instance)
        {
            //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ���ӸŴ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�.
            instance = this;

            //�� ��ȯ�� �Ǵ��� �ı����� �ʰ� �Ѵ�.
            //gameObject�����ε� �� ��ũ��Ʈ�� ������Ʈ�μ� �پ��ִ� Hierarchy���� ���ӿ�����Ʈ��� ��������, 
            //���� �򰥸� ������ ���� this�� �ٿ��ֱ⵵ �Ѵ�.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� GameMgr�� ������ ���� �ִ�.
            //�׷� ��쿣 ���� ������ ����ϴ� �ν��Ͻ��� ��� ������ִ� ��찡 ���� �� ����.
            //�׷��� �̹� ���������� instance�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� ���� GameMgr)�� �������ش�.
            Destroy(this.gameObject);
        }
    }
   
 
    
}
