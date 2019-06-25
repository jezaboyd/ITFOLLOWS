using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_ScaleSwitch : MonoBehaviour
{
    //this script switches the y-scale of the player when the trigger is entered (only for demoscene)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.localScale = new Vector3(collision.transform.localScale.x * -1, collision.transform.localScale.y, collision.transform.localScale.z);            
        }
    }

}
