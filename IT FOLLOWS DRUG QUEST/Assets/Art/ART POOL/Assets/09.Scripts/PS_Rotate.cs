using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_Rotate : MonoBehaviour
{
    //this script lets the gameobject rotate or swing

    public float speed = 5;             //the rotation- / swing-speed
    public bool swing = false;          //false lets the gameobject rotate
    public float swingAngle = 90;       //the maximum Angle when swing is true
    void Update ()
    {
        if (!swing)
        {
            transform.Rotate(Vector3.back * Time.deltaTime * speed*100);
        }
        else
        {
            float angle = Mathf.Sin(Time.time*speed) * swingAngle/2; 

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);

        }
    }
    }
        

