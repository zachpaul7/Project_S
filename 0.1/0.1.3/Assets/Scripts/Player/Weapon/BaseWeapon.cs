using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 0.3f; // 발사 주기

    private void Start()
    {
        StartCoroutine(FireCoroutine());
    }

    IEnumerator FireCoroutine()
    {
        while (true)
        {
            Fire();
            yield return new WaitForSeconds(fireRate);
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab,
            GameManager.instance.playerMove.transform.position,
            GameManager.instance.playerMove.transform.rotation,transform);

        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }

}
