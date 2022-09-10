using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomHeight : MonoBehaviour
{
    // private SpriteRenderer tint;
    private Animator anim;
    private Movement script;
    public GameObject bob;
    public GameObject pillar;

    void Awake()
    {
        Vector3 moveHorizontal = new Vector3(12, 0, 0);
        if (transform.position.x < 240)
        {
            GameObject newPillar = Instantiate(pillar, transform.position + moveHorizontal, transform.rotation);
        }

        Vector3 moveVertical = new Vector3(0, Random.Range(-7, 0), 0);
        transform.position = transform.position + moveVertical;
    }

    void Start()
    {
        bob = GameObject.Find("Bob");
        anim = GetComponent<Animator>();
        script = bob.GetComponent<Movement>();

        // tint = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {

        anim.SetInteger("hunger", script.hunger);    
    }

    // void FixedUpdate()
    // {

    //     Color randColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    //     tint.color = randColor;


    // }


}
