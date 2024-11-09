using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthController : MonoBehaviour
{
    public int _health = 1;
    public int _maxHealth = 2;



    public Image Heart1;
    public Image Heart2;



    // Start is called before the first frame update
    void Start()
    {
        _health = _maxHealth;
    }
    public void UpdateHearts(int PlayerHearts)
    {
        if (PlayerHearts == 2)
        {
            Heart1.color = Color.HSVToRGB(0, 0, 100);
            Heart2.color = Color.HSVToRGB(0, 0, 100);
        }
        else if (PlayerHearts == 1)
        {
            Heart1.color = Color.HSVToRGB(0, 0, 100);
            Heart2.color = Color.HSVToRGB(0, 0, 0);
        }
        else if (PlayerHearts == 0)
        {
            Heart1.color = Color.HSVToRGB(0, 0, 0);
            Heart2.color = Color.HSVToRGB(0, 0, 0);
        }
    }
    void Update()
    {
        if (_health <= 0)
        {

        }
    }

    private void OnTriggerEnter2d(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                takeDamage(1);
            }
        }

        private void takeDamage(int damage)
        {
            _health = _health - damage;
          gameObject.GetComponent<HealthController>().UpdateHearts(_health);

        }

    }
