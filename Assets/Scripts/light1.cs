using UnityEngine;

public class light1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� �±װ� "Ball"�̸鼭 ���� ������Ʈ�� �±װ� "street_lamp"�̸� ����
        if (collision.gameObject.tag == "Ball")
        {
            
            GameObject CarObject = this.gameObject;


            // "street_lamp 1" ������Ʈ�� �ڽ� ������Ʈ �� "light"�� ã��
            GameObject light = CarObject.transform.Find("light").gameObject;
            
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
