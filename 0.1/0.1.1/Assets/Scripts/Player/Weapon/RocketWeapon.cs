using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] rocketPrefabs;

    Animator anim;

    bool isDelay;
    public float coolingTime = 25.0f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isDelay == false)
            {
                isDelay = true;
                anim.SetTrigger("Fire");

                StartCoroutine(FireRocketCoroutine());


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

    IEnumerator FireRocketCoroutine()
    {
        for(int i = 0; i < rocketPrefabs.Length; i++)
        {
            yield return new WaitForSeconds(0.15f);
            FireRocket(i);
        }
    }

    void FireRocket(int i)
    {
        GameObject rocketBullet = Instantiate(rocketPrefabs[i], transform);

        Rigidbody2D rigid = rocketBullet.GetComponent<Rigidbody2D>();

        rigid.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
    }

}
