using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : MonoBehaviour
{
    [SerializeField] GameObject LaserPrefab;

    [SerializeField] GameObject EndLaserSet;

    bool isDelay;
    float accumTime;

    public float coolingTime = 25.0f;
    public float shootingTime = 2.0f;

    Animator anim;

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

                StartCoroutine(SpawnLaserDelayed(0.5f));

                StartCoroutine(ShootingLaserDelayed());

                if (isDelay)
                {
                    StartCoroutine(CoolTime());
                }
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

    IEnumerator SpawnLaserDelayed(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SpawnLaser(true);
    }

    IEnumerator ShootingLaserDelayed()
    {
        yield return new WaitForSeconds(shootingTime);
        SpawnLaser(false);
        EndLaser(true);
        yield return new WaitForSeconds(0.1f);
        EndLaser(false);
    }

    void SpawnLaser(bool isActive)
    {
        if (isActive)
        {
            LaserPrefab.SetActive(true);
        }
        else
        {
            LaserPrefab.SetActive(false);
        }
    }

    void EndLaser(bool isActive)
    {
        if (isActive)
        {
            EndLaserSet.SetActive(true);
        }
        else
        {
            EndLaserSet.SetActive(false);
        }
    }
}
