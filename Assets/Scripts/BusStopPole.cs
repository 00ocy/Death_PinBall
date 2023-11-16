using System.Collections;
using UnityEngine;

public class BusStopPole : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;
    private GameObject[] poles;

    void Start()
    {
        // MeshRenderer�� MeshCollider ������Ʈ�� ������
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();

        // Scene���� ��� "pole" �±׸� ���� GameObject���� ã�� �迭�� ����
        poles = GameObject.FindGameObjectsWithTag("BusStopPole");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameManager GM = GameManager.instance;
            // MeshRenderer�� MeshCollider�� ��Ȱ��ȭ
            meshRenderer.enabled = false;
            meshCollider.enabled = false;

            GM.score += 150;
            // ��� "pole"�� ��Ȱ��ȭ �������� üũ
            if (AllPolesInactive())
            {
                GM.score += 500;
                // 1.5�� �Ŀ� ��� "pole"�� Ȱ��ȭ�ϴ� �ڷ�ƾ ����
                StartCoroutine(ActivateAllPolesAfterDelay(1.5f));
            }
        }
    }

    IEnumerator ActivateAllPolesAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        // ��� "pole"�� ã�Ƽ� üũ
        foreach (GameObject pole in poles)
        {
            // MeshRenderer�� MeshCollider�� Ȱ��ȭ
            pole.GetComponent<MeshRenderer>().enabled = true;
            pole.GetComponent<MeshCollider>().enabled = true;
        }
    }

    bool AllPolesInactive()
    {
        // ��� pole���� ��Ȱ��ȭ�Ǿ����� Ȯ��
        foreach (GameObject pole in poles)
        {
            if (pole.GetComponent<MeshRenderer>().enabled || pole.GetComponent<MeshCollider>().enabled)
            {
                // �ϳ��� Ȱ��ȭ�� pole�� �ִٸ� false ��ȯ
                return false;
            }
        }

        // ��� pole���� ��Ȱ��ȭ�Ǿ��ٸ� true ��ȯ
        return true;
    }
}
