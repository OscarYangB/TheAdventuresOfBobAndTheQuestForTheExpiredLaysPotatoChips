using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Chips : MonoBehaviour
{
    // Components
    private Animator anim;

    private AudioSource sound;
    private AudioSource sound2;

    private Movement script;

    private SpriteRenderer picture;
    private BoxCollider2D collision;

    // Game Objects
    public GameObject bob;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
        sound2 = bob.GetComponent<AudioSource>();
        script = bob.GetComponent<Movement>();
        picture = GetComponent<SpriteRenderer>();
        collision = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        switch(script.hunger)
        {
            case 2:
            case 3:
                anim.SetBool("salt", true);
                break;
            case 4:
            case 5:
            case 6:
                anim.SetBool("ketchup", true);
                break;
        }
    }


   private void OnTriggerEnter2D(Collider2D trig)
    {
        sound.enabled = false;
        sound.enabled = true;

        script.hunger++;

        StartCoroutine(pitchShift());

        picture.enabled = false;
        collision.enabled = false;
        
    }


    IEnumerator pitchShift()
    {
        for (int i = 0; i < 100; i++)
        {
            sound2.pitch = sound2.pitch + 0.001f;
            yield return new WaitForSeconds(0.001f);
        }
    }


}
