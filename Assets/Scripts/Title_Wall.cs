using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleWall : MonoBehaviour
{
    public AudioSource wall;

    void wallSound(AudioClip ac)
    {
        wall.clip = ac;
        wall.Play();
    }
    void pick(int n)
    {
        switch (n)
        {
            case 0: wallSound(SoundManager.instance.metal); break;
            case 1: wallSound(SoundManager.instance.metal); break;
            case 2: wallSound(SoundManager.instance.bbang); break;
            case 3: wallSound(SoundManager.instance.siren); break;
            case 4: wallSound(SoundManager.instance.parking); break;
            case 5: wallSound(SoundManager.instance.trash); break;
            case 6: wallSound(SoundManager.instance.siren); break;
            case 7: wallSound(SoundManager.instance.f_screamSound); break;
            case 8: wallSound(SoundManager.instance.m_screamSound); break;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            pick(Random.Range(0, 8));
        }
    }


    void Start()
    {
        wall = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}