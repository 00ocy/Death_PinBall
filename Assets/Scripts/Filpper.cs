using UnityEngine;
using System.Collections;

public class Filpper : MonoBehaviour {
    
	// 플립퍼 사운드
    public AudioSource Flipper_Source;

    public float force = 100.0f;
	public Vector3 forceDirection = Vector3.forward;
	public string buttonName = "Fire1";
	public Vector3 offset;
    private void Start()
    {
        Flipper_Source = GetComponent<AudioSource>();
    }

	void ddalggak_Sound(AudioClip clip)
	{
		Flipper_Source.clip = clip;
		Flipper_Source.Play();
	}

    private void Update()
    {    
		if(Input.GetButtonDown(buttonName))
		{ 
			ddalggak_Sound(SoundManager.instance.flipperUpSound);
		}
		if(Input.GetButtonUp(buttonName))
		{
            ddalggak_Sound(SoundManager.instance.flipperDownSound);
        }
    }

    void FixedUpdate ()
	{
		if(Input.GetButton(buttonName))
		{
			GetComponent<Rigidbody>().AddForceAtPosition(forceDirection.normalized*force,transform.position+offset);
		}
		else
		{
            GetComponent<Rigidbody>().AddForceAtPosition(forceDirection.normalized*-force,transform.position+offset);
		}
	}
}
