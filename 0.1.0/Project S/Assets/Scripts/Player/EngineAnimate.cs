using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineAnimate : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetInteger("Input", (int)GameManager.instance.playerMove.inputVec.magnitude);
    }
}
