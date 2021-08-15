using System.Collections;
using System.Collections.Generic;
//using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

public enum CryptoState
{
    IDLE,
    RUN
}

public class ZombieBehaviour : MonoBehaviour
{
    [Header("Line of Sight")] 
    public bool HasLOS = false;

    public GameObject player;

    private NavMeshAgent agent;
    private Animator animator;

    public float health = 50f;
    public float distanceToPlayer;
    public float attackDistance = 2.5f;

    public float AttackRate = 3f;
    private float nextTimeToAttack = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if(Vector3.Distance(transform.position, player.transform.position) < 20)
        {
            HasLOS = true;
        }
        else
        {
            HasLOS = false;
        } 
        */

        if (HasLOS)
        {
            agent.SetDestination(player.transform.position);
            distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        }


        if (HasLOS && distanceToPlayer <= attackDistance)
        {
            // could be an attack
            animator.SetInteger("AnimState", (int)CryptoState.IDLE);
            transform.LookAt(transform.position - player.transform.forward);
            Attack();

        }
        else if (HasLOS && distanceToPlayer > attackDistance)
        {
            animator.SetInteger("AnimState", (int)CryptoState.RUN);
        }
        else
        {
            animator.SetInteger("AnimState", (int)CryptoState.IDLE);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Collision occured");
            HasLOS = true;
            player = other.transform.gameObject;
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void Attack()
    {
        if (Time.time >= nextTimeToAttack)
        {
            nextTimeToAttack = Time.time + AttackRate; //take damage for every 3 sec
            PlayerDamage();
        }

    }

    void PlayerDamage()
    {
        player.GetComponent<PlayerController>().TakeDamage(10f);
        SoundManager.PlaySound("hurt");
    }



}

