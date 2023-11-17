using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
   
    
    // �ڵ��� ���̷�, ���������� 3��
    public AudioSource Efx_Source;
  
    // �� �ε�����
    public AudioClip ball_1Sound;
    public AudioClip ball_2Sound;
    public AudioClip ball_3Sound;
    public AudioClip ball_4Sound;
    
    
    public AudioClip heatSound;
    public AudioClip wrongeatSound;


    public AudioClip trashSound;
    public AudioClip wrongSound;

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
   
 
    public void EfxSound(AudioClip clip)
    {
        Efx_Source.clip = clip;
        Efx_Source.Play();
    }
}
