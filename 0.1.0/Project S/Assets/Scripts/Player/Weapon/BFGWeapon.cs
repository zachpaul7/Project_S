using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFGWeapon : MonoBehaviour
{
    public GameObject objBFG;
    public GameObject bulletPrefab;

    bool isDelay;
    public float coolingTime = 25.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isDelay == false)
            {
                isDelay = true;

                objBFG.SetActive(true);

                StartCoroutine(FireBFGCoroutine());

                StartCoroutine(CoolTime());
            }
            else
            {
                Debug.Log("√Ê¿¸¡ﬂ");
            }
        }
    }

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(coolingTime);
        isDelay = false;
    }

    IEnumerator FireBFGCoroutine()
    {
        yield return new WaitForSeconds(0.6f);
        FireBFG();

        yield return new WaitForSeconds(1.1f);
        objBFG.SetActive(false);
    }

    void FireBFG()
    {
        GameObject BFGBullet = Instantiate(bulletPrefab, transform);

        Rigidbody2D rigid = BFGBullet.GetComponent<Rigidbody2D>();

        rigid.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
    }
}
