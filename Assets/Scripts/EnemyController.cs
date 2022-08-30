using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;

    public float rangeToChasePlayer;
    private Vector3 moveDirection;

    public Animator anim;

    public int health = 150;

    public GameObject[] deathSplatters;
    public GameObject hiteffect;

    public bool shouldShoot;

    public GameObject bullet;
    public Transform firePoint;
    public float fireRate;
    private float fireCounter;

    public float shootRange;

    public SpriteRenderer theBody;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(theBody.isVisible && PlayerMovement.instance.gameObject.activeInHierarchy)
        {
            if (Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) < rangeToChasePlayer)
            {
                moveDirection = PlayerMovement.instance.transform.position - transform.position;
            }
            else
            {
                moveDirection = Vector3.zero;
            }

            moveDirection.Normalize();

            theRB.velocity = moveDirection * moveSpeed;

            //enemy shoot
            if (shouldShoot && Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) < shootRange)
            {
                fireCounter -= Time.deltaTime;

                if (fireCounter <= 0)
                {
                    fireCounter = fireRate;
                    Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                    AudioManager.instance.PlaySFX(13);
                }
            }
        }else 
        {
            theRB.velocity = Vector2.zero;
        }
        //enemy animatons
        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

    }

    public void DamageEnemy(int damage)
    {
        health -= damage;
        AudioManager.instance.PlaySFX(2);

        Instantiate(hiteffect, transform.position, transform.rotation);

        if(health <= 0)
        {
            Destroy(gameObject);
            AudioManager.instance.PlaySFX(1);
            
            int selectedSplatter = Random.Range(0,deathSplatters.Length);
            Instantiate(deathSplatters[selectedSplatter], transform.position, transform.rotation);
        }
    }
     
}
