using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_ShadowScaler : MonoBehaviour
{
    // this script adjusts the shadows x- and y- scale depending on the distance between shadow and object

    public float multiplicatorX = 1;        // Scale-Multiplicator in X-Direction (set in inspector)
    public float multiplicatorY = 1;        // Scale-Multiplicator in Y-Direction (set in inspector)
    public GameObject item;                 // object that casts the shadow ( assign in inspector)
    public GameObject shadow;               // shadow that is casted ( assign in inspector)

    private Vector3 startScale;
    private Vector3 shadowScale;
    private float distY;
    

	
	void Start ()
    {
        startScale = shadow.transform.localScale;
	}	
	
	void Update ()
    {
        distY = item.transform.position.y - shadow.transform.position.y;
        shadow.transform.localScale = new Vector3(startScale.x + distY * multiplicatorX, startScale.y + distY * multiplicatorY, startScale.z);
    }
}
