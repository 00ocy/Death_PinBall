using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // ������� �� �Ҹ� (ƽ, ��, ��~, ��, ��~)
    public AudioSource[] Ball_Source;
    

    void Start()
    {
        AudioSource[] Ball_Source = GetComponents<AudioSource>();
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

    private void OnCollisionEnter(Collision collision)
    {
        // �Ҹ� ã�ƿ;� ��
        // ���� ������ �Ҹ�
        if (collision.gameObject.CompareTag("Lamp"))
        {
            BallSound(SoundManager.instance.lamp);
        }
        // �����뿡 �ε����� ���� �Ҹ�.. ��? �;�?
        else if (collision.gameObject.CompareTag("PowerPole"))
        {
            Pole(SoundManager.instance.metal);
        }
        // ���� �ε����� �Ҹ�
        else if (collision.gameObject.CompareTag("Car"))
        {
            Carsound(SoundManager.instance.bbang);
        }
       /* else if (collision.gameObject.CompareTag("f") || collision.gameObject.CompareTag("m"))
        {
            person(SoundManager.instance.personHit);
        }*/

    }
    
}
