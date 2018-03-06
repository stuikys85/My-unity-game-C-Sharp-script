using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;
    public Slider healthBar;


    chase Chase;

    private void Start()
    {
        Chase = GetComponent<chase>();
    }


    public void DeductHealth(float deductHealth)
    {
        healthBar.value = deductHealth;
        enemyHealth -= deductHealth;
        if(enemyHealth <= 0) {
            EnemyDead();
            healthBar.value = 0;

        }

    }
	
    void EnemyDead()
    {
        Chase.EnemyDeathAnim();
        Destroy(gameObject, 6);
    }
}
