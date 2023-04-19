using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LaserBullet : MonoBehaviour
{
    public int damage = 0; // ���ݷ�

    private Enemy currentEnemy; // ���� ���� �����ϴ� ����

    [SerializeField] float atkTime;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                currentEnemy = enemy; // ���� ���� ���� ������ ����
                InvokeRepeating("DamageEnemy", 0f, atkTime); // 0�� �ĺ��� 0.5�ʸ��� DamageEnemy() �Լ��� ȣ���մϴ�.
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            CancelInvoke("DamageEnemy"); // �浹�� ���� ���, InvokeRepeating() �Լ��� ����մϴ�.
            currentEnemy = null; // ���� ���� �����ϴ� ������ �ʱ�ȭ�մϴ�.
        }
    }

    void DamageEnemy()
    {
        if (currentEnemy != null)
        {
            Debug.Log(damage);
            currentEnemy.TakeDamage(damage);
        }
    }

}
