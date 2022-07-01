using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;

    private void Update() 
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);    
        }
        else if(other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);    
        }
    }
}
