using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_TrapTrigger : MonoBehaviour

{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if something enters the trigger call TriggerEnter in parent
        gameObject.GetComponentInParent<PS_Trap>().TriggerEnter(collision); 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if something exits the trigger call TriggerExit in parent
        gameObject.GetComponentInParent<PS_Trap>().TriggerExit(collision);
    }
}
