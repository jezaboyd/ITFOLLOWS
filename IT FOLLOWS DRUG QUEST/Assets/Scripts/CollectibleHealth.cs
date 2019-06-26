using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHealth : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        MoveWithInput controller = other.GetComponent<MoveWithInput>();

        if (controller != null)
        {
            if (controller.currentHealth < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
            }
        }
    }
}


