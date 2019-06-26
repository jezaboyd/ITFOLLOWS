using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        MoveWithInput controller = other.GetComponent<MoveWithInput>();

        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
    }

}
