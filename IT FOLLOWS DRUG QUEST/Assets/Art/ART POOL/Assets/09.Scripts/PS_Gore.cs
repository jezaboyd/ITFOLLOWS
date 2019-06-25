using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_Gore : MonoBehaviour {

    //this script lets the developer play an effect and instantiates an array of gameobjects if -
    // - the tag "Trap" enters the gameobjects trigger

    public GameObject bloodSplatter;    //the effect played when entering the trap
    public GameObject[] goreParts;      //the gameobjects instantiated when entering the trap

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            gameObject.SetActive(false);
            if (bloodSplatter != null)
            {
                Instantiate(bloodSplatter, transform.position, Quaternion.identity);
            }

            if (goreParts != null)
            {
                foreach (GameObject gorePart in goreParts)
                {
                    
                    Instantiate(gorePart, transform.position, Quaternion.identity);
                }
                
            }
        }
    }
}
