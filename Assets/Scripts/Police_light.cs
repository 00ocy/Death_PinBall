using System.Collections;
using UnityEngine;

public class Policelight : MonoBehaviour
{
    public GameObject redLight; // ������ ����Ʈ
    public GameObject blueLight; // �Ķ��� ����Ʈ

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


        // "street_lamp 1" ������Ʈ�� �ڽ� ������Ʈ �� "light"�� ã��
        blueLight = CarObject.transform.Find("light1").gameObject;
        redLight = CarObject.transform.Find("light2").gameObject;

        SirenSound(SoundManager.instance.siren);
    }

    private IEnumerator BlinkLights()
    {
        isBlinking = true;

        // 3�� ���� �����ư��� ���� �Ķ����� ����Ʈ ����
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

        // 3�� �Ŀ� ����Ʈ�� ��� ��
        redLight.SetActive(false);
        blueLight.SetActive(false);

        isBlinking = false;
    }
}
