using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] private float speed = 10f;

    [Range(1, 10)]
    [SerializeField] private float lifeTime = 3f;

    public HealthController hc;
    private Rigidbody2D rb;

    public bool damageCounter;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
        damageCounter = false;
    }


    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
        print (damageCounter);
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.CompareTag("Player"))
        {
            hc = Collision.GetComponent<HealthController>();
            hc.takeDamage(2);
            damageCounter = true;
            print(damageCounter);
            Invoke("destroyBullet", 0.01f);        
        }
    }

    private void destroyBullet()
    {
        Destroy(gameObject);
    }

}
