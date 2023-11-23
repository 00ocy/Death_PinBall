using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    // Start is called before the first frame update
   // public GameManager gm;

    int obj;
    private void Start()
    {
       // gm = GameObject.Find("GM").GetComponent<GameManager>();
    }
   /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {

            obj = this.gameObject.layer;
            switch (obj)
            {
                case 10:
                        gm.score += 100;
                        break;
                case 11:
                        gm.score += 50;
                        break;
                default: break;
            }
        }
    }*/

}