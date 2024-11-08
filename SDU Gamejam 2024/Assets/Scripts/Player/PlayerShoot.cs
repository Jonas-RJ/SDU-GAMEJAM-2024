using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] private GameObject s_BulletPrefab;
    [SerializeField] private float s_BulletSpeed;
    [SerializeField] private float s_TimeBtwnShots;
    
    private bool s_FireContinue;
    private float s_LastShot;
   [SerializeField] private Transform s_ShootingOffset;
   



    // Update is called once per frame
    void Update()
    {

        //hvis continuous fire er true, skyd. 
        if (s_FireContinue)
        {

            float timeSinceLastfire = Time.time - s_LastShot;


            if(timeSinceLastfire >= s_TimeBtwnShots)
            {
                FireBullet();

                s_LastShot = Time.time;
            }
            
        }
    }


    private void OnFire(InputValue inputValue)
    {
        // s� l�nge OnFire (space, LMB, right trigger, osv. er pressed, s�t firecontinue til true.
        s_FireContinue = inputValue.isPressed;
    }

    private void FireBullet()
    {
        //funktion / method der g�r at man skyder


        //instantiater/spawner bullets fra offsettet der er sat tidligere, og f�r fat p� rigidbodien.
        GameObject bullet = Instantiate(s_BulletPrefab, s_ShootingOffset.position, s_ShootingOffset.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();


        // s�tter hastigheden til at v�re bulletspeed x op for playeren. 
        rigidbody.velocity = s_BulletSpeed * transform.up;
    }


    


}
