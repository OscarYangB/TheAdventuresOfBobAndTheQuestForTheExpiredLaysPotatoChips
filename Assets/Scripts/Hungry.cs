using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hungry : MonoBehaviour
{
    public Movement script;
    public int point;

    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(script.hunger == point)
        {
            anim.SetInteger("hunger", script.hunger);
        }
    }
}
