using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        MoveWithInput player = other.gameObject.GetComponent<MoveWithInput>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
