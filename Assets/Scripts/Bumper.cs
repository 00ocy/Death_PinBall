using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour
{

    public float force = 100.0f;
    public float forceRadius = 1.0f;

    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ��ü�� ��ġ�� �������� ���� ��ü ������ �ִ� Collider���� ������
        foreach (Collider col in Physics.OverlapSphere(collision.contacts[0].point, forceRadius))
        {
            // ������ Collider�� Rigidbody�� ������ �ִٸ�
            if (col.GetComponent<Rigidbody>())
            {
                // �ش� Rigidbody�� �������� ���� �߰���
                col.GetComponent<Rigidbody>().AddExplosionForce(force, collision.contacts[0].point, forceRadius);
            }
        }
    }

}
