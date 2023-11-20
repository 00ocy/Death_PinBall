using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
   
    
    // �ڵ��� ���̷�, ���������� 3��
    
  
    // �� �ε�����
    public AudioClip lamp;
    public AudioClip metal;
    public AudioClip bbang;
    public AudioClip personHit;
    //public AudioClip BusstopHit;
    

    // ��ü �߰� ���
    public AudioClip f_screamSound;
    public AudioClip m_screamSound;

    // �ø���
    public AudioClip flipperUpSound;
    public AudioClip flipperDownSound;
    private void Awake()
    {
        if (SoundManager.instance == null) SoundManager.instance = this;
       
    }
   
 
    
}
