using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Auto implemented properties!
    public string Name {get; set;} = "Enemy";
    public int Health {get; set;} = 3;
    public int Damage {get; set;} = 1;
    public float MoveSpeed {get; set;} = 2.4f;
    public float MinDistance {get; set;} = 0.8f;

    [SerializeField] private Transform targetPlayer;
    private EnemyCollider enemyColliderSript;
    private NavMeshAgent agent;
    
    void Awake() 
    {
        enemyColliderSript = GetComponent<EnemyCollider>();
    }

    void Start() 
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        Movement();

        CheckHealth();
    }

    void Movement()
    {
        if(enemyColliderSript.IsPlayer == true && Vector2.Distance(transform.position, targetPlayer.position) > MinDistance)
        {
            agent.enabled = true;
            agent.SetDestination(targetPlayer.position);
        }
        else
        {
            agent.enabled = false;
        }

        // Move the enemy towards target without navmesh    
        /*transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position,
                                                 MoveSpeed * Time.deltaTime);*/
    }

    public virtual void AttackPlayer()
    {
        Debug.Log(Name + " attacked the player by " + Damage + " Points!");
        //Damage += 10;
    }

    private void CheckHealth()
    {
        if(Health <= 0)
            Destroy(gameObject);
    }
}
