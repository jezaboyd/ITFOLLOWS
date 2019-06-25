using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_ShootArrow : MonoBehaviour
{   
    //Just for demo
    //this script instantiates the gameobject set in the inspector

    public GameObject arrow;

    public void FireArrow()
    {
        Instantiate(arrow,transform.position+new Vector3(0.8f,-0.1f,0),Quaternion.identity);
    }
	
}
