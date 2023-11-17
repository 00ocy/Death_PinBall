using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // ������� �� �Ҹ� (ƽ, ��, ��~, ��, ��~)
    public AudioSource Ball_Source;

    void Start()
    {
        Ball_Source = GetComponent<AudioSource>();
    }
    public void BallSound(AudioClip clip)
    {
        Ball_Source.clip = clip;
        Ball_Source.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        // �Ҹ� ã�ƿ;� ��
        // ���� ������ �Ҹ�
        if (collision.gameObject.CompareTag("Lamp"))
        {
            BallSound(SoundManager.instance.ball_1Sound);
        }
        // �����뿡 �ε����� ���� �Ҹ�.. ��? �;�?
        else if (collision.gameObject.CompareTag("PowerPole"))
        {
            BallSound(SoundManager.instance.ball_2Sound);
        }
        // ���� �ε����� �Ҹ�
        else if (collision.gameObject.CompareTag("Car"))
        {
            BallSound(SoundManager.instance.ball_3Sound);
        }

    }
    
}
