using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour {

    public Transform Player;
    public Animator anim;
    bool isDead = false;
    public float damageAmount = 30f;
    public bool canAttack = true;
    AudioSource gunAS;
    [SerializeField]
    float attackTime = 2f;
    public AudioClip shootAC;



    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        gunAS = GetComponent<AudioSource>();
    }


	
	// Update is called once per frame
	void Update ()

    {
        Vector3 direction = Player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);

		if(Vector3.Distance(Player.position, this.transform.position) <15 && angle <120&& !isDead)
        {

            direction.y = 0;


            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);


            anim.SetBool("isIdle", false);
            if (direction.magnitude > 8)
            {
                this.transform.Translate(0, 0, 0.3f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
                
            }

            
            else if(canAttack&& !PlayerHealth.singleton.isDead)
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
                StartCoroutine(AttackTime());
               
                gunAS.PlayOneShot(shootAC);
            }
           else if(!PlayerHealth.singleton.isDead)
            {
                
                DisableEnemy();
            }
           

            }
            else 
            {
                anim.SetBool("isIdle", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", false);
        }


        }
    public void EnemyDeathAnim()
    {
        isDead = true;
        anim.SetTrigger("isDead");
    }

    void DisableEnemy()
    {
        canAttack = false;
        anim.SetBool("isAttacking", false);
        anim.SetBool("isWalking", false);
    }

    IEnumerator AttackTime()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.5f);
       
        PlayerHealth.singleton.DamagePlayer(damageAmount);
        yield return new WaitForSeconds(attackTime);
        canAttack = true;
    }


	}

