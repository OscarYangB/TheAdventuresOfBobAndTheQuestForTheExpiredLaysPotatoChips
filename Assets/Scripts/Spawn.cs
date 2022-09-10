using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Spider;
    public AudioSource screech;
    public BoxCollider2D box;

    public int danger;

    private void Awake()
    {
        screech = GetComponent<AudioSource>();
        box = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.name == "Bob")
        {
            switch (danger)
            {
                case 1:
                    GameObject enemy = Instantiate(Spider, transform.position + new Vector3 (5, 10, 0), Quaternion.identity);
                    break;
                case 2:
                    GameObject enemy2 = Instantiate(Spider, transform.position + new Vector3(-10, 10, 0), Quaternion.identity);
                    GameObject enemy3 = Instantiate(Spider, transform.position + new Vector3(5, 10, 0), Quaternion.identity);
                    break;
                case 3:
                    GameObject enemy4 = Instantiate(Spider, transform.position + new Vector3(-17, 10, 0), Quaternion.identity);
                    GameObject enemy5 = Instantiate(Spider, transform.position + new Vector3(-10, 10, 0), Quaternion.identity);
                    GameObject enemy6 = Instantiate(Spider, transform.position + new Vector3(5, 10, 0), Quaternion.identity);
                    GameObject enemy7 = Instantiate(Spider, transform.position + new Vector3(12, 10, 0), Quaternion.identity);
                    break;
            }
            screech.enabled = false;
            screech.enabled = true;
            box.enabled = false;
            
        }
    }




}
