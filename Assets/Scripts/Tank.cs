using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Tank : MonoBehaviour
{

    [SerializeField] private bool WASD;

    [Header("Танк")]

    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    [Header("Оружие")]

    [SerializeField] float reloadTime;
    [SerializeField] Transform bulletPoint;
    [SerializeField] Bullet bullet;

    Rigidbody2D rb;
    Animator anim;
    AudioSource ass;

    float shotTime = Mathf.Infinity;
    bool canShot = false;
    

    void Shoot(KeyCode shotKey)
    {
        if (Input.GetKey(shotKey) && canShot == true)
        {
            ass.Play();

            canShot = false;
            Bullet bullShot = Instantiate(bullet, bulletPoint.position, Quaternion.identity);
            bullShot.gameObject.transform.Rotate(transform.rotation.eulerAngles, Space.World);
            bullShot.SetDirection(bulletPoint.right);

            anim.SetTrigger("isFire");
            anim.SetTrigger("isNotFire");


        }
    }


    void CanShot()
    {
        if (canShot == true)
        {
            return;
        }

        shotTime = shotTime + Time.deltaTime;

        if (shotTime > reloadTime)
        {
            shotTime = 0;
            canShot = true;
        }
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        anim = gameObject.GetComponentInChildren<Animator>();
        ass = gameObject.GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if (WASD)
        {
            CanShot();
            Shoot(KeyCode.E);

            Move(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D);
        }
        else
        {

            CanShot();
            Shoot(KeyCode.RightShift);


            Move(KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow);
        }
    }

    private void Move(KeyCode forward, KeyCode back, KeyCode left, KeyCode right)
    {
        float v = 0;
        if (Input.GetKey(forward) || Input.GetKey(back))
        {
            if (Input.GetKey(forward))
            {
                v = 1f;
            }
            else
            {
                v = -1f;
            }
            rb.AddForce(transform.right * speed * v, ForceMode2D.Impulse);
        }


        float h = 0;
        if (Input.GetKey(left) || Input.GetKey(right))
        {
            if (Input.GetKey(left))
            {
                h = 1f;
            }
            else
            {
                h = -1f;
            }

            rb.AddTorque(rotationSpeed * h, ForceMode2D.Impulse);
        }
    }
}

