using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;

    public HealthBar healthBar;

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        if( Input.GetKeyDown( KeyCode.Space ) )
        {
            DamagePlayer(10);
        }
    }

    public void DamagePlayer( int damage )
    {
        curHealth -= damage;
        if(curHealth == 0) {
            Debug.Log("DEAD");
        }
        healthBar.SetHealth( curHealth );
    }
}