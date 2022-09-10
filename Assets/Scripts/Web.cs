using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : MonoBehaviour
{

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }



    private void OnCollisionEnter2D(Collision2D trig)
    {
        if(trig.gameObject.name == "Bob")
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }
}
