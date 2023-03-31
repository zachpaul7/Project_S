using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketWeapon : MonoBehaviour
{
    [SerializeField] GameObject rocketPrefabs;

    Animator anim;

    bool isDelay;
    public float coolingTime = 25.0f;

    bool isReload = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
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
                Debug.Log("������");
            }
        }
    }
    private void FixedUpdate()
    {
        anim.SetBool("Reload", isReload);
    }
    IEnumerator CoolTime()
    {
        isReload = true;

        yield return new WaitForSeconds(coolingTime);
        isReload = false;

        isDelay = false;
    }

    IEnumerator FireRocketCoroutine()
    {
        for(int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.16f);
            FireRocket(i);
        }
    }

    void FireRocket(int i)
    {
        Vector3 rocketPosition = transform.position;

        if (i == 0)
        {
            rocketPosition += Vector3.left * 0.17f + Vector3.up * 0.25f;
        }

        else if (i == 1)
        {
            rocketPosition += Vector3.right * 0.2f + Vector3.up * 0.25f;
        }

        else if (i == 2)
        {
            rocketPosition += Vector3.left * 0.28f + Vector3.up * 0.17f;
        }

        else if (i == 3)
        {
            rocketPosition += Vector3.right * 0.31f + Vector3.up * 0.17f;
        }

        else if (i == 4)
        {
            rocketPosition += Vector3.left * 0.39f + Vector3.up * 0.1f;
        }

        else if (i == 5)
        {
            rocketPosition += Vector3.right * 0.41f + Vector3.up * 0.1f;
        }

        GameObject rocketBullet = Instantiate(rocketPrefabs, rocketPosition, Quaternion.identity, transform);

        Rigidbody2D rigid = rocketBullet.GetComponent<Rigidbody2D>();

        rigid.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
    }

}
