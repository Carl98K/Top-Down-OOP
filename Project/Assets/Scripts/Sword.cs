using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private Animator swordAnim;
    [SerializeField] private string swordType;
    [SerializeField] private int normalSwordDamage = 0, greatSwordDamage = 0;

    #region Properties
    /*public string SwordType
    {
        get
        {
            return swordType;
        }
        set
        {
            if(value == "Normal" || value == "Great")
            {
                swordType = value;
            }
            else
            {
                swordType = "None";
                Debug.Log("Sword type not known");
            }
        }
    }

    private int NormalSwordDamage
    {
        get 
        {
            return normalSwordDamage;
        }
        set
        {
            if(normalSwordDamage > 5)
                normalSwordDamage = value;
        }
    }*/
    #endregion

    public void AnimateSword()
    {
        swordAnim.SetTrigger("isAttack");
    }

    public int DamageEnemy()
    {
        Debug.Log("Sword Attack!");

        if(swordType == "Normal")
            return normalSwordDamage;
        else if(swordType == "Great Sword")
            return greatSwordDamage;
        else
            return 0;
    }
}
