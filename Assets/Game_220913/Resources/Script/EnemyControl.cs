using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    Animator animator;
    NavMeshAgent navAgent;

    public GameObject[] player_attack;
    public GameObject player = null;

    private float timer = 0;
    private float waiting = 5.0f;
    bool attacked = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameState == 1)
        {
            if (!attacked)
            {
                navAgent.destination = player.transform.position;

            }
            else
            {
                navAgent.destination = transform.position;
                timer += Time.deltaTime;
                if (waiting < timer)
                {
                    timer = 0;
                    attacked = false;
                }
            }
        }
        
            
        //animatorControl();
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Speed", navAgent.velocity.magnitude);
    }

    void animatorControl()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;

        if(hitObject.layer == LayerMask.NameToLayer("Fire"))
        {
            if(GameManager.Instance.fire)
            {
                animator.SetTrigger("hit");
            }
        }

        for (int i = 0; i < player_attack.Length; i++)
        {
            if (hitObject.gameObject == player_attack[i].gameObject)
            {
                GameManager.Instance.attackGuage -= 10;
                animator.SetTrigger("hit");
                attacked = true;
            }
        }
    }
}
