using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public HealthController hc;
    [SerializeField] private int meleeDamage;
    [SerializeField] private int rangedDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public void takeMeleeDmg() 
    {
        hc.takeDamage(1);
    }

    public void takeRangedDmg()
    {
        hc.takeDamage(rangedDamage);
    }

}
