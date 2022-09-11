using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyData enemySO;
    [SerializeField] private EnemyCollider enemyColliderScript;
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float moveSpeed;
    private float minDistance;

    private void Awake() 
    {
        moveSpeed = enemySO.MoveSpeed;
        minDistance = enemySO.MinDistance;
    } 

    // Start is called before the first frame update
    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if(enemyColliderScript.IsPlayer && Vector2.Distance(transform.position, target.position) > minDistance)
        {
            agent.enabled = true;
            agent.SetDestination(target.position);
        }
        else
        {
            agent.enabled = false;
        }

        // Move the enemy towards target without navmesh    
        /*transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position,
                                                 MoveSpeed * Time.deltaTime);*/
    }
}
