using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
   
    
    // 자동차 사이렌, 버스정류장 3번
    public AudioSource Efx_Source;
  
    // 공 부딪힐때
    public AudioClip ball_1Sound;
    public AudioClip ball_2Sound;
    public AudioClip ball_3Sound;
    public AudioClip ball_4Sound;
    
    
    public AudioClip heatSound;
    public AudioClip wrongeatSound;


    public AudioClip trashSound;
    public AudioClip wrongSound;

    // 시체 발견 비명
    public AudioClip f_screamSound;
    public AudioClip m_screamSound;

    // 플립퍼
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
