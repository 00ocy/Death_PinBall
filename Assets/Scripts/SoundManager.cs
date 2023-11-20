using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
   
    
    // 자동차 사이렌, 버스정류장 3번
    
  
    // 공 부딪힐때
    public AudioClip lamp;
    public AudioClip metal;
    public AudioClip bbang;
    public AudioClip personHit;
    //public AudioClip BusstopHit;
    

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
   
 
    
}
