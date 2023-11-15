using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour
{

    public float force = 100.0f;
    public float forceRadius = 1.0f;

    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 물체의 위치를 기준으로 현재 물체 주위에 있는 Collider들을 가져옴
        foreach (Collider col in Physics.OverlapSphere(collision.contacts[0].point, forceRadius))
        {
            // 가져온 Collider가 Rigidbody를 가지고 있다면
            if (col.GetComponent<Rigidbody>())
            {
                // 해당 Rigidbody에 폭발적인 힘을 추가함
                col.GetComponent<Rigidbody>().AddExplosionForce(force, collision.contacts[0].point, forceRadius);
            }
        }
    }

}
