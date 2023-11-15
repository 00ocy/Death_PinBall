using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� �±װ� "Ball"�̸鼭 ���� ������Ʈ�� �±װ� "street_lamp"�̸� ����
        if (collision.gameObject.tag == "Ball" )
        {
            // "street_lamp 1" ������Ʈ�� ã��
            GameObject streetLampObject = GetComponent<GameObject>();

            if (streetLampObject != null)
            {
                // "street_lamp 1" ������Ʈ�� �ڽ� ������Ʈ �� "light"�� ã��
                Transform lightTransform = streetLampObject.transform.Find("light");

                if (lightTransform != null)
                {
                    // "light" ������Ʈ�� Ȱ��ȭ�� true�� ����
                    lightTransform.gameObject.SetActive(true);
                }
                else
                {
                    Debug.LogError("Could not find 'light' object under 'street_lamp 1'.");
                }
            }
            else
            {
                Debug.LogError("Could not find 'street_lamp 1' object.");
            }
        }
    }
}
