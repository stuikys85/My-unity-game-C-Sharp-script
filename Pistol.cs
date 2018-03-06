using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    RaycastHit hit;

    // use to damage enemy
    [SerializeField]
    float damageEnemy = 20f;

    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    int currentAmmo;

    // Weapon Effects
    // Muzzle Flash
    public ParticleSystem muzzleflash;
    // Eject bullet casing
    public ParticleSystem bulletCasing;

    //Gun audio
    AudioSource gunAS;
    public AudioClip shootAC;

    //rate Od Fire
    [SerializeField]
    float rateOfFire;
    float nextFire = 0;


    [SerializeField]
    float weaponRange;

     void Start()
    {

        muzzleflash.Stop();
        bulletCasing.Stop();
        gunAS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButton("Fire1")&& currentAmmo>0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + rateOfFire;

            currentAmmo--;
            
            gunAS.PlayOneShot(shootAC);

            StartCoroutine(WeaponEffects());

            if(Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, weaponRange))
            {
                if(hit.transform.tag == "Enemy")
                {
                    Debug.Log("Hit Enemy");
                    EnemyHealth enemyHealthScript = hit.transform.GetComponent<EnemyHealth>();
                    enemyHealthScript.DeductHealth(damageEnemy);
                    
                }
                else
                {
                    Debug.Log("Hit Something Else");
                }
            }
        }
    }

    IEnumerator WeaponEffects()
    {
        bulletCasing.Play();
        muzzleflash.Play();
        yield return new WaitForEndOfFrame();
        muzzleflash.Stop();
        bulletCasing.Stop();
    }

	
}
