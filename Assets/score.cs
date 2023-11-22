using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    int obj;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            obj = collision.gameObject.layer;
            switch(obj)
            {
                case 10:
                        GameManager.instance.score += 100;;
                        break;
                case 11:
                        GameManager.instance.score += 50;
                        break;
                default: break;
            }
        }
    }
}
