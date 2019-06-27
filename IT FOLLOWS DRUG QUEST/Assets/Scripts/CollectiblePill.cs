using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePill : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D otherP)
    {
        MoveWithInput controller = otherP.GetComponent<MoveWithInput>();

        if (controller != null)
        {
            if (controller.currentPill < controller.maxPill)
            {
                controller.ChangePill(1);
                Destroy(gameObject);
            }
        }
    }
}


