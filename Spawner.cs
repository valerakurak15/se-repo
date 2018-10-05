using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject spawnObject;
    public float spawnTime = 1f;

    private float timer = 0;
    void Start()
    {

    }


    void Update()
    {
        timer -= Time.deltaTime;

        if (timer<=0)
        {
            Instantiate(spawnObject, transform.position, transform.rotation);

            timer = spawnTime;
        }
    }
}
