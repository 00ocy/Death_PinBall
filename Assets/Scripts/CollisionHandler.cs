using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� �±װ� "Ball"�̸鼭 ���� ������Ʈ�� �±װ� "street_lamp"�̸� ����
        if (collision.gameObject.tag == "Ball")
        {
            // "street_lamp 1" ������Ʈ�� ã��
            GameObject streetLampObject = this.gameObject;

            GameObject street_lamp = streetLampObject.transform.Find("street_lamp 1").gameObject;

            // "street_lamp 1" ������Ʈ�� �ڽ� ������Ʈ �� "light"�� ã��
            GameObject light = street_lamp.transform.Find("light").gameObject;
            
            if(light.activeSelf)
            {
                light.SetActive(false);
            }
            else
            {
                light.SetActive(true);
            }

        }
          
    }
}
