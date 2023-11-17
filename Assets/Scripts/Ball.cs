using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // ´ê¾ÒÀ»¶§ ³¯ ¼Ò¸® (Æ½, ÅÎ, ÆÃ~, ÆÜ, ±ø~)
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
        // ¼Ò¸® Ã£¾Æ¿Í¾ß µÊ
        // Àüµî ÄÑÁö´Â ¼Ò¸®
        if (collision.gameObject.CompareTag("Lamp"))
        {
            BallSound(SoundManager.instance.ball_1Sound);
        }
        // Àüº¿´ë¿¡ ºÎµúÈ÷´Â µíÇÑ ¼Ò¸®.. ÅÖ? ÅÍ¾û?
        else if (collision.gameObject.CompareTag("PowerPole"))
        {
            BallSound(SoundManager.instance.ball_2Sound);
        }
        // Â÷¶û ºÎµúÈ÷´Â ¼Ò¸®
        else if (collision.gameObject.CompareTag("Car"))
        {
            BallSound(SoundManager.instance.ball_3Sound);
        }

    }
    
}
