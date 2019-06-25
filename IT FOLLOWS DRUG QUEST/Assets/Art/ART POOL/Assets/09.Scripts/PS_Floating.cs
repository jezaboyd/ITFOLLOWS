using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_Floating : MonoBehaviour
{
    //this script lets the gameobject float with a certain speed and amplitude

    private Vector3 startposition;
    public float amplitude=1;       //the floating amplitude (set in inspector)
    public float speed=1;           //the floating speed (set in inspector)

	void Start ()
    {
        startposition = transform.position;
	}	
	
	void Update ()
    {
        transform.position = new Vector3(startposition.x, startposition.y + amplitude * Mathf.Sin(speed * Time.time), startposition.z);
	}
}
