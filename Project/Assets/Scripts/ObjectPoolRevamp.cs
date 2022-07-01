using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolRevamp : MonoBehaviour
{
    public static ObjectPoolRevamp sharedInstance;

    [SerializeField] private GameObject objectToPool;
    private List<GameObject> pooledObjects;
    private int amountToPool = 15;

    void Awake() 
    {
        sharedInstance = this;    
    }

    void Start()
    {
        CreatePoolObjects();
    }

    void CreatePoolObjects()
    {
        pooledObjects = new List<GameObject>();

        GameObject tmp;
        
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            tmp.transform.parent = transform;
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
