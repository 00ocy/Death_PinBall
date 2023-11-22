using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Run : MonoBehaviour
{
    // 이동 속도를 조절하는 변수
    public float moveSpeed = 5f;

    void Update()
    {
        // 오브젝트를 y축으로 이동
        MoveObject();
    }

    void MoveObject()
    {
        // 현재 위치를 저장
        Vector3 currentPosition = transform.position;

        // y축 방향으로 이동
        currentPosition.x += moveSpeed * Time.deltaTime;

        // 새로운 위치를 적용
        transform.position = currentPosition;
    }
}
