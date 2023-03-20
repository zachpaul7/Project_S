using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[Serializable]
public class EnemyStats
{
    public int hp = 999;
    public int dmg = 1;
    public float moveSpeed = 1f;
    private EnemyStats stats;

    public EnemyStats(EnemyStats stats)
    {
        this.hp = stats.hp;
        this.dmg = stats.dmg;
        this.moveSpeed = stats.moveSpeed;
    }
}

public class Enemy : MonoBehaviour
{
    public EnemyStats stats;

    SpriteRenderer spriter;
    Rigidbody2D rgb2d;
    Collider2D coll;
    Animator animator;

    void Awake()
    {
        coll = GetComponent<Collider2D>();
        rgb2d = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        stats = new EnemyStats(null);
        SetStats(stats);
    }

    public void TakeDamage(int dmg)
    {
        stats.hp -= dmg;

        if (stats.hp > 0)
        {
            StartCoroutine("HitEffect");
            Debug.Log(stats.hp);
        }
        else
        {
            coll.enabled = false;
            rgb2d.simulated = false;
            spriter.sortingOrder = 1;
            animator.SetBool("Dead", true);
        }
    }

    public void SetStats(EnemyStats stats)
    {
        this.stats = new EnemyStats(stats);
    }

    IEnumerator HitEffect()
    {
        spriter.color = new Color32(255, 255, 255, 160);
        yield return new WaitForSeconds(0.1f);
        spriter.color = new Color32(255, 255, 255, 255);
        yield return null;
    }
}
