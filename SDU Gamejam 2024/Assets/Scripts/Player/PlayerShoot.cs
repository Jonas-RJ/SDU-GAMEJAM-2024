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
        // så længe OnFire (space, LMB, right trigger, osv. er pressed, sæt firecontinue til true.
        s_FireContinue = inputValue.isPressed;
    }

    private void FireBullet()
    {
        //funktion / method der gør at man skyder


        //instantiater/spawner bullets fra offsettet der er sat tidligere, og får fat på rigidbodien.
        GameObject bullet = Instantiate(s_BulletPrefab, s_ShootingOffset.position, s_ShootingOffset.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();


        // sætter hastigheden til at være bulletspeed x op for playeren. 
        rigidbody.velocity = s_BulletSpeed * transform.up;
    }


    


}
