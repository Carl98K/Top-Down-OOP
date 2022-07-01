using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Auto implemented properties!
    private string Name {get; set;} = "Enemy";
    private int Health {get; set;} = 5;
    private int Damage {get; set;} = 100;
    private float MoveSpeed {get; set;} = 2.4f;
    private float MinDistance {get; set;} = 5f;

    [SerializeField] private Transform targetPlayer;
    
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(Health);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(Vector2.Distance(transform.position, targetPlayer.position) > MinDistance)
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position,
                                                     MoveSpeed * Time.deltaTime);
        else
            AttackPlayer();
    }

    void AttackPlayer()
    {
        Debug.Log(Name + " attacked the player by " + Damage + " Points!");
    }
}
