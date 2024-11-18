using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float damage;
    Rigidbody2D rb;
    Animator anim;

    public void SetDirection(Vector3 direction)
    {
        rb =  GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.velocity = direction.normalized * speed;
    }

    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("brick3") || collision.name.StartsWith("Tank"))
        {
            HPObject hp = collision.GetComponent<HPObject>();

            if (hp != null)
            {
                hp.ChangeHp(damage);
            }           
        }

        anim.SetTrigger("isCollision");
        rb.velocity = new Vector3(0, 0, 0);

        Destroy(gameObject, 0.5f);
    }


}
