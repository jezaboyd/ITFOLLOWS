using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform target;

    //public void Start()
    //{
    //    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    //}


    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
