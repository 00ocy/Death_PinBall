using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 태그가 "Ball"이면서 현재 오브젝트의 태그가 "street_lamp"이면 실행
        if (collision.gameObject.tag == "Ball" )
        {
            // "street_lamp 1" 오브젝트를 찾음
            GameObject streetLampObject = GetComponent<GameObject>();

            if (streetLampObject != null)
            {
                // "street_lamp 1" 오브젝트의 자식 오브젝트 중 "light"를 찾음
                Transform lightTransform = streetLampObject.transform.Find("light");

                if (lightTransform != null)
                {
                    // "light" 오브젝트의 활성화를 true로 설정
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
