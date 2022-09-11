using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _moveSpeed ;
    [SerializeField] private float _minDistance;

    public string Name
    {
        get { return _name; }
    }

    public int Health
    {
        get { return _health; }
    }

    public int Damage
    {
        get { return _damage; }
    }

    public float MoveSpeed
    {
        get { return _moveSpeed; }
    }

    public float MinDistance
    {
        get { return _minDistance; }
    }
}
