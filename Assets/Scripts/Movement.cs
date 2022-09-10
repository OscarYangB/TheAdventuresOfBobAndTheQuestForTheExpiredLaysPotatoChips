using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    // Public Variables
    public float speed;
    public float jumpPower;
    public float bulletSpeed;
    public int hunger = 0;
    public int life;

    // Game Objects
    public GameObject pillar;
    public GameObject cam;
    public GameObject chip;

    // Components
    private AudioSource sound;
    private Rigidbody2D physics;
    private CircleCollider2D collision;
    private Animator anim;
    private Camera lens;

    // Layeer Masks
    public LayerMask pillarMask;

    // Private Variables
    private Vector3 startPosition;
    private Vector2 movement;

    private Vector2 lookDirection;
    private Quaternion angle;
    private float lookAngle;

    private void Start()
    {
        // Getting Components
        sound = GetComponent<AudioSource>();
        physics = GetComponent<Rigidbody2D>();
        collision = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        lens = cam.GetComponent<Camera>();

        // Starting Position
        startPosition = new Vector3(-0.07f, pillar.transform.position.y + 7.5f, 0f);
        transform.position = startPosition;
    }

    // Ground Check
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(collision.bounds.center, Vector2.down, 2f, pillarMask);
        Debug.DrawRay(collision.bounds.center, Vector2.down * 2, Color.red);
        return raycastHit.collider != null;
    }

    private void Update()
    {
        // Firing
        if(Input.GetButtonDown("Fire1"))
        {
            anim.SetInteger("fire", 1);

        } else
        {
            anim.SetInteger("fire", 0);
        }

        if(Input.GetButtonDown("Fire1") && hunger>=1)
        {
            lookDirection = (lens.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            GameObject chipsAhoy = Instantiate(chip, transform.position, Quaternion.identity);
            chipsAhoy.GetComponent<Rigidbody2D>().velocity = lookDirection.normalized*bulletSpeed;
        }

        // Jumping
        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            physics.AddForce(Vector2.up * jumpPower);
        }

        // Moving
        movement = new Vector2(Input.GetAxis("Horizontal"), 0);
        physics.AddForce(movement*speed*Time.deltaTime);

        // Dying
        if (transform.position.y < -10 || transform.position.y > 20 || transform.position.x < -10)
        {
            physics.velocity = Vector3.zero;
            transform.position = startPosition;
            life--;
        }

        if (life == 0)
        {
            SceneManager.LoadScene("Menu");
        }

        if(transform.position.x > 245 && hunger == 6)
        {
            SceneManager.LoadScene("End");
        }

    }

}

    



