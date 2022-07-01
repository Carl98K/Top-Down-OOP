using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPos;
    [SerializeField] private float fireRate = 1f;
    private float nextFire = 0f;

    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }

    void Fire()
    {
        GameObject bullet = ObjectPoolRevamp.sharedInstance.GetPooledObject();

        if(bullet != null)
        {
            bullet.transform.position = bulletSpawnPos.position;
            bullet.transform.rotation = bulletSpawnPos.rotation;
            bullet.SetActive(true);
        }
    }
}
