using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_TimedSpawner : MonoBehaviour
{

    public GameObject objectToSpawn;        // (assign in inspector)
    public float spawntimer = 0.35f;        // (set in inspector)
    private float timer;

    public void Start()
    {
        timer = 0;
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnRunDust();
        }
        
    }

    public void SpawnRunDust()
    {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        timer = spawntimer;
    }
}
