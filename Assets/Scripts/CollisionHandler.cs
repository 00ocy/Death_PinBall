using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 태그가 "Ball"이면서 현재 오브젝트의 태그가 "street_lamp"이면 실행
        if (collision.gameObject.tag == "Ball")
        {
            // "street_lamp 1" 오브젝트를 찾음
            GameObject streetLampObject = this.gameObject;

            GameObject street_lamp = streetLampObject.transform.Find("street_lamp 1").gameObject;

            // "street_lamp 1" 오브젝트의 자식 오브젝트 중 "light"를 찾음
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
