using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_AddForce : MonoBehaviour
{
    // this script lets the developer set (or randomizes) a force and torque and adds it to the gameobject

    public bool randomForce;    //set true if force should be generated randomly
    public float dirX;          //Forces X Direction
    public float dirY;          //Forces Y Direction
    public float torque;        //Forces Torque

    private Rigidbody2D rb2d;

    private void Start()
    {
        //sets a random force for the impuls
        if(randomForce == true)
        {
            dirX = Random.Range(-5, 5);     //you can change the possible range here
            dirY = Random.Range(5, 10);
            torque = Random.Range(5, 15);
        }
        
        rb2d = GetComponent<Rigidbody2D>();

        rb2d.AddForce(new Vector2(dirX, dirY),ForceMode2D.Impulse);
        rb2d.AddTorque(torque,ForceMode2D.Force);
    }
}
