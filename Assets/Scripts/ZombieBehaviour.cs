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
    public bool HasLOS;

    public GameObject player;

    private NavMeshAgent agent;
    private Animator animator;

    public float health = 50f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HasLOS)
        {
            agent.SetDestination(player.transform.position);
        }


        if(HasLOS && Vector3.Distance(transform.position, player.transform.position) < 2.5)
        {
                // could be an attack
            animator.SetInteger("AnimState", (int)CryptoState.IDLE);
            transform.LookAt(transform.position - player.transform.forward);

            if (agent.isOnOffMeshLink)
            {
                //animator.SetInteger("AnimState", (int)CryptoState.JUMP);
            }
        }
        else
        {
            animator.SetInteger("AnimState", (int)CryptoState.RUN);
        }

        //Debug.Log(Vector3.Distance(transform.position, player.transform.position));
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

}

