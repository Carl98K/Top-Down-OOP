using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   /* [Header("Attack Attributes")]
    [SerializeField] private Transform attackPos;
    [SerializeField] private float attackRange;
    [SerializeField] private int attackDamage;
    [SerializeField] private float timeBtwAttack;
    [SerializeField] private float startTimeBtwAttack;*/

    [Header("Components Reference")]
    [SerializeField] private Sword swordClass;
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask enemies;

    // Start is called before the first frame update
    private void Update()
    {
            if(Input.GetKeyDown(KeyCode.J))
            {
                swordClass.AnimateSword();
                swordClass.DamageEnemy();
                //GetComponent<Sword>().AnimateSword();
                //GetComponent<Sword>().DamageEnemy();
            }

    }
}
