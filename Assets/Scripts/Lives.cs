using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
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
        if (script.life < point)
        {
            Destroy(gameObject);
        }

        if(Input.GetButtonDown("Fire1"))
        {
            anim.SetInteger("fire", 1);

        }
        else
        {
            anim.SetInteger("fire", 0);
        }
    }
}
