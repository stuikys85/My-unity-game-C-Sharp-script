using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth singleton;
    public float currentHealth;
    public static int maxHealth = 150;
    public bool isDead = false;
    public Slider healthBar;
    
    

    private void Awake()
    {
        singleton = this;
    }

    void Start ()
    {
        
        currentHealth = maxHealth;
        healthBar.value = currentHealth;


    }
	
	
	void Update ()
    {
		
        if(currentHealth<0)
        {
            currentHealth = 0;
        }

	}

    public void DamagePlayer(float damage)
    {
        if(currentHealth>0)
        {
            currentHealth -= damage;
            healthBar.value = currentHealth;
        }
        else
        {   
            Dead();
        }

    }
      void Dead()
    {
        currentHealth = 0;
        isDead = true;
        Debug.Log("Player is dead");
        FindObjectOfType<GameManager>().EndGame();
        
        
    }
}
