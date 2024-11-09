using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public HealthController hc;
    [SerializeField] private float takeDamageCD;
    //nedenstående bool er tilgængelig til andre scripts, men kan kun sættes / defineres heri. 
    public bool _IsAware  { get; private set; }
    public Vector2 c_PlayerDirection {  get; private set; }

    [SerializeField] private float c_PlayerAwareDist;

    private Transform c_Player;


    // Start is called before the first frame update
    private void Awake()
    {
        c_Player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = c_Player.position - transform.position;
        c_PlayerDirection = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= c_PlayerAwareDist)
        {
            _IsAware = true;
        }
        else
        {
            _IsAware = false;
        }


    }



    void OnTriggerEnter2D(Collider2D col)
    {
        takeDamageCD -= Time.deltaTime;

        if (col.CompareTag("Player"))
        {
            if(takeDamageCD <= 0) { 
            hc.takeDamage(1);
            print("EnemyCol");
                takeDamageCD = 0.5f;
            }
        }
    }
}
