using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   [SerializeField] private float b_BulletLifeTime;
    

    private void Awake()
    {
        StartCoroutine(bulletDestroyRoutine());

    }


    private void OnTriggerEnter2D(Collider2D Collision)
    {
        //Destroy(Collision.gameObject);
      //  Destroy(gameObject);

        /*
        if (Collision.GetComponent<>();)
        {


        }
      
    */
    }



    IEnumerator bulletDestroyRoutine()
    {
        print("Bullet shot");

        yield return new WaitForSeconds(b_BulletLifeTime);

        Destroy(gameObject);


    }
}
