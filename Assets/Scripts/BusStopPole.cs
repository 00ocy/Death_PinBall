using System.Collections;
using UnityEngine;

public class BusStopPole : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;
    private GameObject[] poles;

    public GameManager gm;
    void Start()
    {
        // MeshRenderer와 MeshCollider 컴포넌트를 가져옴
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();

        // Scene에서 모든 "pole" 태그를 가진 GameObject들을 찾아 배열에 저장
        poles = GameObject.FindGameObjectsWithTag("BusStopPole");
        gm = GameObject.Find("GM").GetComponent<GameManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // MeshRenderer와 MeshCollider를 비활성화
            meshRenderer.enabled = false;
            meshCollider.enabled = false;

            gm.score += 150;
            // 모든 "pole"이 비활성화 상태인지 체크
            if (AllPolesInactive())
            {
                gm.score += 500;
                // 1.5초 후에 모든 "pole"을 활성화하는 코루틴 시작
                StartCoroutine(ActivateAllPolesAfterDelay(1.5f));
            }
        }
    }

    IEnumerator ActivateAllPolesAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        // 모든 "pole"을 찾아서 체크
        foreach (GameObject pole in poles)
        {
            // MeshRenderer와 MeshCollider를 활성화
            pole.GetComponent<MeshRenderer>().enabled = true;
            pole.GetComponent<MeshCollider>().enabled = true;
        }
    }

    bool AllPolesInactive()
    {
        // 모든 pole들이 비활성화되었는지 확인
        foreach (GameObject pole in poles)
        {
            if (pole.GetComponent<MeshRenderer>().enabled || pole.GetComponent<MeshCollider>().enabled)
            {
                // 하나라도 활성화된 pole이 있다면 false 반환
                return false;
            }
        }

        // 모든 pole들이 비활성화되었다면 true 반환
        return true;
    }
}
