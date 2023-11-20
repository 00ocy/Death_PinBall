using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // ´ê¾ÒÀ»¶§ ³¯ ¼Ò¸® (Æ½, ÅÎ, ÆÃ~, ÆÜ, ±ø~)
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
        // ¼Ò¸® Ã£¾Æ¿Í¾ß µÊ
        // Àüµî ÄÑÁö´Â ¼Ò¸®
        if (collision.gameObject.CompareTag("Lamp"))
        {
            BallSound(SoundManager.instance.lamp);
        }
        // Àüº¿´ë¿¡ ºÎµúÈ÷´Â µíÇÑ ¼Ò¸®.. ÅÖ? ÅÍ¾û?
        else if (collision.gameObject.CompareTag("PowerPole"))
        {
            Pole(SoundManager.instance.metal);
        }
        // Â÷¶û ºÎµúÈ÷´Â ¼Ò¸®
        else if (collision.gameObject.CompareTag("Car"))
        {
            Carsound(SoundManager.instance.bbang);
        }
        else if (collision.gameObject.CompareTag("f") || collision.gameObject.CompareTag("m"))
        {
            person(SoundManager.instance.personHit);
        }
        else if (collision.gameObject.CompareTag("parking") || collision.gameObject.CompareTag("h"))
        {
            parking(SoundManager.instance.parking);
        }
        else if (collision.gameObject.CompareTag("trash"))
        {
            trash(SoundManager.instance.trash);
        }

    }
    
}
