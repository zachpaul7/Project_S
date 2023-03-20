using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class AutoCanonWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 0.3f; // �߻� �ֱ�

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(FireCoroutine());
    }

    private IEnumerator FireCoroutine()
    {
        while (true)
        {
            Fire();
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void Fire()
    {
        if (!Input.GetButton("Fire1"))
        {
            return;
        }

        anim.SetTrigger("Fire");
        Invoke("FireCanon", 0.1f);
    }

    private void FireCanon()
    {
        Vector3 position = GameManager.instance.playerMove.transform.position;
        Quaternion rotation = GameManager.instance.playerMove.transform.rotation;

        GameObject bulletR = Instantiate(bulletPrefab, position + Vector3.right * 0.32f + Vector3.up * 0.25f, rotation, transform);
        GameObject bulletL = Instantiate(bulletPrefab, position + Vector3.left * 0.32f + Vector3.up * 0.25f, rotation, transform);

        Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();

        rigidR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        rigidL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }
}

