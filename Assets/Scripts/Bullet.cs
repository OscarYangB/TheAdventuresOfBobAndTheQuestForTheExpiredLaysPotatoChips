using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject spider;

    private GameObject bob;
    private Movement script2;

    private Animator anim;

    public int damage;

    private void Awake()
    {
        spider = GameObject.Find("spider");

        bob = GameObject.Find("Bob");
        script2 = bob.GetComponent<Movement>();

        anim = GetComponent<Animator>();


        switch(script2.hunger)
        {
            case 1:
            case 2:
                damage = 1;
                break;
            case 3:
            case 4:
                damage = 2;
                anim.SetBool("salt", true);
                break;
            case 5:
            case 6:
                anim.SetBool("salt", true);
                anim.SetBool("ketchup", true);
                damage = 3;
                break;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }



}
