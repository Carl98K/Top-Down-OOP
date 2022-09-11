using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
   public bool IsPlayer {get; private set;} = false; 

   //private Enemy enemyScript;
   private SimpleFlashFx sFlashFxScript;

   void Awake() 
   {
        //enemyScript = GetComponent<Enemy>(); 
        sFlashFxScript = GetComponent<SimpleFlashFx>();
   }

    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
            IsPlayer = true;    
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        IsPlayer = false;    
    } 

    void OnCollisionEnter2D(Collision2D other) 
    {
        //if(other.gameObject.CompareTag("Player"))
            //enemyScript.AttackPlayer();
        if(other.gameObject.CompareTag("Bullet"))
        {
            //enemyScript.Health -= other.gameObject.GetComponent<Bullet>().BulletDamage;
            //Debug.Log(enemyScript.Health);
            sFlashFxScript.Flash();
        }            
    }
}
