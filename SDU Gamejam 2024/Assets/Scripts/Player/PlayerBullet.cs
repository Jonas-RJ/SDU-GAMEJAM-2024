using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
   

    [Range(1, 10)]
    [SerializeField] private float lifeTime = 3f;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D Collision)
    {
     //   Invoke("destroyBullet", 0.01f);

        if (Collision.CompareTag("Enemy"))
        {
            print("hi");
            Collision.gameObject.SetActive(false);
        }
    }

    private void destroyBullet()
    {
        Destroy(gameObject);
    }


}
