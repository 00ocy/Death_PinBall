using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Run : MonoBehaviour
{
    // �̵� �ӵ��� �����ϴ� ����
    public float moveSpeed = 5f;

    void Update()
    {
        // ������Ʈ�� y������ �̵�
        MoveObject();
    }

    void MoveObject()
    {
        // ���� ��ġ�� ����
        Vector3 currentPosition = transform.position;

        // y�� �������� �̵�
        currentPosition.x += moveSpeed * Time.deltaTime;

        // ���ο� ��ġ�� ����
        transform.position = currentPosition;
    }
}
