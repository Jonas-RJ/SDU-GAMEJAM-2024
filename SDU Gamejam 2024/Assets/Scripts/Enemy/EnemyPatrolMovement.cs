using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolMovement : MonoBehaviour
{

    [SerializeField] private float p_EnemySpeed;
    [SerializeField] private float p_ËnemyRotateSpeed;
    [SerializeField] private float p_DirChangeCD;

    private Rigidbody2D p_rb;
    private EnemyAI p_enemyAI;
    private Vector2 p_TargetDirection;

    // Start is called before the first frame update
    private void Awake()
    {
        p_rb = GetComponent<Rigidbody2D>();
        p_enemyAI = GetComponent<EnemyAI>();
        p_TargetDirection = transform.up;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateToTarget();
        SetVelocity();
    }


    private void UpdateTargetDirection()
    {
        RandomDirChange();
        playerTargeting();
        // checker via andet script om enemien har spottet playeren
      
    }

    private void RotateToTarget()
    {
       
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, p_TargetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, p_ËnemyRotateSpeed * Time.deltaTime);

        p_rb.SetRotation(rotation);

    }


    private void SetVelocity()
    {
       
            p_rb.velocity = transform.up * p_EnemySpeed;
        

    }

    private void RandomDirChange()
    {
        p_DirChangeCD -= Time.deltaTime;
        if(p_DirChangeCD <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            p_TargetDirection = rotation * p_TargetDirection;


            p_DirChangeCD = Random.Range(1f, 5f);

        }
    }

    private void playerTargeting()
    {
        if (p_enemyAI._IsAware)
        {
            //sætter targetdir til at være playerens dir fra det andet script. 
            p_TargetDirection = p_enemyAI.c_PlayerDirection;
        }
    }
}




