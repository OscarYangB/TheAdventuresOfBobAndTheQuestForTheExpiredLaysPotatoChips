using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public int health = 20;
    public float webSpeed;
    private Vector3 moveVertical;

    public GameObject bob;
    public GameObject web;
    public Animator face;

    private Bullet script;
    private AudioSource screech;
    private Vector3 spawnPoint = new Vector3(0, -12, 0);
    private Vector2 lookDirection;

    private void Awake()
    {
        bob = GameObject.Find("Bob");
        screech = GetComponent<AudioSource>();

        moveVertical = new Vector3(0, -1f, 0);
        StartCoroutine(spawn());
        StartCoroutine(attack());
    }

    private void Update()
    {
        if(health == 0)
        {
            StartCoroutine(death());
            health = -1;
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "bullet")
        {
            script = trig.GetComponent<Bullet>();
            health = health - script.damage;
            StartCoroutine(damage());
            screech.enabled = false;
            screech.enabled = true;
        }
    }


    IEnumerator damage()
    {
        face.SetBool("isHurt", true);
        yield return new WaitForSeconds(0.5f);
        face.SetBool("isHurt", false);
    }

    IEnumerator spawn()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.position = transform.position + moveVertical;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator attack()
    {
        while (health > 0) {
            if (transform.position.x - bob.transform.position.x < 20)
            {
                yield return new WaitForSeconds(1);
                lookDirection = bob.transform.position - (transform.position + spawnPoint);
                GameObject newWeb = Instantiate(web, transform.position + spawnPoint, Quaternion.identity);
                newWeb.GetComponent<Rigidbody2D>().velocity = lookDirection.normalized * webSpeed;
            } else
            {
                yield return new WaitForSeconds(1);
            }
        }
    }


    IEnumerator death()
    {
        for(int i = 0; i < 10; i++)
        {
            transform.position = transform.position - moveVertical;
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);
    }
}
