using System.Collections;
using UnityEngine;

public class Policelight : MonoBehaviour
{
    public GameObject redLight; // 빨강색 라이트
    public GameObject blueLight; // 파랑색 라이트

    public AudioSource Siren_Source;

    private bool isBlinking = false;

    void SirenSound(AudioClip ac)
    {
        Siren_Source.clip = ac;
        Siren_Source.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball" && !isBlinking)
        {
            StartCoroutine(BlinkLights());
        }

        GameObject CarObject = this.gameObject;


        // "street_lamp 1" 오브젝트의 자식 오브젝트 중 "light"를 찾음
        blueLight = CarObject.transform.Find("light1").gameObject;
        redLight = CarObject.transform.Find("light2").gameObject;

        SirenSound(SoundManager.instance.siren);
    }

    private IEnumerator BlinkLights()
    {
        isBlinking = true;

        // 3초 동안 번갈아가며 빨강 파랑으로 라이트 변경
        float elapsedTime = 0f;
        float blinkDuration = 1.5f;

        while (elapsedTime < blinkDuration)
        {
            blueLight.SetActive(true);
            redLight.SetActive(false);
            yield return new WaitForSeconds(0.15f);

            redLight.SetActive(true);
            blueLight.SetActive(false);
            yield return new WaitForSeconds(0.15f);

            elapsedTime += 0.3f;
        }

        // 3초 후에 라이트를 모두 끔
        redLight.SetActive(false);
        blueLight.SetActive(false);

        isBlinking = false;
    }
}
