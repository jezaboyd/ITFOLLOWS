using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_PickUp : MonoBehaviour
{
    //this script lets the developer play an effect and instantiates a gameobject if -
    // - the Tag "Player" enters the gameobjects trigger

    public GameObject pickUpEffect;         //the effect played when picking up the object
    public GameObject spawnAfterPickUp;     //the gameobject instantiated when picking up the object

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            if(pickUpEffect != null)
            {
                Instantiate(pickUpEffect, transform.position, Quaternion.identity);
            }
            
            if(spawnAfterPickUp != null)
            {
                Instantiate(spawnAfterPickUp, transform.position, Quaternion.identity);
            }
        }
    }
}
