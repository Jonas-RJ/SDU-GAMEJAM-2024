using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public HealthController hc;


   [SerializeField] private float m_EnemySpeed;
    [SerializeField] private float m_ËnemyRotateSpeed;

    private Rigidbody2D m_rb;
    private EnemyAI m_enemyAI;
    private Vector2 m_TargetDirection;
    
    // Start is called before the first frame update
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_enemyAI = GetComponent<EnemyAI>();
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

        // checker via andet script om enemien har spottet playeren
        if (m_enemyAI._IsAware)
        {
            //sætter targetdir til at være playerens dir fra det andet script. 
            m_TargetDirection = m_enemyAI.c_PlayerDirection;
        }
        else
        {

            //ellers bliver enemien stående
            m_TargetDirection = Vector2.zero;
        }
    }

    private void RotateToTarget()
    {
        if(m_TargetDirection == Vector2.zero)
        {
            return;
        }
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, m_TargetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, m_ËnemyRotateSpeed * Time.deltaTime);

        m_rb.SetRotation(rotation); 

    }


    private void SetVelocity() 
    {
        if (m_TargetDirection == Vector2.zero)
        {
            m_rb.velocity = Vector2.zero;
        }
        else
        {
            m_rb.velocity = transform.up * m_EnemySpeed;
        }

    }


  
}
