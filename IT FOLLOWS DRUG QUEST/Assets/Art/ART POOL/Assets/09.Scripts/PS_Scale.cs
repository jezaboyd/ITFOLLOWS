using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_Scale : MonoBehaviour
{
    //this script scales a gamobject from startscale to endscale
    
    public Vector3 startScale = Vector3.zero;       //scale the object is set to when starting
    public Vector3 endScale = Vector3.one;          //scale the object is when finished
    public float scaleSpeed= 1;                     //speed of the scaling
	
	void Start ()
    {
        transform.localScale = startScale;
	}
	
	void Update ()
    {
        if ( transform.localScale.x < endScale.x && transform.localScale.y < endScale.y && transform.localScale.z < endScale.z)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, Time.time*scaleSpeed);
        }
	}
}
