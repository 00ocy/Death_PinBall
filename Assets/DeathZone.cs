using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathZone : MonoBehaviour
{
    public GameManager gm;

    void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            if (gm.life > 0) gm.life -= 1;
            else
            {
                gm.life = 0;
            }
        }
    }
    
}
