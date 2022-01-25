using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public GameManager gm;
    public GameObject bulletPrefab;

    private Vector3 aim;

    private float playerInput;

    public float speed, jumpForce, boostForce, bulletForce;

    private bool left, right;

    private void Update()
    {
        playerInput = Input.GetAxis("Horizontal") * speed;

        if(playerInput < 0 && left == false)
        {
            transform.position += new Vector3(-0.7f, 0, 0);
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            left = true;
            right = false;
        }
        else if(playerInput > 0 && right == false)
        {
            transform.position += new Vector3(0.7f, 0, 0);
            transform.rotation = Quaternion.Euler(Vector3.zero);
            right = true;
            left = false;
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (!gm.paused)
            {
                Vector3 shootDirection;
                shootDirection = Input.mousePosition;
                shootDirection.z = 0f;
                shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
                shootDirection = shootDirection - transform.position;

                GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(Vector3.zero));
                bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * bulletForce, shootDirection.y * bulletForce);
                gm.bullets++;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb2d.velocity;
        velocity.x = playerInput;
        rb2d.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D col2d)
    {
        if(col2d.gameObject.tag == "Plattform")
        {
            if (col2d.relativeVelocity.y >= 0f)
            {
                Vector2 velocity = rb2d.velocity;
                velocity.y = jumpForce;
                rb2d.velocity = velocity;
            }
        }

        if(col2d.gameObject.tag == "teleporter")
        {
            if(transform.position.x < 0)
            {
                transform.position = new Vector3(-transform.position.x - 1, transform.position.y, 0f);
            }
            else if(transform.position.x > 0)
            {
                transform.position = new Vector3(-transform.position.x + 1, transform.position.y, 0f);
            }
        }
        if(col2d.gameObject.tag == "Enemy")
        {
            gm.EndGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lower")
        {
            gm.EndGame();
        }
        if(collision.gameObject.tag == "pickUp")
        {
            Vector2 velocity = rb2d.velocity;
            velocity.y = boostForce;
            rb2d.velocity = velocity;
            gm.pickUps++;
        }
    }
}
