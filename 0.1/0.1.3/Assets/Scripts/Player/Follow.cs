using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾��� ��ġ�� ������ Transform ����

    void Update()
    {
        // ������Ʈ�� ��ġ�� �÷��̾��� ��ġ�� ������Ʈ
        transform.position = playerTransform.position;
    }
}
