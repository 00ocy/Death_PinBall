using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // ������� �� �Ҹ� (ƽ, ��, ��~, ��, ��~)
    public AudioSource[] Ball_Source;
    public GameManager gm;

    int obj;
  
      

    void Start()
    {
        AudioSource[] Ball_Source = GetComponents<AudioSource>();
        gm = GameObject.Find("GM").GetComponent<GameManager>();

    }
    public void BallSound(AudioClip clip)
    {
        Ball_Source[0].clip = clip;
        Ball_Source[0].Play();
    }
    public void Pole(AudioClip clip)
    {
        Ball_Source[1].clip = clip;
        Ball_Source[1].Play();
    }
    public void Carsound(AudioClip clip)
    {
        Ball_Source[2].clip = clip;
        Ball_Source[2].Play();
    }
    public void person(AudioClip clip)
    {
        Ball_Source[3].clip = clip;
        Ball_Source[3].Play();
    }
    public void parking(AudioClip clip)
    {
        Ball_Source[4].clip = clip;
        Ball_Source[4].Play();
    }
    public void trash(AudioClip clip)
    {
        Ball_Source[5].clip = clip;
        Ball_Source[5].Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �Ҹ� ã�ƿ;� ��
        // ���� ������ �Ҹ�
        if (collision.gameObject.CompareTag("Lamp"))
        {
            BallSound(SoundManager.instance.lamp);
            gm.score += 50;
        }
        // �����뿡 �ε����� ���� �Ҹ�.. ��? �;�?
        else if (collision.gameObject.CompareTag("PowerPole"))
        {
            Pole(SoundManager.instance.metal);
            gm.score += 50;
        }
        // ���� �ε����� �Ҹ�
        else if (collision.gameObject.CompareTag("Car"))
        {
            Carsound(SoundManager.instance.bbang);
            gm.score += 50;
        }
        else if (collision.gameObject.CompareTag("f"))
        {
            person(SoundManager.instance.fHit);
            gm.score += 100;
        }
        else if (collision.gameObject.CompareTag("m"))
        {
            person(SoundManager.instance.mHit);
            gm.score += 100;
        }
        else if (collision.gameObject.CompareTag("parking") || collision.gameObject.CompareTag("h"))
        {
            parking(SoundManager.instance.parking);
            gm.score += 50;
        }
        else if (collision.gameObject.CompareTag("trash"))
        {
            trash(SoundManager.instance.trash);
            gm.score += 25;
        }
        else if (collision.gameObject.CompareTag("BusStopPole"))
        {
            // ���� ������� ��(SoundManager.instance.trash);
            gm.score += 150;
        }

    }
    
}
